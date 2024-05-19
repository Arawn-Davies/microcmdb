/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Utility class to provide methods for importing and exporting data to and from the microCMDB backend.
using microCMDB.CLI.Models;
using System.IO;

namespace microCMDB.CLI.Util
{
    public class IO
    {
        public static bool Hosted;

        private static string[] CIs = new string[999];
        private static string[] Nodes = new string[999];
        private static string[] Hosts = new string[999];
        private static string[] Services = new string[999];
        private static string[] Software = new string[999];
        private static string[] NetworkUsers = new string[999];
        private static string[] CINodeMappings = new string[999];
        private static string[] NodeHostMappings = new string[999];
        private static string[] HostServiceMappings = new string[999];
        private static string[] SoftwareInstallations = new string[999];
        private static string[] NetworkUserMappings = new string[999];

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

        public static int GetInt()
        {
            int i = 0;
            bool valid = false;
            while (!valid)
            {
                try
                {
                    i = Convert.ToInt32(Console.ReadLine());
                    valid = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }   
            return i;
        }

        public static double GetDouble()
        {
            double d = 0;
            bool valid = false;
            while (!valid)
            {
                try
                {
                    d = Convert.ToDouble(Console.ReadLine());
                    valid = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            return d;
        }
        
        public static string? path;

        public static bool resp = false;
        // Export all of the ICollection properties to a CSV file
        public static void Export()
        {
            Console.WriteLine("Exporting data to CSV files...");
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (Db.CurrentDbContext == null)
            {
                Console.WriteLine("No database context found. Please create a new database context before exporting data.");
                return;
            }

            // Write the contents of each ICollection to a CSV file
            Console.WriteLine("Writing CSV files...");
            #region Entity-specific CSV
            foreach (ConfigItem ci in Db.CurrentDbContext.ConfigItems)
            {
                Console.WriteLine(ci.ExportObject());
                File.AppendAllText(path + "/cfgitems.csv", ci.ExportObject() + "\n");
            }
            foreach (Node node in Db.CurrentDbContext.Nodes)
            {
                Console.WriteLine(node.ExportObject());
                File.AppendAllText(path + "/nod.csv", node.ExportObject() + "\n");
            }
            foreach (Host host in Db.CurrentDbContext.Hosts)
            {
                Console.WriteLine(host.ExportObject());
                // Append the host ExportObject string to the hst.csv file
                File.AppendAllText(path + "/hst.csv", host.ExportObject() + "\n");
            }
            foreach (Service service in Db.CurrentDbContext.Services)
            {
                Console.WriteLine(service.ExportObject());
                // Append the service ExportObject string to the svc.csv file
                File.AppendAllText(path + "/svc.csv", service.ExportObject() + "\n");
            }
            foreach (Software software in Db.CurrentDbContext.Software)
            {
                Console.WriteLine(software.ExportObject());
                // Append the software ExportObject string to the stw.csv file
                File.AppendAllText(path + "/stw.csv", software.ExportObject() + "\n");
            }
            foreach (NetworkUser networkUser in Db.CurrentDbContext.NetworkUsers)
            {
                Console.WriteLine(networkUser.ExportObject());
                // Append the networkUser ExportObject string to the nus.csv file
                File.AppendAllText(path + "/nus.csv", networkUser.ExportObject() + "\n");
            }
            #endregion
            Console.WriteLine("Entity-specific CSVs written...");

            Console.WriteLine("Writing Mapping-specific CSVs...");
            #region Mapping-specific CSV
            foreach (CINodeMapping ciNodeMapping in Db.CurrentDbContext.CINodeMappings)
            {
                Console.WriteLine(ciNodeMapping.ExportObject());
                // Append the ciNodeMapping ExportObject string to the cinmap.csv file
                File.AppendAllText(path + "/cinmap.csv", ciNodeMapping.ExportObject() + "\n");
            }
            foreach (NodeHostMapping nodeHostMapping in Db.CurrentDbContext.NodeHostMappings)
            {
                Console.WriteLine(nodeHostMapping.ExportObject());
                // Append the nodeHostMapping ExportObject string to the ndhmap.csv file
                File.AppendAllText(path + "/ndhmap.csv", nodeHostMapping.ExportObject() + "\n");
            }
            foreach (HostServiceMapping hostServiceMapping in Db.CurrentDbContext.HostServiceMappings)
            {
                Console.WriteLine(hostServiceMapping.ExportObject());
                // Append the hostServiceMapping ExportObject string to the hsvmap.csv file
                File.AppendAllText(path + "/hsvmap.csv", hostServiceMapping.ExportObject() + "\n");
            }
            foreach (SoftwareInstallation softwareInstallation in Db.CurrentDbContext.SoftwareInstallations)
            {
                Console.WriteLine(softwareInstallation.ExportObject());
                // Append the softwareInstallation ExportObject string to the sinmap.csv file
                File.AppendAllText(path + "/sinmap.csv", softwareInstallation.ExportObject() + "\n");
            }
            foreach (NetworkUserMapping networkUserMapping in Db.CurrentDbContext.NetworkUserMappings)
            {
                Console.WriteLine(networkUserMapping.ExportObject());
                // Append the networkUserMapping ExportObject string to the nusmap.csv file
                File.AppendAllText(path + "/nusmap.csv", networkUserMapping.ExportObject() + "\n");
            }
            #endregion
            Console.WriteLine("Mapping-specific CSVs written...");
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
                    new ConfigItem(prop[0], prop[1], prop[2], GetDate(prop[3]), prop[4]);
                }

                // ========================================================================================================
                // From the Export() method, do the reverse of the Export() method and import the data from the CSV files
                // ========================================================================================================

                foreach (string node in Directory.GetFiles(Directory.GetCurrentDirectory(), "nod.csv"))
                {
                    Console.WriteLine("Importing data from file: " + node);
                    string[] prop = node.Split(',');
                    new Node(prop[0], prop[1], prop[2], prop[3], prop[4], prop[5], prop[6], prop[7], prop[8], prop[9], prop[10], prop[11], prop[12], prop[13], prop[14], prop[15], prop[16], prop[17], prop[18], prop[19], prop[20], prop[21], prop[22], prop[23], prop[24], prop[25], prop[26], prop[27], prop[28], prop[29], prop[30], prop[31], prop[32], prop[33], prop[34], prop[35], prop[36], prop[37], prop[38], prop[39], prop[40], prop[41], prop[42], prop[43], prop[44], prop[45], prop[46], prop[47], prop[48], prop[49], prop[50], prop[51], prop[52], prop[53], prop[54], prop[55], prop[56], prop[57], prop[58], prop[59], prop[60], prop[61], prop[62], prop[63], prop[64], prop[65], prop[66], prop[67], prop[68], prop[69], prop[70], prop[71], prop[72], prop[73], prop[74], prop[75], prop[76], prop[77], prop[78], prop[79], prop[80], prop[81], prop[82], prop[83], prop[84], prop[85], prop[86], prop[87], prop[88], prop[89], prop[90], prop[91], prop[92], prop[93], prop[94], prop[95], prop[96], prop[97], prop[98], prop[99]);
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
            if (Db.CurrentDbContext.Entities.Any(o => o.DbTag == _dbTag))
            {
                Db.CurrentDbContext.Entities.Remove(Db.CurrentDbContext.Entities.First(o => o.DbTag == _dbTag));
            }
            else if (Db.CurrentDbContext.CINodeMappings.Any(cnm => cnm.DbTag == _dbTag))
            {
                Db.CurrentDbContext.CINodeMappings.Remove(Db.CurrentDbContext.CINodeMappings.First(cnm => cnm.DbTag == _dbTag));
            }
            else if (Db.CurrentDbContext.NodeHostMappings.Any(nhm => nhm.DbTag == _dbTag))
            {
                Db.CurrentDbContext.NodeHostMappings.Remove(Db.CurrentDbContext.NodeHostMappings.First(nhm => nhm.DbTag == _dbTag));
            }
            else if (Db.CurrentDbContext.HostServiceMappings.Any(hsm => hsm.DbTag == _dbTag))
            {
                Db.CurrentDbContext.HostServiceMappings.Remove(Db.CurrentDbContext.HostServiceMappings.First(hsm => hsm.DbTag == _dbTag));
            }
            else if (Db.CurrentDbContext.SoftwareInstallations.Any(si => si.DbTag == _dbTag))
            {
                Db.CurrentDbContext.SoftwareInstallations.Remove(Db.CurrentDbContext.SoftwareInstallations.First(si => si.DbTag == _dbTag));
            }
            else if (Db.CurrentDbContext.NetworkUserMappings.Any(num => num.DbTag == _dbTag))
            {
                Db.CurrentDbContext.NetworkUserMappings.Remove(Db.CurrentDbContext.NetworkUserMappings.First(num => num.DbTag == _dbTag));
            }
            else if (Db.CurrentDbContext.ConfigItems.Any(ci => ci.DbTag == _dbTag))
            {
                Db.CurrentDbContext.Entities.Remove(Db.CurrentDbContext.Entities.First(ci => ci.DbTag == _dbTag));
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
