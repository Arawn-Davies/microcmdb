---
title: Known Issues
nav_order: 7
---

# Known Issues

A candid list of current limitations and rough edges in **microCMDB.CLI**, to set
expectations and guide contributors.

## Recently fixed

These crash/hang paths have been addressed:

- **Empty / EOF input no longer crashes.** `GetYesNo` and the date parser guard
  against `null` from `Console.ReadLine()`, so `Ctrl-D` and end-of-pipe no longer
  throw `NullReferenceException` or loop forever.
- **The main shell loop exits on EOF** instead of spinning, printing
  "Invalid command" indefinitely.
- **`set c` / `set configitems` with no tag** prints a usage message instead of
  throwing `IndexOutOfRangeException`.
- **`find` with no tag** is rejected instead of dumping the entire database
  (an empty prefix matched everything).

## Open issues

### Correctness

- **`new configitem` double-adds.** The object initializer self-registers in the
  constructor *and* the handler calls `Add` again, so the item appears twice.
- **`new db` does not reset IDs.** The per-type counter is `static` and survives
  context replacement, so tags continue from where they left off
  (`CFG0006`, …) rather than restarting at `CFG0001`.
- **Seed data contains duplicate SoftwareInstallations.**
- **`new host` / `new service` / `new software` are stubs** that only print a
  message. Several `set …` verbs are likewise stubs.
- **`Import()` is broken** — it splits the *file path* rather than the file
  contents, so nothing is actually read, and it is not wired to a command.
- **`export` appends** to existing CSVs (duplicating rows on repeat) and does not
  quote/escape values, so commas or newlines in free-text fields corrupt a row.
- **`delete` leaves orphaned mappings** — related join records are not removed.

### Design

- **Persistence via constructor side-effect.** Entities add themselves to a
  global static `Db.CurrentDbContext`; constructing one without a live context
  throws, and explicit `Add` calls can double-register.
- **Pervasive static mutable state** (the context, the ID counter, reused fields
  in `Set`) makes behaviour order-dependent and hard to unit-test.
- **`Db` is in-memory only** — there is no persistence layer; state is lost on
  exit unless exported. Meanwhile **microCMDB.Web** maintains a parallel,
  EF-Core-backed copy of the same models.
- **Large boilerplate duplication** across the `Get`, `Export`, and command-
  dispatch code that a registry or generics could collapse.

### Cosmetic

- In `get hosts`, the `Services:` line is not newline-terminated, so the next
  table separator runs into it.

See the [GitHub repository](https://github.com/Arawn-Davies/microcmdb) to file or
track issues.
