/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Utility class to provide methods for retrieving entities from the microCMDB backend.

using microCMDB.CLI.Models;

namespace microCMDB.CLI.Util
{
    internal class Get
    {
        public static void Find(string _tag)
        {
            Table.PrintLine();
            // Sort through the collections and compare the DbTag prefix and compare it to the first three letters of the method parameter.
            // If the prefix matches, call the PrintInfo method on the specific object
            foreach (ConfigItem configItem in Db.CurrentDbContext.ConfigItems)
            {
                if (configItem.DbTag.ToLower().StartsWith(_tag.ToLower()))
                {
                    configItem.PrintInfo();
                }
            } 

            foreach (Software software in Db.CurrentDbContext.Software)
            {
                if (software.DbTag.ToLower().StartsWith(_tag.ToLower()))
                {
                    software.PrintInfo();
                }
            }
            foreach (Service service in Db.CurrentDbContext.Services)
            {
                if (service.DbTag.ToLower().StartsWith(_tag.ToLower()))
                {
                    service.PrintInfo();
                }
            }
            foreach (NetworkUser networkUser in Db.CurrentDbContext.NetworkUsers)
            {
                if (networkUser.DbTag.ToLower().StartsWith(_tag.ToLower()))
                {
                    networkUser.PrintInfo();
                }
            }
            foreach (Host host in Db.CurrentDbContext.Hosts)
            {
                if (host.DbTag.ToLower().StartsWith(_tag.ToLower()))
                {
                    host.PrintInfo();
                }
            }

            foreach (Node node in Db.CurrentDbContext.Nodes)
            {
                if (node.DbTag.ToLower().StartsWith(_tag.ToLower()))
                {
                    node.PrintInfo();
                }
            }

            bool found = false;
            // If the tag does not match any of the prefixes found in Entity.EntityTypes, print an error message.
            foreach (string s in Entity.Prefixes)
            {
                if (_tag.ToLower().StartsWith(s.ToLower()))
                {
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No entity found with the tag: " + _tag);
                Console.WriteLine("Please enter a valid database entry.");
            }
            Table.PrintLine();
        }

        public static void GetConfigItems()
        {
            Table.PrintLine();
            foreach (var item in Db.CurrentDbContext.ConfigItems)
            {
                item.PrintInfo();
                Table.PrintLine();
            }
        }

        public static void GetNodes()
        {
            Table.PrintLine();
            foreach (var node in Db.CurrentDbContext.Nodes)
            {
                node.PrintInfo();
                Table.PrintLine();
            }
        }

        public static void GetHosts()
        {
            Table.PrintLine();
            foreach (var host in Db.CurrentDbContext.Hosts)
            {
                host.PrintInfo();
                Table.PrintLine();
            }
        }

        public static void GetServices()
        {
            Table.PrintLine();
            foreach (var service in Db.CurrentDbContext.Services)
            {
                service.PrintInfo();
                Table.PrintLine();
            }
        }

        public static void GetSoftware()
        {
            Table.PrintLine();
            foreach (var software in Db.CurrentDbContext.Software)
            {
                software.PrintInfo();
                Table.PrintLine();
            }
        }

        public static void GetNetworkUsers()
        {
            Table.PrintLine();
            foreach (var networkUser in Db.CurrentDbContext.NetworkUsers)
            {
                networkUser.PrintInfo();
                Table.PrintLine();
            }
        }

        public static void GetCINodeMappings()
        {
            Table.PrintLine();
            foreach (var ciNodeMapping in Db.CurrentDbContext.CINodeMappings)
            {
                ciNodeMapping.PrintInfo();
                Table.PrintLine();
            }
        }

        public static void GetNodeHostMappings()
        {
            Table.PrintLine();
            foreach (var nodeHostMapping in Db.CurrentDbContext.NodeHostMappings)
            {
                nodeHostMapping.PrintInfo();
                Table.PrintLine();
            }
        }

        public static void GetHostServiceMappings()
        {
            Table.PrintLine();
            foreach (var hostServiceMapping in Db.CurrentDbContext.HostServiceMappings)
            {
                hostServiceMapping.PrintInfo();
                Table.PrintLine();
            }
        }

        public static void GetSoftwareInstallations()
        {
            Table.PrintLine();
            foreach (var softwareInstallation in Db.CurrentDbContext.SoftwareInstallations)
            {
                softwareInstallation.PrintInfo();
                Table.PrintLine();
            }
        }

        public static void GetNetworkUserMappings()
        {
            Table.PrintLine();
            foreach (var networkUserMapping in Db.CurrentDbContext.NetworkUserMappings)
            {
                networkUserMapping.PrintInfo();
                Table.PrintLine();
            }
        }
    }
}
