using microCMDB.common.Models;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microCMDB.common.Util
{
    internal class IO
    {
        // Prompt the user to respond with a 'y' or 'n' and return the response as a boolean
        public static bool GetYesNo(string _prompt)
        {
            Console.WriteLine(_prompt + " (y/n)");
            string response = Console.ReadLine();
            if (response.ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static string path = Directory.GetCurrentDirectory() + "/data/";
        public static bool resp = false;
        // Export all of the ICollection properties to a CSV file
        public static void Export()
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine("");
            }
            if (Db.CurrentDbContext == null)
            {
                Console.WriteLine("No database context found. Please create a new database context before exporting data.");
                return;
            }
            List<string> EntityCSV = new List<string>();
            List<string> CIs = new List<string>();
            List<string> Nodes = new List<string>();
            List<string> Hosts = new List<string>();
            List<string> Services = new List<string>();
            List<string> Software = new List<string>();
            List<string> NetworkUsers = new List<string>();
            List<string> CINodeMappings = new List<string>();
            List<string> NodeHostMappings = new List<string>();
            List<string> HostServiceMappings = new List<string>();
            List<string> SoftwareInstallations = new List<string>();
            List<string> NetworkUserMappings = new List<string>();
            List<string> MapCSV = new List<string>();

            #region Entity-specific CSV
            foreach (ConfigItem ci in Db.CurrentDbContext.ConfigItems)
            {
                CIs.Add(ci.ExportObject());
            }
            foreach (Node node in Db.CurrentDbContext.Nodes)
            {
                Nodes.Add(node.ExportObject());
            }
            foreach (Host host in Db.CurrentDbContext.Hosts)
            {
                Hosts.Add(host.ExportObject());
            }
            foreach (Service service in Db.CurrentDbContext.Services)
            {
                Services.Add(service.ExportObject());
            }
            foreach (Software software in Db.CurrentDbContext.Software)
            {
                Software.Add(software.ExportObject());
            }
            foreach (NetworkUser networkUser in Db.CurrentDbContext.NetworkUsers)
            {
                NetworkUsers.Add(networkUser.ExportObject());
            }
            #endregion

            #region Mapping-specific CSV
            foreach (CINodeMapping ciNodeMapping in Db.CurrentDbContext.CINodeMappings)
            {
                CINodeMappings.Add(ciNodeMapping.ExportObject());
            }
            foreach (NodeHostMapping nodeHostMapping in Db.CurrentDbContext.NodeHostMappings)
            {
                NodeHostMappings.Add(nodeHostMapping.ExportObject());
            }
            foreach (HostServiceMapping hostServiceMapping in Db.CurrentDbContext.HostServiceMappings)
            {
                HostServiceMappings.Add(hostServiceMapping.ExportObject());
            }
            foreach (SoftwareInstallation softwareInstallation in Db.CurrentDbContext.SoftwareInstallations)
            {
                SoftwareInstallations.Add(softwareInstallation.ExportObject());
            }
            foreach (NetworkUserMapping networkUserMapping in Db.CurrentDbContext.NetworkUserMappings)
            {
                NetworkUserMappings.Add(networkUserMapping.ExportObject());
            }
            #endregion

            File.WriteAllLines(path + "cfgitems.csv", CIs);
            File.WriteAllLines(path + "nodes.csv", Nodes);
            File.WriteAllLines(path + "hosts.csv", Hosts);
            File.WriteAllLines(path + "services.csv", Services);
            File.WriteAllLines(path + "software.csv", Software);
            File.WriteAllLines(path + "networkusers.csv", NetworkUsers);
            File.WriteAllLines(path + "cinodemappings.csv", CINodeMappings);
            File.WriteAllLines(path + "nodehostmappings.csv", NodeHostMappings);
            File.WriteAllLines(path + "hostservicemappings.csv", HostServiceMappings);
            File.WriteAllLines(path + "softwareinstallations.csv", SoftwareInstallations);
            File.WriteAllLines(path + "networkusermappings.csv", NetworkUserMappings);

        }

        public static void Import()
        {
            if (Db.CurrentDbContext != null)
            {
                if (Db.CurrentDbContext.ConfigItems.Count > 0)
                {
                    resp = GetYesNo("Data already exists in the database. Importing data will overwrite the existing data. Do you want to continue?");
                    if (resp != true)
                    {
                        return;
                    }
                }
                Console.WriteLine("Importing data from CSV files...");
                // Read all CSV files in the current directory and import the data into the corresponding collections in Db.CurrentDbContext
                foreach (string ci in Directory.GetFiles(Directory.GetCurrentDirectory(), "cfgitems.csv"))
                {
                    Console.WriteLine("Importing data from file: " + ci);
                    string[] prop = ci.Split(',');
                    new ConfigItem( prop[0],prop[1],prop[2],GetDate(prop[3]),prop[4]);
                }
            }
        }

        public static DateTime GetDate(string _dstr)
        {
            DateTime date = DateTime.MinValue;
            if (!string.IsNullOrEmpty(_dstr))
            {
                bool validDate = false;
                while (!validDate)
                {
                    try
                    {
                        if (_dstr == "now")
                        {
                            date = DateTime.Now;
                            validDate = true;
                        }
                        else if (_dstr == "never")
                        {
                            date = DateTime.MinValue;
                            validDate = true;
                        }
                        // Split the string into three segments separated by '/'
                        string[] dateParts = _dstr.Split('/');
                        // Store the day, month and year as integers
                        int day = Convert.ToInt32(dateParts[0]);
                        int month = Convert.ToInt32(dateParts[1]);
                        int year = Convert.ToInt32(dateParts[2]);
                        // Create a new DateTime object with the parsed day, month and year
                        date = new DateTime(year, month, day);
                        validDate = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid date. Use format DD/MM/YYYY - Please retry.");
                        _dstr = Console.ReadLine();
                    }
                }
            }
            else
            {
                date = DateTime.Now;
            }
            return date;
        }

        // Prompt the user for a specific DbTag and delete the associated entity from its respective ICollection
        public static void DeleteEntity(string input)
        {
            string _dbTag = input.ToUpper();
            if (Db.CurrentDbContext == null)
            {
                Console.WriteLine("No database context found. Please create a new database context before deleting data.");
                return;
            }
            if (Db.CurrentDbContext.ConfigItems.Any(ci => ci.DbTag == _dbTag))
            {
                Db.CurrentDbContext.ConfigItems.Remove(Db.CurrentDbContext.ConfigItems.First(ci => ci.DbTag == _dbTag));
            }
            else if (Db.CurrentDbContext.Nodes.Any(n => n.DbTag == _dbTag))
            {
                Db.CurrentDbContext.Nodes.Remove(Db.CurrentDbContext.Nodes.First(n => n.DbTag == _dbTag));
            }
            else if (Db.CurrentDbContext.Hosts.Any(h => h.DbTag == _dbTag))
            {
                Db.CurrentDbContext.Hosts.Remove(Db.CurrentDbContext.Hosts.First(h => h.DbTag == _dbTag));
            }
            else if (Db.CurrentDbContext.Services.Any(s => s.DbTag == _dbTag))
            {
                Db.CurrentDbContext.Services.Remove(Db.CurrentDbContext.Services.First(s => s.DbTag == _dbTag));
            }
            else if (Db.CurrentDbContext.Software.Any(sw => sw.DbTag == _dbTag))
            {
                Db.CurrentDbContext.Software.Remove(Db.CurrentDbContext.Software.First(sw => sw.DbTag == _dbTag));
            }
            else if (Db.CurrentDbContext.NetworkUsers.Any(nu => nu.DbTag == _dbTag))
            {
                Db.CurrentDbContext.NetworkUsers.Remove(Db.CurrentDbContext.NetworkUsers.First(nu => nu.DbTag == _dbTag));
            }
            else
            {
                Console.WriteLine("No entity found with the DbTag: " + _dbTag);
            }
        }

    }
}
