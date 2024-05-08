using microCMDB.CLI;
using microCMDB.CLI.Models;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace microCMDB.Test
{
    [TestClass]
    public class CLITest
    {
        [TestMethod]
        public void SoftwareStore()
        {
            // Create a new instance of the Db class
            Db.CurrentDbContext = new Db();
            Software egApp = new Software { Name = "TestApp", Version = "1.0" };
            Assert.IsTrue(Db.CurrentDbContext.Software.First().Name == "TestApp");
        }

        [TestMethod]
        public void ConfigItemStore()
        {
            Db.CurrentDbContext = new Db();
            ConfigItem egConfigItem = new ConfigItem { Name = "TestConfigItem" };
            Assert.IsTrue(Db.CurrentDbContext.ConfigItems.First().Name == "TestConfigItem");
        }
        [TestMethod]
        public void NodeStore()
        {
            Db.CurrentDbContext = new Db();
            Node egNode = new Node { Name = "TestNode" };
            Db.CurrentDbContext.Nodes.Add(egNode);
            Assert.IsTrue(Db.CurrentDbContext.Nodes.First().Name == "TestNode");
        }
        [TestMethod]
        public void HostStore()
        {
            Db.CurrentDbContext = new Db();
            Host egHost = new Host { Name = "TestHost" };
            Assert.IsTrue(Db.CurrentDbContext.Hosts.First().Name == "TestHost", "Failed to store a Host");
        }
        [TestMethod]
        public void ServiceStore()
        {
            Db.CurrentDbContext = new Db();
            Service egService = new Service { Name = "TestService" };
            Assert.IsTrue(Db.CurrentDbContext.Services.First().Name == "TestService", "Failed to store a Service");
        }
        [TestMethod]
        public void NetworkUserStore()
        {
            Db.CurrentDbContext = new Db();
            NetworkUser egNetworkUser = new NetworkUser { Name = "TestNetworkUser" };
            Assert.IsTrue(Db.CurrentDbContext.NetworkUsers.First().Name == "TestNetworkUser", "Failed to store a Network User");
        }

        [TestMethod]
        public void DeleteTest()
        {
            Db.CurrentDbContext = new Db();
            Node egNode = new Node { Name = "TestNode", CPU_Arch = "x86_64", RAM = 32768, Description = "Put a more descriptive description here"};
            Console.WriteLine(egNode.ExportObject());
            CLI.Util.IO.DeleteEntity(egNode.DbTag);
            bool found = CLI.Util.Get.Find(egNode.DbTag);
            Assert.IsFalse(found, "Failed to delete Node entity from database");
        }

        [TestMethod]
        public void CITagTest()
        {
            Db.CurrentDbContext = new Db();
            ConfigItem egConfigItem = new ConfigItem { Name = "TestConfigItem" };
            Assert.IsTrue(egConfigItem.DbTag.StartsWith("CFG"));
        }

        [TestMethod]
        public void NodeTagTest()
        {
            Db.CurrentDbContext = new Db();
            Node egNode = new Node { Name = "TestNode" };
            Assert.IsTrue(egNode.DbTag.StartsWith("NOD"));
        }

        [TestMethod]
        public void HostTagTest()
        {
            Db.CurrentDbContext = new Db();
            Host egHost = new Host { Name = "TestHost" };
            Assert.IsTrue(egHost.DbTag.StartsWith("HST"));
        }

        [TestMethod]
        public void ServiceTagTest()
        {
            Db.CurrentDbContext = new Db();
            Service egService = new Service { Name = "TestService" };
            Assert.IsTrue(egService.DbTag.StartsWith("SVC"));
        }

        [TestMethod]
        public void SoftwareTagTest()
        {
            Db.CurrentDbContext = new Db();
            Software egSoftware = new Software { Name = "TestSoftware" };
            Assert.IsTrue(egSoftware.DbTag.StartsWith("STW"));
        }

        [TestMethod]
        public void NetworkUserTagTest()
        {
            Db.CurrentDbContext = new Db();
            NetworkUser egNetworkUser = new NetworkUser { Name = "TestNetworkUser" };
            Assert.IsTrue(egNetworkUser.DbTag.StartsWith("USR"));
        }
        
        // Test the DbTag property for each entity type
        [TestMethod]
        public void DbTagTests()
        {
            CITagTest();
            NodeTagTest();
            HostTagTest();
            ServiceTagTest();
            SoftwareTagTest();
            NetworkUserTagTest();
        }
    }
}