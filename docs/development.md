---
title: Development
nav_order: 6
---

# Development

## Repository layout

```
microcmdb/
├── microCMDB.CLI/        # Interactive console front-end (primary)
│   ├── Program.cs        # Entry point
│   ├── Db.cs             # In-memory database + seed data
│   ├── Models/           # Entity types
│   │   └── NavProps/     # Mapping / join types
│   └── Util/             # Shell, Get, Set, New, IO, Help, Table
├── microCMDB.Web/        # ASP.NET Core + EF Core web front-end
├── microCMDB.OS/         # Cosmos-kernel bare-metal variant
├── microCMDB.Test/       # Test suite
├── docs/                 # This documentation site + deliverables
├── scripts/run-cli.sh    # Interactive launcher (host | docker)
└── microcmdb.sln
```

## Target frameworks

| Project | Target | Notes |
|---------|--------|-------|
| microCMDB.CLI | `net6.0` | Runs on .NET 8/9 via `RollForward`. |
| microCMDB.OS | `net6.0` | Cosmos kernel; pins the CLI to net6 for compatibility. |
| microCMDB.Web | `net7.0` | |
| microCMDB.Test | `net7.0` | |

The CLI is deliberately kept on `net6.0` because **microCMDB.OS** is much harder
to move forward; upgrading the CLI alone would break source sharing.

## Building

```bash
# Whole solution
dotnet build microcmdb.sln

# Just the CLI
dotnet build microCMDB.CLI/microCMDB.CLI.csproj
```

## Build metadata

`microCMDB.CLI/Util/BuildInfo.cs` is generated on each build by an MSBuild target
in the `.csproj`; it stamps a build number that the `ver` command prints.

## Testing

```bash
dotnet test microCMDB.Test/microCMDB.Test.csproj
```

The CLI's reliance on a single static `Db.CurrentDbContext` and self-registering
constructors makes isolated unit testing awkward — tests must set up a context
before constructing any model. This is called out under
**[Known Issues]({{ '/known-issues' | relative_url }})**.

## Coding notes

- Input is read with `Console.ReadLine()`, which returns `null` at EOF. Helpers
  guard against this so piped input and `Ctrl-D` exit cleanly rather than
  crashing or looping.
- Output uses the fixed-width helpers in `Util/Table.cs`; prefer them over raw
  `Console.WriteLine` for tabular data.

## Documentation site

This site is plain Markdown rendered by Jekyll (the
[just-the-docs](https://just-the-docs.com) theme) and published by GitHub Pages
from the `/docs` folder. To preview locally:

```bash
cd docs
bundle install      # first time only; needs the github-pages gem
bundle exec jekyll serve --baseurl ""
```

Then open <http://localhost:4000>. Add new pages as Markdown files with
`title` and `nav_order` front matter; they appear in the sidebar automatically.
