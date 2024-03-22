/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Utility class to provide methods for retrieving entities from the microCMDB backend.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcmdb.common.Util
{
    internal class Get
    {
        public static void GetConfigItems()
        {
            // Placeholder implementation to retrieve ConfigItems
            Console.WriteLine("Retrieving ConfigItems...");
            // Replace this with actual logic to fetch ConfigItems from the CMDB backend
            foreach (var item in Db.CurrentDbContext.ConfigItems)
            {
                Console.WriteLine("=================================================");
                Console.WriteLine("ID: " + item.DbTag);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Purchase date: " + item.PurchaseDate);
                Console.WriteLine("Deployment location: " + item.DeployLoc);
            }
            Console.WriteLine("=================================================");
        }

        public static void GetNodes()
        {
            // Placeholder implementation to retrieve Nodes
            Console.WriteLine("Retrieving Nodes...");
            // Replace this with actual logic to fetch Nodes from the CMDB backend
            foreach (var node in Db.CurrentDbContext.Nodes)
            {
                Console.WriteLine("=================================================");
                Console.WriteLine("ID: " + node.NodeID);
                Console.WriteLine("Name: " + node.Name);
                Console.WriteLine("OS: " + node.OS_Version);
            }
        }

        public static void GetHosts()
        {
            // Placeholder implementation to retrieve Hosts
            Console.WriteLine("Retrieving Hosts...");
            // Replace this with actual logic to fetch Hosts from the CMDB backend
        }

        public static void GetServices()
        {
            // Placeholder implementation to retrieve Services
            Console.WriteLine("Retrieving Services...");
            // Replace this with actual logic to fetch Services from the CMDB backend
        }

        public static void GetSoftware()
        {
            // Placeholder implementation to retrieve Software
            Console.WriteLine("Retrieving Software...");
            // Replace this with actual logic to fetch Software from the CMDB backend
        }

        public static void GetNetworkUsers()
        {
            // Placeholder implementation to retrieve NetworkUsers
            Console.WriteLine("Retrieving NetworkUsers...");
            // Replace this with actual logic to fetch NetworkUsers from the CMDB backend
        }
    }
}
