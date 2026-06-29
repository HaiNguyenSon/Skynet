# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this is

A personal Windows utility: a single-screen WinForms app that, on confirmation, launches a fixed set of local desktop apps the user wants open for work (Docker, Rider, Slack, Chrome, etc.). "Skynet / world domination" is just the theme — there is no networking or automation beyond starting processes.

## Build & run

Classic (non-SDK) .NET Framework 4.7.2 project — there is no `dotnet`-style SDK csproj, but `dotnet build` drives MSBuild here fine:

```sh
dotnet build Skynet/Skynet.csproj -v minimal      # or: msbuild Skynet/Skynet.csproj
```

Output: `Skynet/bin/Debug/Skynet.exe`. Run that exe to launch the app. There are **no tests, no linter, and no CI** — verification is build-clean + manual run.

`bin/` and `obj/` are gitignored; do not re-add build output to git.

## Code structure

Everything lives in `Skynet/Program.cs` — ~90 lines, two methods:

- `Main` builds a modal WinForms dialog with two checkboxes (VS Code, Waterfox) and Yes/No buttons. **Checkbox state must be read *after* `ShowDialog()` returns OK** — reading it before capture always yields the unchecked default (this was a past bug).
- `WorldDomination(Input)` starts each app. Every launch goes through the `TryStart` helper, which wraps `Process.Start` in try/catch and shows a `MessageBox` naming the failing path. This isolation is intentional: one missing/wrong path must not abort the rest of the sequence. The first process started is `jira-mcp.exe`.

## Conventions specific to this repo

- App paths are **hardcoded absolute Windows paths**, several user-specific (`C:\Users\hai.nguyen\...`) and version-pinned (e.g. `JetBrains Rider 2022.3.2`). Adding/removing an app = adding/removing a `TryStart(...)` line. Expect these to break when apps update; `TryStart` surfaces that at runtime rather than failing the build.
- The repo commits to `main` directly (solo project).
