# GT Dump Updater

Small local tool that refreshes a Gorilla Tag C# dump from your Steam install.

After a game update, run it and only **changed** source is swapped in. Unchanged files are left alone.

## Requirements

- Windows
- [Gorilla Tag](https://store.steampowered.com/app/1533390) installed via Steam
- [.NET SDK](https://dotnet.microsoft.com/download) (for `ilspycmd`)

```bash
dotnet tool install -g ilspycmd
```

## Usage

1. Let Steam finish updating Gorilla Tag
2. Double-click **`DUMP.bat`**
3. Type **`YES`** when asked

The script will:

1. Decompile assemblies from  
   `Steam\steamapps\common\Gorilla Tag\Gorilla Tag_Data\Managed`
2. Compare against your local dump folder
3. Add / update / remove only what changed
4. Open **`DUMP_CHANGES.html`** with a red/green diff (GitHub-style)

## Files

| File | Purpose |
|------|---------|
| `DUMP.bat` | Launcher (green console) |
| `Update-Dump.ps1` | Decompile + sync logic |

## Notes

- Keep this repo for the **tooling only**. Put your dump output in a separate local folder (or clone/copy the scripts next to your dump).
- `.git`, the scripts, and stamp/report files are never deleted by the updater.
