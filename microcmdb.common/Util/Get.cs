/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Utility class to provide methods for retrieving entities from the microCMDB backend.

using microcmdb.common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcmdb.common.Util
{
    internal class Get
    {
        public static void SpecificGet(string _tag)
        {
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

            // If the tag does not match any of the prefixes found in Entity.EntityTypes, print an error message.
            foreach (string s in Entity.Prefixes)
            {
                if (!_tag.ToLower().StartsWith(s.ToLower()))
                {
                    Console.WriteLine("Invalid database tag. Please enter a valid one.");
                }
            }
        }

        public static void GetConfigItems()
        {
            foreach (var item in Db.CurrentDbContext.ConfigItems)
            {
                item.PrintInfo();
            }
        }

        public static void GetNodes()
        {
            foreach (var node in Db.CurrentDbContext.Nodes)
            {
                node.PrintInfo();
            }
        }

        public static void GetHosts()
        {
            foreach (var host in Db.CurrentDbContext.Hosts)
            {
                host.PrintInfo();
            }
        }

        public static void GetServices()
        {
            Console.WriteLine("Retrieving Services...");
            foreach (var service in Db.CurrentDbContext.Services)
            {
                service.PrintInfo();
            }
        }

        public static void GetSoftware()
        {
            foreach (var software in Db.CurrentDbContext.Software)
            {
                software.PrintInfo();
            }
        }

        public static void GetNetworkUsers()
        {
            foreach (var networkUser in Db.CurrentDbContext.NetworkUsers)
            {
                networkUser.PrintInfo();
            }
        }
    }
}
