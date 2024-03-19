using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using microcmdb.Web.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Internal;
using System.Reflection.Emit;

namespace microcmdb.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ConfigItem> ConfigItems { get; set; }
        public DbSet<NetworkUser> NetworkUsers { get; set; }
        public DbSet<Models.Host> Hosts { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Software> Software { get; set; }
        public DbSet<CINodeMapping> CINodeMappings { get; set; }
        public DbSet<HostServiceMapping> HostServiceMappings { get; set; }
        public DbSet<NodeHostMapping> NodeHostMappings { get; set; }
        public DbSet<NetworkUserMapping> UserMappings { get; set; }
        public DbSet<SoftwareInstallation> SoftwareInstallations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
               
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ConfigItem>()
                .HasKey(c => c.ConfigItemID);


            modelBuilder.Entity<CINodeMapping>()
                .HasKey(c => c.CINodeMappingID);

            modelBuilder.Entity<CINodeMapping>()
                .HasOne(c => c.ConfigItem)
                .WithOne(ci => ci.CINodeMapping)
                .HasForeignKey<CINodeMapping>(c => c.ConfigItemID);

            modelBuilder.Entity<CINodeMapping>()
                .HasOne(c => c.Node)
                .WithOne(n => n.CINodeMapping)
                .HasForeignKey<CINodeMapping>(c => c.NodeID);

            modelBuilder.Entity<NodeHostMapping>()
                .HasKey(nh => nh.NodeHostMappingID);

            modelBuilder.Entity<NodeHostMapping>()
                .HasOne(nh => nh.Node)
                .WithOne(n => n.AssocHost)
                .HasForeignKey<NodeHostMapping>(nh => nh.NodeID);

            modelBuilder.Entity<NodeHostMapping>()
                .HasOne(nh => nh.Host)
                .WithOne(h => h.NodeHostMapping)
                .HasForeignKey<NodeHostMapping>(nh => nh.HostID);

            modelBuilder.Entity<NetworkUserMapping>()
                .HasKey(nu => new { nu.NodeID, nu.NetworkUserID });

            modelBuilder.Entity<SoftwareInstallation>()
                .HasKey(si => new { si.NodeID, si.SoftwareID });

            modelBuilder.Entity<HostServiceMapping>()
                .HasKey(hs => new { hs.HostID, hs.ServiceID });

            

            /*
             * Initial relationships and tables
             * 
             *
            builder.Entity<ConfigItem>().ToTable("ConfigItem");
            builder.Entity<NetworkUser>().ToTable("NetworkUser");
            builder.Entity<Models.Host>().ToTable("Host");
            builder.Entity<Node>().ToTable("Node");
            builder.Entity<Service>().ToTable("Service");
            builder.Entity<Software>().ToTable("Software");
            builder.Entity<CINodeMapping>().ToTable("CINodeMapping");
            builder.Entity<CINodeMapping>().HasKey(c => c.CINodeMappingID);
            builder.Entity<NodeHostMapping>().ToTable("NodeHostMapping");
            builder.Entity<NodeHostMapping>().HasKey(c => c.NodeHostMappingID);
            builder.Entity<HostServiceMapping>().ToTable("HostServiceMapping");
            builder.Entity<HostServiceMapping>().HasKey(c => c.HostServiceMappingID);
            builder.Entity<NetworkUserMapping>().ToTable("NetworkUserMapping");
            builder.Entity<NetworkUserMapping>().HasKey(c => c.NetworkUserID);
            builder.Entity<SoftwareInstallation>().ToTable("SoftwareInstallation");
            builder.Entity<SoftwareInstallation>().HasKey(c => c.SoftwareInstallationID);
            initialSeed(this);
            */

        }

        public void SeedData()
        {
            if (!ConfigItems.Any())
            {
                // Create ConfigItems
                var amiga500 = new ConfigItem { Name = "Amiga 500", PurchaseDate = DateTime.Now, DeployLoc = "Office" };
                var amstradCPC6128 = new ConfigItem { Name = "Amstrad CPC 6128", PurchaseDate = DateTime.Now, DeployLoc = "Office" };
                var intelAtomNAS = new ConfigItem { Name = "16TB Intel Atom NAS", PurchaseDate = DateTime.Now, DeployLoc = "Datacenter" };

                // Add ConfigItems to context
                ConfigItems.AddRange(amiga500, amstradCPC6128, intelAtomNAS);
                SaveChanges();

                // Create Nodes
                var nodeAmiga500 = new Node { Name = "Amiga 500", OS_Version = "AmigaOS", CPU_Arch = "Motorola 68000", RAM = 1, Storage = 20, CINodeMapping = new CINodeMapping { ConfigItem = amiga500 } };
                var nodeAmstradCPC6128 = new Node { Name = "Amstrad CPC 6128", OS_Version = "Amstrad CP/M", CPU_Arch = "Zilog Z80", RAM = 0.5, Storage = 3, CINodeMapping = new CINodeMapping { ConfigItem = amstradCPC6128 } };
                var nodeIntelAtomNAS = new Node { Name = "16TB Intel Atom NAS", OS_Version = "Custom NAS OS", CPU_Arch = "Intel Atom", RAM = 16, Storage = 16000, CINodeMapping = new CINodeMapping { ConfigItem = intelAtomNAS } };

                // Add Nodes to context
                Nodes.AddRange(nodeAmiga500, nodeAmstradCPC6128, nodeIntelAtomNAS);
                SaveChanges();

                // Create Relationships
                var networkUser = new NetworkUser { Username = "JohnDoe", Email = "john@example.com" };
                var networkUserMapping = new NetworkUserMapping { Node = nodeAmiga500, NetworkUser = networkUser };

                var software = new Software { Name = "Example Software", Version = "1.0" };
                var softwareInstallation = new SoftwareInstallation { Node = nodeIntelAtomNAS, Software = software };

                var service = new Service { Protocol = "HTTP", URL = "http://example.com", PortNum = 80 };
                var hostServiceMapping = new HostServiceMapping { Host = new Models.Host { Name = "Example Host" }, Service = service };

                NetworkUsers.Add(networkUser);
                Software.Add(software);
                Services.Add(service);
                Hosts.Add(hostServiceMapping.Host);
                SaveChanges();
            }
        }

        private void initialSeed(ApplicationDbContext context)
        { 
            //Database.EnsureCreated();
            ConfigItem[] initialCIs = new ConfigItem[]
            {
                new ConfigItem { Name = "SQUIDBEAST", DeployLoc = "Home Office", PurchaseDate = new DateTime(2022, 07, 15), LastUpdated = DateTime.Now, Notes = "Main Workstation"},
                new ConfigItem { Name = "A500_030", DeployLoc = "Garage", PurchaseDate = new DateTime(2019, 04, 27), LastUpdated=new DateTime(2021, 10, 31), Notes = "Amiga 500 Rev 5A with TF534 expansion" },
                new ConfigItem { Name = "Pi400", DeployLoc = "Games Room", PurchaseDate = new DateTime(2020, 11, 2), LastUpdated=DateTime.Now, Notes = "Raspberry Pi 400" },
                new ConfigItem { Name = "CPC6128", DeployLoc = "Loft", PurchaseDate = new DateTime(1985, 06, 12), LastUpdated=new DateTime(2021, 12, 25), Notes = "Amstrad CPC 6128 with FlashFloppy drive emulator" },
                new ConfigItem { Name = "C64", DeployLoc = "Loft", PurchaseDate = new DateTime(1983, 08, 01), LastUpdated=new DateTime(2021, 12, 25), Notes = "Commodore 64 with SD2IEC" },
            };

            ConfigItem cHomeNAS = new ConfigItem { Name = "SQUIDNAS", DeployLoc = "Home Office", PurchaseDate = new DateTime(2022, 08, 17), LastUpdated = DateTime.Now, Notes = "NAS server" };
            
            Node[] initialNodes = new Node[]
            {
                new Node { Name = "SQUIDBEAST", OS_Version = "Windows 11 23H2", CPU_Arch = "x86_64", RAM = 32768, Storage = 6144, IPaddr = "192.168.2.50" },
                new Node { Name = "A500_030", OS_Version = "AmigaOS 3.1.4", CPU_Arch = "MC68030", RAM = 6, Storage = 4, IPaddr = "192.168.2.75" },
                new Node { Name = "Pi400", OS_Version = "Raspberry Pi OS Buster", CPU_Arch = "ARM64", RAM = 4096, Storage = 32, IPaddr = "192.168.2.30" },
                new Node { Name = "CPC6128", OS_Version = "Amstrad CP/M 2.2", CPU_Arch = "Zilog Z80", RAM = 0.128, Storage = 0, IPaddr = "N/A" },
                new Node { Name = "C64", OS_Version = "Commodore BASIC 2.0", CPU_Arch = "MOS 8500", RAM = 0.064, Storage = 0, IPaddr = "N/A" },
            };

            Node nHomeNAS = new Node { Name = "SQUIDNAS", OS_Version = "Synology DSM 5.6.13-1", CPU_Arch = "x86_32", RAM = 2048, Storage = 16384, IPaddr = "192.168.2.150" };
            

            CINodeMapping[] initialCINMaps = new CINodeMapping[]
            {
                new CINodeMapping { ConfigItemID = 1, ConfigItem = initialCIs.First(), NodeID = 1, Node = initialNodes.First()},
                new CINodeMapping { ConfigItemID = 2, ConfigItem = initialCIs[1], NodeID = 2, Node = initialNodes[1]},
                new CINodeMapping { ConfigItemID = 3, ConfigItem = initialCIs[2], NodeID = 3, Node = initialNodes[2]},
                new CINodeMapping { ConfigItemID = 4, ConfigItem = initialCIs[3], NodeID = 4, Node = initialNodes[3]},
                new CINodeMapping { ConfigItemID = 5, ConfigItem = initialCIs[4], NodeID = 5, Node = initialNodes[4]},
            };

            CINodeMapping cHomeNASMap = new CINodeMapping { ConfigItemID = 6, ConfigItem = cHomeNAS, NodeID = 6, Node = nHomeNAS };

            ConfigItems.AddRange(initialCIs);
            ConfigItems.Add(cHomeNAS);
            Nodes.AddRange(initialNodes);
            Nodes.Add(nHomeNAS);
            CINodeMappings.AddRange(initialCINMaps);
            CINodeMappings.Add(cHomeNASMap);
            SaveChanges();

            
        }
    }
}
