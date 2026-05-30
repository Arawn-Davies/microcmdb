---
title: Home
nav_order: 1
---

# microCMDB

A small **CMDB-style configuration manager** for home networks. It is useful for
complex home setups with client devices and assets of varying device classes —
giving you a single place to record hosts, nodes, installed software, services,
and the relationships between them.

microCMDB began as a Computer Science BSc (Hons) final-year project and ships as
a .NET solution made up of several front-ends over a shared data model.

## Components

| Project | Description |
|---------|-------------|
| **microCMDB.CLI** | An interactive console front-end — the primary way to explore and edit the CMDB. |
| **microCMDB.Web** | An ASP.NET Core web front-end backed by Entity Framework Core. |
| **microCMDB.OS** | A bare-metal variant of the CLI built on the Cosmos OS kernel. |
| **microCMDB.Test** | The test suite for the CLI and its components. |

## Where to go next

- **[Getting Started]({{ '/getting-started' | relative_url }})** — build and run the CLI on the host or in Docker.
- **[CLI Reference]({{ '/cli-reference' | relative_url }})** — every command the shell understands.
- **[Architecture]({{ '/architecture' | relative_url }})** — how the pieces fit together.
- **[Data Model]({{ '/data-model' | relative_url }})** — entities, mappings, and the CSV export/import format.
- **[Development]({{ '/development' | relative_url }})** — project layout, target frameworks, and testing.
- **[Known Issues]({{ '/known-issues' | relative_url }})** — current limitations and rough edges.

## Reference deliverables

The original project deliverables are published alongside this site:

- [System Report]({{ '/Final Deliverable - System Report.docx' | relative_url }})
- [Project Contract]({{ '/Project Contract.docx' | relative_url }})
- [Entity Relationship Diagram (PDF)]({{ '/uCMDB ERD.pdf' | relative_url }})
- Example screens: [Home]({{ '/uCMDB Home.pdf' | relative_url }}) ·
  [Host]({{ '/uCMDB Host example.pdf' | relative_url }}) ·
  [Node]({{ '/uCMDB Node example.pdf' | relative_url }})
