---
title: Architecture
nav_order: 4
---

# Architecture

microCMDB.CLI is a single-process console application. This page describes how it
is put together.

## Process flow

```
Program.Main
  └─ Shell.Prep()           # create the in-memory Db and seed example data
  └─ loop: Shell.CLI()      # read a line, dispatch a command, repeat
```

- `Program.Main` (`Program.cs`) sets the working directory, marks the session as
  *hosted*, and runs the shell loop until `Program.running` becomes false.
- `Shell.Prep` (`Util/Shell.cs`) constructs a `Db` and seeds it.
- `Shell.CLI` reads a line, splits it into a command and arguments, and
  dispatches through a `switch`. On EOF (`Ctrl-D` / end of piped input) it exits
  cleanly.

## The in-memory database

`Db` (`Db.cs`) is **not** a real database — it is a bag of `List<T>` collections
(one per entity and per mapping type) held in a single static instance:

```csharp
public static Db? CurrentDbContext { get; set; }
```

All reads and writes go through `Db.CurrentDbContext`. The naming mirrors Entity
Framework's `DbContext`, but there is no persistence: state lives only in memory
and is lost on exit unless you `export`.

## Self-registering entities

Entities do not need to be added to the database explicitly. Every model's
constructor registers the new instance into the current context. The base
`Entity` constructor assigns a `DbTag` and adds the instance to `Entities`; each
derived constructor also adds itself to its specific collection:

```csharp
public ConfigItem() : base()
{
    Db.CurrentDbContext.ConfigItems.Add(this);
}
```

This keeps seeding and creation terse, but it has consequences worth knowing —
see **[Known Issues]({{ '/known-issues' | relative_url }})** (e.g. a live
`Db.CurrentDbContext` must exist before any entity is constructed, and explicit
`Add` calls can double-register).

## Layers

| Namespace | Responsibility |
|-----------|----------------|
| `microCMDB.CLI` | Entry point (`Program`) and the `Db` context. |
| `microCMDB.CLI.Models` | Entity types (ConfigItem, Node, Host, Service, Software, NetworkUser, Publisher, Developer, Manufacturer). |
| `microCMDB.CLI.Models.NavProps` | Mapping/join types that express relationships. |
| `microCMDB.CLI.Util` | Command handlers and helpers: `Shell`, `Get`, `Set`, `New`, `IO`, `Help`, `Table`. |

## Output rendering

`Util/Table.cs` provides the fixed-width table primitives (`PrintLine`,
`PrintRow`) used to render entities. Each entity overrides `PrintInfo()` to lay
out its own fields.

## Import / export

`Util/IO.cs` handles CSV export (one file per collection) and import. Each entity
implements `ExportObject()` to produce its CSV row. See the
**[Data Model]({{ '/data-model' | relative_url }})** page for the on-disk format.

## Runtime targeting

The CLI targets `net6.0` for source compatibility with **microCMDB.OS**, which is
harder to move off .NET 6. Because no .NET 6 runtime is typically installed, the
project sets `<RollForward>Major</RollForward>` so it runs on .NET 8/9 on the
host. The Docker image instead uses the .NET 6 base images and runs natively.
