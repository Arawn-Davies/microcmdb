using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using microcmdb.common.Models;

namespace microcmdb.common
{
    internal class Db
    {
        public static Db CurrentDbContext;

        public ICollection<ConfigItem> ConfigItems { get; set; }
        
        public ICollection<Node> Nodes { get; set; }

        public ICollection<Host> Hosts { get; set; }

        public ICollection<Service> Services { get; set; }

        public ICollection<Software> Software { get; set; }

        public ICollection<NetworkUser> NetworkUsers{ get; set; }

        public ICollection<CINodeMapping> CINodeMappings { get; set; }

        public ICollection<NodeHostMapping> NodeHostMappings { get; set; }    

        public ICollection<HostServiceMapping> HostServiceMappings { get; set; }

        public ICollection<SoftwareInstallation> SoftwareInstallations { get; set;}

        public ICollection<NetworkUserMapping> NetworkUserMappings { get; set; }

        public Db()
        {
            ConfigItems = new List<ConfigItem>();
            Nodes = new List<Node>();
            Hosts = new List<Host>();
            Services = new List<Service>();
            Software = new List<Software>();
            NetworkUsers = new List<NetworkUser>();
            CINodeMappings = new List<CINodeMapping>();
            NodeHostMappings = new List<NodeHostMapping>();
            HostServiceMappings = new List<HostServiceMapping>();
            SoftwareInstallations = new List<SoftwareInstallation>();
            NetworkUserMappings = new List<NetworkUserMapping>();
        }

        public void SeedDatabase()
        {
            if (!ConfigItems.Any())
            {
                // Example date
                DateTime example = new DateTime(2018, 4, 27);
                DateTime LastYear = DateTime.Now.AddYears(-1);
                DateTime TenYearsAgo = DateTime.Now.AddYears(-10);

                // Create ConfigItems
                var cA500 = new ConfigItem { Name = "Amiga 500", PurchaseDate = example, DeployLoc = "Home" };
                var cA6128 = new ConfigItem { Name = "Amstrad CPC 6128", PurchaseDate = DateTime.Now, DeployLoc = "Home" };
                var cNAS1 = new ConfigItem { Name = "16TB Intel Atom NAS", PurchaseDate = TenYearsAgo, DeployLoc = "Garage" };
                var cNAS2 = new ConfigItem { Name = "Ubuntu Server NAS", PurchaseDate = DateTime.Now, DeployLoc = "Office" };
                var cRPI = new ConfigItem { Name = "Raspberry Pi 4", PurchaseDate = LastYear, DeployLoc = "Home" };

                

                // Create Nodes
                var nA500 = new Node { Name = "Amiga 500", OS_Version = "AmigaOS", CPU_Arch = "Motorola 68000", RAM = 1, Storage = 20};
                var nA6128 = new Node { Name = "Amstrad CPC 6128", OS_Version = "Amstrad CP/M", CPU_Arch = "Zilog Z80", RAM = 0.5, Storage = 3 };
                var nNAS1 = new Node { Name = "16TB Synology NAS", OS_Version = "DSM Linux 3.2.101", CPU_Arch = "Intel Atom", RAM = 16, Storage = 16000 };
                var nNAS2 = new Node { Name = "16TB Ubuntu NAS", OS_Version = "Ubuntu Server 20.04", CPU_Arch = "Intel Core i7", RAM = 4, Storage = 16000 };


                // Create Hosts                
                var hNAS1 = new Host { Name = "HOMENAS" };
                var hNAS2 = new Host { Name = "SHEDNAS" };


                // Create Network Users
                var networkUser = new NetworkUser { Username = "p2626517", Email = "p2626517@my365.dmu.ac.uk" };
                var networkUser2 = new NetworkUser { Username = "arawn", Email = "arawn.davies780@gmail.com" };
                
                // Create Software
                var DSM = new Software { Name = "Synology DiskStation Manager", Version = "7.1" };
                var AWB = new Software { Name = "Amiga Workbench", Version = "3.1" };

                // Create Services
                var svcHTTP = new Service { Protocol = "HTTP", PortNum = 80};
                var svcFTP= new Service { Protocol = "FTP", PortNum = 21 };
                var svcSSH = new Service { Protocol = "SSH", PortNum = 22 };    


                // Create initial CINMs
                var cA500Mapping = new CINodeMapping { ConfigItem = cA500, Node = nA500 };
                var cA6128Mapping = new CINodeMapping { ConfigItem = cA6128, Node = nA6128 };
                var cNASMapping1 = new CINodeMapping { ConfigItem = cNAS1, Node = nNAS1 };
                var cNASMapping2 = new CINodeMapping { ConfigItem = cNAS2, Node = nNAS2 };

                // Create initial NHMs

                var NHM1 = new NodeHostMapping { Node = nNAS1, Host = hNAS1 };
                var NHM2 = new NodeHostMapping { Node = nNAS2, Host = hNAS2 };

                nNAS1.NodeHostMapping = NHM1;
                hNAS1.NodeHostMapping = NHM1;
                nNAS2.NodeHostMapping = NHM2;
                hNAS2.NodeHostMapping = NHM2;


                // Create initial NUMs
                var NUM1 = new NetworkUserMapping { Node = nNAS1, NetworkUser = networkUser };
                var NUM2 = new NetworkUserMapping { Node = nNAS2, NetworkUser = networkUser2 };

                // Create initial SIs
                var SI1 = new SoftwareInstallation { Node = nNAS1, Software = DSM };
                var SI2 = new SoftwareInstallation { Node = nA500, Software = AWB };
                nNAS1.InstalledSoftware.Add(SI1);
                nA500.InstalledSoftware.Add(SI2);


                // Create initial HSMs
                var HSM1 = new HostServiceMapping { Host = hNAS1, Service = svcFTP };
                var HSM2 = new HostServiceMapping { Host = hNAS2, Service = svcHTTP };
                var HSM3 = new HostServiceMapping { Host = hNAS2, Service = svcSSH };



                // Add new entities to database
                ConfigItems.Add(cA500);
                ConfigItems.Add(cA6128);
                ConfigItems.Add(cNAS1);
                ConfigItems.Add(cNAS2);

                Nodes.Add(nA500);
                Nodes.Add(nA6128);
                Nodes.Add(nNAS1);
                Nodes.Add(nNAS2);
                Hosts.Add(hNAS1);
                Hosts.Add(hNAS2);

                NetworkUsers.Add(networkUser);
                NetworkUsers.Add(networkUser2);

                Software.Add(DSM);
                Software.Add(AWB);

                Services.Add(svcSSH);
                Services.Add(svcFTP);
                Services.Add(svcHTTP);

                CINodeMappings.Add(cA500Mapping);
                CINodeMappings.Add(cA6128Mapping);
                CINodeMappings.Add(cNASMapping1);
                CINodeMappings.Add(cNASMapping2);

                NodeHostMappings.Add(NHM1);
                NodeHostMappings.Add(NHM2);

                SoftwareInstallations.Add(SI1);
                SoftwareInstallations.Add(SI2);

                HostServiceMappings.Add(HSM1);
                HostServiceMappings.Add(HSM2);
                HostServiceMappings.Add(HSM3);

                NetworkUserMappings.Add(NUM1);
                NetworkUserMappings.Add(NUM2);
            }
        }
    }
}
