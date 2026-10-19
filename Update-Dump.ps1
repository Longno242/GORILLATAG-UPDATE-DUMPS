#Requires -Version 5.1
<#
.SYNOPSIS
  Re-decompile Gorilla Tag Managed DLLs and sync only changed source into the dump folder.
#>
[CmdletBinding()]
param(
  [string]$ManagedPath = "",
  [string]$OutRoot = "",
  [switch]$SkipConfirm
)

$ErrorActionPreference = "Stop"

# --- paths ------------------------------------------------------------------
if (-not $OutRoot) {
  $OutRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
}
if (-not $ManagedPath) {
  $ManagedPath = "C:\Program Files (x86)\Steam\steamapps\common\Gorilla Tag\Gorilla Tag_Data\Managed"
}

$KeepNames = [System.Collections.Generic.HashSet[string]]::new(
  [string[]]@(
    ".git", ".vs", ".idea",
    "Update-Dump.ps1", "DUMP.bat", "README.md", ".gitignore",
    "DUMP_STAMP.txt", "DUMP_CHANGES.txt", "DUMP_CHANGES.html"
  ),
  [StringComparer]::OrdinalIgnoreCase
)

$SkipAssemblies = [System.Collections.Generic.HashSet[string]]::new(
  [string[]]@(
    "mscorlib", "netstandard",
    "System", "System.Core", "System.Data", "System.Data.DataSetExtensions",
    "System.Drawing", "System.IO.Compression", "System.IO.Compression.FileSystem",
    "System.ComponentModel.Composition", "System.Configuration", "System.Numerics",
    "System.Runtime.Serialization", "System.Security", "System.Transactions",
    "System.Xml", "System.Xml.Linq", "System.Net.Http", "System.ServiceModel.Internals"
  ),
  [StringComparer]::OrdinalIgnoreCase
)

# --- console chrome ---------------------------------------------------------
function Set-Theme {
  try {
    $host.UI.RawUI.WindowTitle = "GT DUMP  //  sync changed code"
    $host.UI.RawUI.BackgroundColor = "Black"
    $host.UI.RawUI.ForegroundColor = "Green"
    Clear-Host
  } catch {}
}

function Write-Banner {
  $c = [ConsoleColor]::DarkGreen
  $a = [ConsoleColor]::Green
  $lines = @(
    "",
    "  ============================================================",
    "   _______    /",
    "  /       \",
    " /  _____  \          G O R I L L A   T A G",
    "/ / _   _ \ \         D U M P   U P D A T E R",
    "[ | (O) (O) | ]",
    " | \  . .  / |        sync only changed code",
    " |  | _._ |  |",
    "  ============================================================",
    ""
  )
  foreach ($line in $lines) {
    Write-Host $line -ForegroundColor $(if ($line -match "G O R I L L A|D U M P") { $a } else { $c })
  }
}

function Write-Step([string]$msg) {
  Write-Host ("  > " + $msg) -ForegroundColor Cyan
}

function Write-Ok([string]$msg) {
  Write-Host ("  + " + $msg) -ForegroundColor Green
}

function Write-WarnLine([string]$msg) {
  Write-Host ("  ! " + $msg) -ForegroundColor Yellow
}

function Write-ErrLine([string]$msg) {
  Write-Host ("  x " + $msg) -ForegroundColor Red
}

function Write-Bar([int]$current, [int]$total, [string]$label) {
  $width = 28
  if ($total -le 0) { $pct = 0 } else { $pct = [int](($current / $total) * 100) }
  $filled = [int](($pct / 100.0) * $width)
  if ($filled -gt $width) { $filled = $width }
  $bar = ("#" * $filled).PadRight($width, ".")
  $name = if ($label.Length -gt 34) { $label.Substring(0, 31) + "..." } else { $label.PadRight(34) }
  Write-Host ("`r  [$bar] {0,3}%  {1}" -f $pct, $name) -NoNewline -ForegroundColor Green
}

# --- resolve tools ----------------------------------------------------------
function Resolve-IlSpyCmd {
  $cmd = Get-Command ilspycmd -ErrorAction SilentlyContinue
  if ($cmd) { return $cmd.Source }
  $fallback = Join-Path $env:USERPROFILE ".dotnet\tools\ilspycmd.exe"
  if (Test-Path $fallback) { return $fallback }
  return $null
}

function Get-SteamBuildId {
  $acf = "C:\Program Files (x86)\Steam\steamapps\appmanifest_1533390.acf"
  if (-not (Test-Path $acf)) { return "unknown" }
  $raw = Get-Content $acf -Raw
  if ($raw -match '"buildid"\s+"(\d+)"') { return $Matches[1] }
  return "unknown"
}

function Get-FileHashFast([string]$path) {
  return (Get-FileHash -LiteralPath $path -Algorithm SHA256).Hash
}

function Escape-Html([string]$text) {
  if ($null -eq $text) { return "" }
  return ($text -replace "&", "&amp;" -replace "<", "&lt;" -replace ">", "&gt;" -replace '"', "&quot;")
}

function Get-UnifiedDiffLines([string]$oldPath, [string]$newPath) {
  $prev = $ErrorActionPreference
  $ErrorActionPreference = "Continue"
  $raw = & git -c core.safecrlf=false --no-pager diff --no-index --unified=3 --ignore-cr-at-eol -- $oldPath $newPath 2>&1
  $ErrorActionPreference = $prev
  $out = New-Object System.Collections.Generic.List[string]
  if ($null -eq $raw) { return ,$out.ToArray() }
  # Prevent PowerShell from iterating a single string as chars
  $items = if ($raw -is [System.Array]) { $raw } else { @($raw) }
  foreach ($item in $items) {
    [void]$out.Add([string]$item)
  }
  return ,$out.ToArray()
}

function Get-AllLinesAsDiff([string]$path, [ValidateSet("add", "del")][string]$mode) {
  if (-not (Test-Path -LiteralPath $path)) { return ,([string[]]@()) }
  $prefix = if ($mode -eq "add") { "+" } else { "-" }
  $lines = Get-Content -LiteralPath $path -ErrorAction SilentlyContinue
  if ($null -eq $lines) { return ,([string[]]@()) }
  $max = 800
  $out = New-Object System.Collections.Generic.List[string]
  $n = 0
  $items = if ($lines -is [System.Array]) { $lines } else { @($lines) }
  foreach ($line in $items) {
    $n++
    if ($n -gt $max) {
      [void]$out.Add($prefix + "... truncated ...")
      break
    }
    [void]$out.Add($prefix + [string]$line)
  }
  return ,$out.ToArray()
}

function Write-ConsoleDiff {
  param(
    [string]$Rel,
    [string]$Kind,
    $DiffLines
  )
  $color = switch ($Kind) {
    "A" { "Green" }
    "D" { "Red" }
    default { "Yellow" }
  }
  Write-Host ""
  Write-Host ("  ---- $Kind  $Rel ----") -ForegroundColor $color
  $shown = 0
  foreach ($rawLine in @($DiffLines)) {
    $line = [string]$rawLine
    if ($line -match '^diff --git' -or $line -match '^index ' -or $line -match '^---' -or $line -match '^\+\+\+') { continue }
    if ($line.StartsWith("-")) {
      Write-Host ("  " + $line) -ForegroundColor Red
      $shown++
    } elseif ($line.StartsWith("+")) {
      Write-Host ("  " + $line) -ForegroundColor Green
      $shown++
    } elseif ($line.StartsWith("@@")) {
      Write-Host ("  " + $line) -ForegroundColor Cyan
    }
    if ($shown -ge 80) {
      Write-Host "  ... (more in DUMP_CHANGES.html)" -ForegroundColor DarkGray
      break
    }
  }
}

function Get-CollectionCount($collection) {
  if ($null -eq $collection) { return 0 }
  if ($collection -is [System.Collections.ICollection]) { return $collection.Count }
  return @($collection).Length
}

function New-DumpChangesHtml {
  param(
    [Parameter(Mandatory)][string]$Path,
    [Parameter(Mandatory)][string]$BuildId,
    [Parameter(Mandatory)]$Stats,
    [Parameter(Mandatory)]$FileDiffs
  )

  $css = @(
    'body{margin:0;font-family:Segoe UI,Helvetica,Arial,sans-serif;background:#0d1117;color:#e6edf3}'
    'header{padding:20px 28px;border-bottom:1px solid #30363d;background:#010409}'
    'header h1{margin:0 0 6px;font-size:20px}'
    'header p{margin:0;color:#8b949e;font-size:13px}'
    '.stats{display:flex;gap:14px;margin-top:12px;flex-wrap:wrap}'
    '.pill{font-size:12px;padding:4px 10px;border-radius:999px;border:1px solid #30363d}'
    '.pill.add{color:#3fb950;border-color:#238636}'
    '.pill.mod{color:#d29922;border-color:#9e6a03}'
    '.pill.del{color:#f85149;border-color:#da3633}'
    '.pill.keep{color:#8b949e}'
    'nav{padding:12px 28px;border-bottom:1px solid #30363d;font-size:13px}'
    'nav a{color:#58a6ff;text-decoration:none;margin-right:14px}'
    '.file{margin:18px 28px;border:1px solid #30363d;border-radius:8px;overflow:hidden;background:#0d1117}'
    '.file-head{padding:10px 14px;background:#161b22;border-bottom:1px solid #30363d;font-family:Consolas,monospace;font-size:13px}'
    '.badge{display:inline-block;min-width:18px;text-align:center;font-weight:700;margin-right:8px}'
    '.badge.A{color:#3fb950}.badge.M{color:#d29922}.badge.D{color:#f85149}'
    'pre.diff{margin:0;padding:0;overflow:auto;font-family:Consolas,monospace;font-size:12px;line-height:1.45}'
    '.line{display:block;white-space:pre;padding:0 12px;border-left:3px solid transparent}'
    '.line.add{background:rgba(46,160,67,.15);border-left-color:#3fb950;color:#aff5b4}'
    '.line.del{background:rgba(248,81,73,.15);border-left-color:#f85149;color:#ffdcd7}'
    '.line.ctx{color:#e6edf3}'
    '.line.hunk{background:rgba(56,139,253,.1);color:#79c0ff}'
    '.line.meta{color:#8b949e}'
  ) -join ''

  $sb = New-Object System.Text.StringBuilder
  [void]$sb.AppendLine('<!DOCTYPE html>')
  [void]$sb.AppendLine('<html lang="en"><head><meta charset="utf-8"/>')
  [void]$sb.AppendLine(('<title>GT Dump Changes - build {0}</title>' -f (Escape-Html $BuildId)))
  [void]$sb.AppendLine(('<style>{0}</style></head><body>' -f $css))
  [void]$sb.AppendLine('<header><h1>Gorilla Tag dump sync</h1>')
  [void]$sb.AppendLine(('<p>buildid={0} | {1} | red=removed green=added</p>' -f (Escape-Html $BuildId), (Escape-Html ([string]$Stats.DumpedUtc))))
  [void]$sb.AppendLine('<div class="stats">')
  [void]$sb.AppendLine(('<span class="pill add">+ {0} added</span>' -f $Stats.Added))
  [void]$sb.AppendLine(('<span class="pill mod">~ {0} updated</span>' -f $Stats.Updated))
  [void]$sb.AppendLine(('<span class="pill del">- {0} removed</span>' -f $Stats.Removed))
  [void]$sb.AppendLine(('<span class="pill keep">{0} unchanged</span>' -f $Stats.Unchanged))
  [void]$sb.AppendLine('</div></header><nav>')

  $idx = 0
  foreach ($fd in $FileDiffs) {
    $idx++
    [void]$sb.AppendLine(('  <a href="#f{0}">{1} {2}</a>' -f $idx, $fd.Kind, (Escape-Html $fd.Path)))
  }
  [void]$sb.AppendLine('</nav>')

  $idx = 0
  foreach ($fd in $FileDiffs) {
    $idx++
    [void]$sb.AppendLine(('<section class="file" id="f{0}">' -f $idx))
    [void]$sb.AppendLine(('<div class="file-head"><span class="badge {0}">{0}</span>{1}</div>' -f $fd.Kind, (Escape-Html $fd.Path)))
    [void]$sb.AppendLine('<pre class="diff">')
    foreach ($rawLine in @($fd.Lines)) {
      if ($null -eq $rawLine) { continue }
      $line = [string]$rawLine
      $esc = Escape-Html $line
      # Concatenate (don't use -f) so C# braces in code don't break formatting
      if ($line -match '^diff --git' -or $line -match '^index ' -or $line -match '^---' -or $line -match '^\+\+\+') {
        [void]$sb.AppendLine('<span class="line meta">' + $esc + '</span>')
      } elseif ($line.StartsWith('@@')) {
        [void]$sb.AppendLine('<span class="line hunk">' + $esc + '</span>')
      } elseif ($line.StartsWith('+')) {
        [void]$sb.AppendLine('<span class="line add">' + $esc + '</span>')
      } elseif ($line.StartsWith('-')) {
        [void]$sb.AppendLine('<span class="line del">' + $esc + '</span>')
      } else {
        [void]$sb.AppendLine('<span class="line ctx">' + $esc + '</span>')
      }
    }
    [void]$sb.AppendLine('</pre></section>')
  }

  [void]$sb.AppendLine('</body></html>')
  [System.IO.File]::WriteAllText($Path, $sb.ToString(), [System.Text.UTF8Encoding]::new($false))
}

function Sync-DumpTree {
  param(
    [Parameter(Mandatory)][string]$StageRoot,
    [Parameter(Mandatory)][string]$DestRoot,
    [Parameter(Mandatory)]$KeepNames
  )

  $added = 0
  $updated = 0
  $unchanged = 0
  $removed = 0
  $changeLog = New-Object System.Collections.Generic.List[string]
  $fileDiffs = New-Object System.Collections.Generic.List[object]

  $stageFiles = @{}
  Get-ChildItem -LiteralPath $StageRoot -Recurse -File -Force | ForEach-Object {
    $rel = $_.FullName.Substring($StageRoot.Length).TrimStart("\", "/")
    $stageFiles[$rel] = $_.FullName
  }

  $i = 0
  $total = [Math]::Max($stageFiles.Count, 1)
  foreach ($rel in ($stageFiles.Keys | Sort-Object)) {
    $i++
    if (($i % 50) -eq 0 -or $i -eq $total) {
      Write-Bar $i $total "syncing files"
    }
    $src = $stageFiles[$rel]
    $dst = Join-Path $DestRoot $rel
    $dstDir = Split-Path -Parent $dst
    if (-not (Test-Path -LiteralPath $dstDir)) {
      New-Item -ItemType Directory -Path $dstDir -Force | Out-Null
    }

    $isCode = $rel -match '\.(cs|csproj)$'

    if (-not (Test-Path -LiteralPath $dst)) {
      $diffLines = @()
      if ($isCode) { $diffLines = Get-AllLinesAsDiff -path $src -mode add }
      Copy-Item -LiteralPath $src -Destination $dst -Force
      $added++
      $changeLog.Add("A  $rel") | Out-Null
      if ($isCode) {
        $fileDiffs.Add([pscustomobject]@{ Kind = "A"; Path = $rel; Lines = $diffLines }) | Out-Null
      }
    } else {
      $srcHash = Get-FileHashFast $src
      $dstHash = Get-FileHashFast $dst
      if ($srcHash -ne $dstHash) {
        $diffLines = @()
        if ($isCode) {
          $diffLines = Get-UnifiedDiffLines -oldPath $dst -newPath $src
        }
        Copy-Item -LiteralPath $src -Destination $dst -Force
        $updated++
        $changeLog.Add("M  $rel") | Out-Null
        if ($isCode) {
          $fileDiffs.Add([pscustomobject]@{ Kind = "M"; Path = $rel; Lines = $diffLines }) | Out-Null
        }
      } else {
        $unchanged++
      }
    }
  }
  Write-Host ""

  Write-Step "removing obsolete dump files..."
  Get-ChildItem -LiteralPath $DestRoot -Force | ForEach-Object {
    if ($KeepNames.Contains($_.Name)) { return }

    if ($_.PSIsContainer) {
      $asmName = $_.Name
      $asmStage = Join-Path $StageRoot $asmName
      if (-not (Test-Path -LiteralPath $asmStage)) {
        Get-ChildItem -LiteralPath $_.FullName -Recurse -File -Force -ErrorAction SilentlyContinue | ForEach-Object {
          $rel = $_.FullName.Substring($DestRoot.Length).TrimStart("\", "/")
          $isCode = $rel -match '\.(cs|csproj)$'
          if ($isCode) {
            $diffLines = Get-AllLinesAsDiff -path $_.FullName -mode del
            $fileDiffs.Add([pscustomobject]@{ Kind = "D"; Path = $rel; Lines = $diffLines }) | Out-Null
          }
          $changeLog.Add("D  $rel") | Out-Null
          $removed++
        }
        Remove-Item -LiteralPath $_.FullName -Recurse -Force -ErrorAction SilentlyContinue
        return
      }

      Get-ChildItem -LiteralPath $_.FullName -Recurse -File -Force -ErrorAction SilentlyContinue | ForEach-Object {
        $rel = $_.FullName.Substring($DestRoot.Length).TrimStart("\", "/")
        if (-not $stageFiles.ContainsKey($rel)) {
          $isCode = $rel -match '\.(cs|csproj)$'
          if ($isCode) {
            $diffLines = Get-AllLinesAsDiff -path $_.FullName -mode del
            $fileDiffs.Add([pscustomobject]@{ Kind = "D"; Path = $rel; Lines = $diffLines }) | Out-Null
          }
          Remove-Item -LiteralPath $_.FullName -Force -ErrorAction SilentlyContinue
          $changeLog.Add("D  $rel") | Out-Null
          $removed++
        }
      }

      Get-ChildItem -LiteralPath $_.FullName -Recurse -Directory -Force -ErrorAction SilentlyContinue |
        Sort-Object { $_.FullName.Length } -Descending |
        ForEach-Object {
          if (-not (Get-ChildItem -LiteralPath $_.FullName -Force -ErrorAction SilentlyContinue)) {
            Remove-Item -LiteralPath $_.FullName -Force -ErrorAction SilentlyContinue
          }
        }
    } else {
      $rel = $_.Name
      if (-not $stageFiles.ContainsKey($rel)) {
        Remove-Item -LiteralPath $_.FullName -Force -ErrorAction SilentlyContinue
        $changeLog.Add("D  $rel") | Out-Null
        $removed++
      }
    }
  }

  # Leading comma keeps PowerShell from unrolling the result object
  return ,([pscustomobject]@{
    Added = $added
    Updated = $updated
    Unchanged = $unchanged
    Removed = $removed
    ChangeLog = $changeLog.ToArray()
    FileDiffs = $fileDiffs.ToArray()
  })
}

# --- main -------------------------------------------------------------------
Set-Theme
Write-Banner

$ilspy = Resolve-IlSpyCmd
$buildId = Get-SteamBuildId
$acsDll = Join-Path $ManagedPath "Assembly-CSharp.dll"

Write-Host "  out      : $OutRoot" -ForegroundColor DarkGray
Write-Host "  managed  : $ManagedPath" -ForegroundColor DarkGray
Write-Host "  buildid  : $buildId" -ForegroundColor DarkGray
Write-Host "  mode     : sync (only swap changed code)" -ForegroundColor DarkGray
Write-Host "  ilspycmd : $(if ($ilspy) { $ilspy } else { 'MISSING' })" -ForegroundColor DarkGray
Write-Host ""

if (-not (Test-Path $ManagedPath)) {
  Write-ErrLine "Managed folder not found. Is Gorilla Tag installed?"
  Write-Host ""
  Read-Host "  Press Enter to close"
  exit 1
}
if (-not $ilspy) {
  Write-ErrLine "ilspycmd not found. Install with:"
  Write-Host "    dotnet tool install -g ilspycmd" -ForegroundColor Yellow
  Write-Host ""
  Read-Host "  Press Enter to close"
  exit 1
}
if (-not (Test-Path $acsDll)) {
  Write-ErrLine "Assembly-CSharp.dll missing in Managed."
  Write-Host ""
  Read-Host "  Press Enter to close"
  exit 1
}

$acsInfo = Get-Item $acsDll
Write-Host ("  Assembly-CSharp.dll  {0:N0} bytes   {1}" -f $acsInfo.Length, $acsInfo.LastWriteTime) -ForegroundColor DarkGray
Write-Host ""

if (-not $SkipConfirm) {
  Write-WarnLine "Fresh decompile goes to a temp folder first."
  Write-WarnLine "Then only ADD / UPDATE / REMOVE files that differ."
  Write-WarnLine "Unchanged code is left alone. .git and scripts stay."
  Write-Host ""
  $ans = Read-Host "  Type YES to continue"
  if ($ans -ne "YES") {
    Write-Host "  cancelled." -ForegroundColor DarkGray
    exit 0
  }
  Write-Host ""
}

$dlls = Get-ChildItem -LiteralPath $ManagedPath -Filter "*.dll" |
  Where-Object { -not $SkipAssemblies.Contains($_.BaseName) } |
  Sort-Object Name

$stage = Join-Path $env:TEMP ("gt-dump-stage-" + [guid]::NewGuid().ToString("N"))
New-Item -ItemType Directory -Path $stage -Force | Out-Null

Write-Step ("decompiling $($dlls.Count) assemblies to staging...")
Write-Host ""

$ok = 0
$fail = 0
$failures = New-Object System.Collections.Generic.List[string]
$i = 0
$sw = [System.Diagnostics.Stopwatch]::StartNew()

try {
  foreach ($dll in $dlls) {
    $i++
    $name = $dll.BaseName
    Write-Bar $i $dlls.Count $name
    $dest = Join-Path $stage $name
    New-Item -ItemType Directory -Path $dest -Force | Out-Null
    $prevEap = $ErrorActionPreference
    $ErrorActionPreference = "Continue"
    $null = & $ilspy $dll.FullName -p -o $dest 2>&1
    $code = $LASTEXITCODE
    $ErrorActionPreference = $prevEap
    if ($code -eq 0) {
      $ok++
    } else {
      $fail++
      $failures.Add($name) | Out-Null
      Remove-Item -LiteralPath $dest -Recurse -Force -ErrorAction SilentlyContinue
    }
  }
  Write-Host ""
  Write-Host ""

  Write-Step "comparing + swapping changed code only..."
  $sync = Sync-DumpTree -StageRoot $stage -DestRoot $OutRoot -KeepNames $KeepNames

  Write-Host ""
  Write-Step "preview (red=removed, green=added) - full report opens in browser"
  $diffCount = Get-CollectionCount $sync.FileDiffs
  $preview = @($sync.FileDiffs | Select-Object -First 12)
  foreach ($fd in $preview) {
    Write-ConsoleDiff -Rel $fd.Path -Kind $fd.Kind -DiffLines $fd.Lines
  }
  if ($diffCount -gt 12) {
    Write-Host ""
    Write-Host ("  ... +{0} more files in DUMP_CHANGES.html" -f ($diffCount - 12)) -ForegroundColor DarkGray
  }
}
finally {
  if (Test-Path -LiteralPath $stage) {
    Remove-Item -LiteralPath $stage -Recurse -Force -ErrorAction SilentlyContinue
  }
}

$sw.Stop()
Write-Host ""
Write-Step "done"
Write-Ok ("decompile ok=$ok  fail=$fail")
Write-Ok ("added=$($sync.Added)  updated=$($sync.Updated)  removed=$($sync.Removed)  unchanged=$($sync.Unchanged)")
Write-Ok ("elapsed=$([math]::Round($sw.Elapsed.TotalSeconds,1))s  buildid=$buildId")

if ($failures.Count -gt 0) {
  Write-Host ""
  Write-WarnLine "failed assemblies (skipped):"
  foreach ($f in $failures) {
    Write-Host ("    - " + $f) -ForegroundColor Yellow
  }
}

$stamp = @(
  "buildid=$buildId"
  ("dumped_utc=" + [DateTime]::UtcNow.ToString("o"))
  "mode=sync"
  "assemblies_ok=$ok"
  "assemblies_fail=$fail"
  "files_added=$($sync.Added)"
  "files_updated=$($sync.Updated)"
  "files_removed=$($sync.Removed)"
  "files_unchanged=$($sync.Unchanged)"
  "source=$ManagedPath"
) -join "`r`n"
Set-Content -LiteralPath (Join-Path $OutRoot "DUMP_STAMP.txt") -Value $stamp -Encoding UTF8

$logPath = Join-Path $OutRoot "DUMP_CHANGES.txt"
$logBody = New-Object System.Collections.Generic.List[string]
[void]$logBody.Add("GT dump sync  buildid=$buildId  $([DateTime]::UtcNow.ToString('o'))")
[void]$logBody.Add("A=added  M=modified  D=deleted   (open DUMP_CHANGES.html for red/green diffs)")
[void]$logBody.Add("")
foreach ($entry in @($sync.ChangeLog)) {
  [void]$logBody.Add([string]$entry)
}
Set-Content -LiteralPath $logPath -Value $logBody.ToArray() -Encoding UTF8

$htmlPath = Join-Path $OutRoot "DUMP_CHANGES.html"
New-DumpChangesHtml -Path $htmlPath -BuildId $buildId -Stats ([pscustomobject]@{
  Added = $sync.Added
  Updated = $sync.Updated
  Removed = $sync.Removed
  Unchanged = $sync.Unchanged
  DumpedUtc = [DateTime]::UtcNow.ToString("o")
}) -FileDiffs @($sync.FileDiffs)

Write-Ok "wrote DUMP_STAMP.txt + DUMP_CHANGES.txt + DUMP_CHANGES.html"
Write-Ok ("html diffs for {0} code files (red=removed, green=added)" -f (Get-CollectionCount $sync.FileDiffs))

try { Start-Process $htmlPath } catch {}

Write-Host ""
Write-Host "  ============================================================" -ForegroundColor DarkGreen
Write-Host "   red  = removed code" -ForegroundColor Red
Write-Host "   green = added code" -ForegroundColor Green
Write-Host "   opened DUMP_CHANGES.html" -ForegroundColor Cyan
Write-Host "  ============================================================" -ForegroundColor DarkGreen
Write-Host ""
Read-Host "  Press Enter to close"
