using microCMDB.CLI;
using microCMDB.CLI.Models;

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
            Db.CurrentDbContext.Software.Add(egApp);
            Assert.IsTrue(Db.CurrentDbContext.Software.First().Name == "TestApp");
        }

        [TestMethod]
        public void ConfigItemStore()
        {
            Db.CurrentDbContext = new Db();
            ConfigItem egConfigItem = new ConfigItem { Name = "TestConfigItem" };
            Db.CurrentDbContext.ConfigItems.Add(egConfigItem);
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
            Db.CurrentDbContext.Hosts.Add(egHost);
            Assert.IsTrue(Db.CurrentDbContext.Hosts.First().Name == "TestHost");
        }
        [TestMethod]
        public void ServiceStore()
        {
            Db.CurrentDbContext = new Db();
            Service egService = new Service { Name = "TestService" };
            Db.CurrentDbContext.Services.Add(egService);
            Assert.IsTrue(Db.CurrentDbContext.Services.First().Name == "TestService");
        }
        [TestMethod]
        public void NetworkUserStore()
        {
            Db.CurrentDbContext = new Db();
            NetworkUser egNetworkUser = new NetworkUser { Name = "TestNetworkUser" };
            Db.CurrentDbContext.NetworkUsers.Add(egNetworkUser);
            Assert.IsTrue(Db.CurrentDbContext.NetworkUsers.First().Name == "TestNetworkUser");
        }

        // Test the DbTag property for each entity type
        [TestMethod]
        public void DbTagTest()
        {
            Db.CurrentDbContext = new Db();
            Software egSoftware = new Software { Name = "TestSoftware" };
            Assert.IsTrue(egSoftware.DbTag.StartsWith("STW"));
            ConfigItem egConfigItem = new ConfigItem { Name = "TestConfigItem" };
            Assert.IsTrue(egConfigItem.DbTag.StartsWith("CFG"));
            Node egNode = new Node { Name = "TestNode" };
            Assert.IsTrue(egNode.DbTag.StartsWith("NOD"));
            Host egHost = new Host { Name = "TestHost" };
            Assert.IsTrue(egHost.DbTag.StartsWith("HST"));
            Service egService = new Service { Name = "TestService" };
            Assert.IsTrue(egService.DbTag.StartsWith("SVC"));
            NetworkUser egNetworkUser = new NetworkUser { Name = "TestNetworkUser" };
            Assert.IsTrue(egNetworkUser.DbTag.StartsWith("USR"));
        }
    }
}