---
title: Getting Started
nav_order: 2
---

# Getting Started

This guide covers building and running **microCMDB.CLI** — the interactive
console front-end.

## Prerequisites

- **.NET SDK** — the CLI *targets* `net6.0`. You do **not** need the .NET 6
  runtime installed: the project sets `<RollForward>Major</RollForward>`, so it
  runs on a newer installed runtime (.NET 8 or 9). Building requires a .NET SDK
  (8.0 or 9.0 is fine).
- **Docker** *(optional)* — for the containerised run, which uses the .NET 6
  base image and therefore needs no roll-forward.

## Build

```bash
dotnet build microCMDB.CLI/microCMDB.CLI.csproj
```

The build emits nullable-reference warnings; these are non-fatal. A successful
build reports `0 Error(s)`.

## Run on the host

```bash
dotnet run --project microCMDB.CLI
```

On start, the CLI creates an in-memory database, seeds it with example data, and
drops you at a `>` prompt:

```
Creating collections...
Collections created.
Creating a new database...

>
```

Type `help` to list commands, or see the **[CLI Reference]({{ '/cli-reference' | relative_url }})**.
Type `exit` (or send EOF with `Ctrl-D`) to quit.

### Launcher script

For an interactive session in its own terminal window that closes itself when
the CLI exits, use the helper script:

```bash
scripts/run-cli.sh host     # dotnet run on the host (default)
scripts/run-cli.sh docker   # interactive run inside the container
```

## Run in Docker

The CLI ships with a Dockerfile that builds on the .NET 6 images, so it runs
natively without roll-forward.

```bash
# Build the image
docker build -t microcmdb-cli -f microCMDB.CLI/Dockerfile microCMDB.CLI

# Run interactively
docker run -it --rm microcmdb-cli dotnet microCMDB.CLI.dll
```

> **Note:** the Dockerfile's default `CMD` starts an SSH daemon (for remote
> debugging from Visual Studio), *not* the CLI. The app is published with
> `UseAppHost=false`, so the interactive command above launches it explicitly
> via `dotnet microCMDB.CLI.dll`.

## Persisting data

The database is in-memory and is lost when the process exits. Use the `export`
command to write the current contents to CSV files in the working directory.
See the **[Data Model]({{ '/data-model' | relative_url }})** page for the CSV format.
