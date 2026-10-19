@echo off
title GT DUMP  //  managed -^> csharp
color 0A
cd /d "%~dp0"

:: custom console size if possible
mode con cols=80 lines=30 >nul 2>&1

echo.
echo   launching dump updater...
echo.

powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0Update-Dump.ps1"
if errorlevel 1 (
  color 0C
  echo.
  echo   dump failed.
  pause
)
