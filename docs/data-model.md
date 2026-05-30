---
title: Data Model
nav_order: 5
---

# Data Model

microCMDB models a home network as a set of **entities** connected by **mapping**
(join) types. The full entity-relationship diagram is available as a
[PDF]({{ '/uCMDB ERD.pdf' | relative_url }}).

## Entities

| Entity | Tag prefix | Key fields |
|--------|-----------|------------|
| **ConfigItem** | `CFG` | Name, Description, PurchaseDate, DeployLoc |
| **Node** | `NOD` | Name, Modelname, OS_Version, CPU_Arch, RAM, Storage |
| **Host** | `HST` | Name, IPaddr |
| **Service** | `SVC` | Name, PortNum |
| **Software** | `STW` | Name, Version, Developer, LicenseType |
| **NetworkUser** | — | Username, Email, Firstname, Lastname |
| **Publisher** | — | Name |
| **Developer** | — | Name |
| **Manufacturer** | — | Name |

Every entity also carries the common fields defined on the base `Entity` type:
`Id`, `DbTag`, `Name`, `Description`, `CreatedDate`, `ModifiedDate`.

## Relationships

The join types live in `microCMDB.CLI.Models.NavProps`:

| Mapping | Connects | Cardinality |
|---------|----------|-------------|
| **CINodeMapping** | ConfigItem ↔ Node | one-to-one |
| **NodeHostMapping** | Node ↔ Host | one-to-one |
| **HostServiceMapping** | Host ↔ Service | one-to-many |
| **SoftwareInstallation** | Node ↔ Software | many-to-many |
| **NetworkUserMapping** | Node ↔ NetworkUser | many-to-many |
| **SoftwarePublisherMapping** | Software ↔ Publisher | many-to-many |
| **SoftwareDeveloperMapping** | Software ↔ Developer | many-to-many |
| **HardwareManufacturerMapping** | Node ↔ Manufacturer | many-to-many |

Conceptually: a **ConfigItem** (a physical asset) realises a **Node** (a logical
machine), which is reachable as a **Host** (an address) exposing **Services**.
A Node runs **Software** and grants access to **NetworkUsers**. Software has
**Publishers**/**Developers**; hardware has **Manufacturers**.

## CSV export format

The `export` command writes one CSV file per collection to the working directory.
There is no header row — columns follow each type's `ExportObject()` ordering.

| File | Contents |
|------|----------|
| `cfgitems.csv` | ConfigItems |
| `nod.csv` | Nodes |
| `hst.csv` | Hosts |
| `svc.csv` | Services |
| `stw.csv` | Software |
| `nus.csv` | NetworkUsers |
| `cinmap.csv` | CINodeMappings |
| `ndhmap.csv` | NodeHostMappings |
| `hsvmap.csv` | HostServiceMappings |
| `sinmap.csv` | SoftwareInstallations |
| `nusmap.csv` | NetworkUserMappings |

For example, a ConfigItem row is:

```
DbTag,Name,Description,CreatedDate,ModifiedDate,PurchaseDate,DeployLoc
```

Column-by-column schemas for every type are checked into the repository under
[`docs/csv-schemas/`](https://github.com/Arawn-Davies/microcmdb/tree/main/docs/csv-schemas).

> **Heads-up:** the exporter currently *appends* to existing files and does not
> quote or escape values, so commas or newlines in free-text fields will corrupt
> a row. See **[Known Issues]({{ '/known-issues' | relative_url }})**.
