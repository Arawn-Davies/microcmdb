---
title: CLI Reference
nav_order: 3
---

# CLI Reference

The CLI is a read–eval loop: it prints a `>` prompt, reads a line, and dispatches
on the first word (the command) and, where relevant, the second word (the
sub-command / entity type). Input is case-insensitive.

## Entity tags

Every entity has a unique **DbTag** — a three-letter type prefix plus a
zero-padded counter, e.g. `CFG0001`. Commands that act on a single entity
(`find`, `delete`, `set configitems`) accept a tag or tag prefix.

| Prefix | Entity |
|--------|--------|
| `CFG` | ConfigItem |
| `NOD` | Node |
| `HST` | Host |
| `SVC` | Service |
| `STW` | Software |

## Commands

### Session

| Command | Description |
|---------|-------------|
| `help [get\|set\|new]` | Show the command list, or detailed help for a verb. |
| `cls` / `clear` | Clear the screen. |
| `ver` | Print version, build number, and copyright. |
| `exit` | Quit the CLI. (EOF / `Ctrl-D` also exits cleanly.) |

### `get` — list entities

Lists all entities of a type.

| Command | Aliases |
|---------|---------|
| `get configitems` | `get c` |
| `get nodes` | `get n` |
| `get hosts` | `get h` |
| `get services` | `get svc` |
| `get software` | `get stw` |
| `get manufacturers` | `get man` |
| `get publishers` | `get pub` |
| `get developers` | `get devs` |

### `find` — show one entity

```
find <dbtag>
```

Prints the full detail for the entity whose tag starts with `<dbtag>`. A tag is
required — `find` with no argument is rejected.

### `new` — create entities

| Command | Aliases | Notes |
|---------|---------|-------|
| `new db` | | Discard the current database and start a fresh one. Prompts for confirmation. |
| `new configitem` | `new c` | Interactive prompts for each field. |
| `new node` | `new n` | |
| `new host` | `new h` | *Stub — not yet implemented.* |
| `new service` | `new svc` | *Stub — not yet implemented.* |
| `new software` | `new stw` | *Stub — not yet implemented.* |

### `set` — edit entities

| Command | Aliases | Notes |
|---------|---------|-------|
| `set configitems <dbtag>` | `set c <dbtag>` | A tag is required. Prompts for each field; blank input keeps the existing value. |
| `set nodes` | `set n` | *Stub.* |
| `set hosts` | `set h` | *Stub.* |
| `set services` | `set svc` | *Stub.* |
| `set software` | `set stw` | *Stub.* |

### `delete` — remove an entity

```
delete <dbtag>
```

Removes the entity with the matching tag from the database.

### `export` — write CSV

```
export
```

Writes each collection to a CSV file in the working directory. See the
**[Data Model]({{ '/data-model' | relative_url }})** page for file names and columns.

### `sys` — pass-through to the OS

```
sys <command>
```

Only available in **microCMDB.OS**; forwards the command to the underlying
Cosmos kernel. In the hosted CLI it prints a "not available" message.

## Date input

Fields that accept a date use `DD/MM/YYYY`. Invalid input re-prompts; a blank
entry defaults to the current date.
