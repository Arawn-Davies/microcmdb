using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using microcmdb.Web.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Internal;
using System.Reflection.Emit;
using Newtonsoft.Json.Serialization;

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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {   }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Define primary keys

            modelBuilder.Entity<ConfigItem>()
                .HasKey(c => c.ConfigItemID);

            modelBuilder.Entity<Node>()
                .HasKey(n => n.NodeID);

            modelBuilder.Entity<Models.Host>()
                .HasKey(h => h.HostID);

            modelBuilder.Entity<Service>()
                .HasKey(svc => svc.ServiceID);

            modelBuilder.Entity<Software>()
                .HasKey(sw => sw.SoftwareID);

            modelBuilder.Entity<NetworkUser>()
                .HasKey(nu => nu.NetworkUserID);

            modelBuilder.Entity<CINodeMapping>()
                .HasKey(c => new { c.ConfigItemID, c.NodeID });

            modelBuilder.Entity<NodeHostMapping>()
                .HasKey(nh => new { nh.NodeID, nh.HostID });

            modelBuilder.Entity<NetworkUserMapping>()
                .HasKey(nu => new { nu.NodeID, nu.NetworkUserID });

            modelBuilder.Entity<SoftwareInstallation>()
                .HasKey(si => new { si.NodeID, si.SoftwareID });

            modelBuilder.Entity<HostServiceMapping>()
                .HasKey(hs => new { hs.HostID, hs.ServiceID });

            #endregion

            // Set Id properties to auto-increment

            #region Set Id properties to auto-increment

            modelBuilder.Entity<ConfigItem>()
                .Property(c => c.ConfigItemID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Node>()
                .Property(n => n.NodeID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Models.Host>()
                .Property(h => h.HostID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Software>()
                .Property(sw => sw.SoftwareID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Service>()
                .Property(svc => svc.ServiceID)
                .ValueGeneratedOnAdd();
            #endregion


            #region Define relationships and foreign keys

            // ConfigItem entity
            modelBuilder.Entity<ConfigItem>()
                .HasOne(c => c.Node)
                .WithOne(c => c.ConfigItem)
                .OnDelete(DeleteBehavior.SetNull);

            // Node entity has one Node to one ConfigItem
            modelBuilder.Entity<Node>()
                .HasOne(n => n.ConfigItem)
                .WithOne(n => n.Node)
                .HasForeignKey<Node>(n => n.ConfigItemID)
                .OnDelete(DeleteBehavior.SetNull);

            // Host has a one-to-one relationship with Node
            modelBuilder.Entity<Node>()
                .HasOne(n => n.Host)
                .WithOne(n => n.Node)
                .OnDelete(DeleteBehavior.SetNull);

            // Define the relationship between Host and Node
            modelBuilder.Entity<Models.Host>()
                .HasOne(h => h.Node)
                .WithOne(n => n.Host)
                .HasForeignKey<Models.Host>(h => h.NodeId) // Assuming the foreign key property name is "NodeId"
                .IsRequired(true) // Assuming a host must belong to a node
                .OnDelete(DeleteBehavior.Cascade); // Depending on your requirements


            // Host has a one-to-many relationship with Services
            modelBuilder.Entity<Models.Host>()
                .HasMany(h => h.Services)
                .WithOne(svc => svc.Host)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NetworkUserMapping>()
                .HasOne(nu => nu.Node)
                .WithMany(n => n.NetworkUsers)
                .HasForeignKey(nu => nu.NodeID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<NetworkUserMapping>()
                .HasOne(nu => nu.NetworkUser)
                .WithMany(u => u.AllowedNodes)
                .HasForeignKey(nu => nu.NetworkUserID)
                .OnDelete(DeleteBehavior.SetNull);

            // Software has a one-to-many relationship with SoftwareInstallation
            modelBuilder.Entity<Software>()
                .HasMany(sw => sw.Installations)
                .WithOne(si => si.Software)
                .OnDelete(DeleteBehavior.Cascade);


            #endregion
        }

        public void SeedData()
        {
            if (!ConfigItems.Any())
            {
                // Create ConfigItems
                var cA500 = new ConfigItem { Name = "Amiga 500", PurchaseDate = DateTime.Now, DeployLoc = "Office" };
                var cA6128 = new ConfigItem { Name = "Amstrad CPC 6128", PurchaseDate = DateTime.Now, DeployLoc = "Office" };
                var cNAS = new ConfigItem { Name = "16TB Intel Atom NAS", PurchaseDate = DateTime.Now, DeployLoc = "Datacenter" };

                // Add ConfigItems to context
                ConfigItems.AddRange(cA500, cA6128, cNAS);
                SaveChanges();

                // Create Nodes
                var nA500 = new Node { Name = "Amiga 500", OS_Version = "AmigaOS", CPU_Arch = "Motorola 68000", RAM = 1, Storage = 20, ConfigItem = cA500 };
                var nA6128 = new Node { Name = "Amstrad CPC 6128", OS_Version = "Amstrad CP/M", CPU_Arch = "Zilog Z80", RAM = 0.5, Storage = 3, ConfigItem = cA6128 };
                var nNAS = new Node { Name = "16TB Intel Atom NAS", OS_Version = "Custom NAS OS", CPU_Arch = "Intel Atom", RAM = 16, Storage = 16000, ConfigItem = cNAS };

                // Add Nodes to context
                Nodes.AddRange(nA500, nA6128, nNAS);
                SaveChanges();

                var hNAS = new Models.Host { Name = "NAS Host", Node = nNAS};
                Hosts.Add(hNAS);

                // Create Relationships
                var networkUser = new NetworkUser { Username = "JohnDoe", Email = "john@example.com" };
                NetworkUsers.Add(networkUser);

                var software = new Software { Name = "Example Software", Version = "1.0" };
                Software.Add(software);

                var service = new Service { Protocol = "HTTP", URL = "http://" + hNAS.Node.IPaddr + "/", PortNum = 80, Host = hNAS };
                Services.Add(service);

                var networkUserMapping = new NetworkUserMapping { Node = nNAS, NetworkUser = networkUser };
                UserMappings.Add(networkUserMapping);

                

                var softwareInstallation = new SoftwareInstallation { Node = nA500, Software = software };
                nA500.InstalledSoftware.Add(softwareInstallation);
                SoftwareInstallations.Add(softwareInstallation);

                var hostServiceMapping = new HostServiceMapping { Host = hNAS, Service = service };
                HostServiceMappings.Add(hostServiceMapping);
                
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
