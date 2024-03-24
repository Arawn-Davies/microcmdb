/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Utility class to provide methods for editing entities in the microCMDB backend.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcmdb.common.Util
{
    internal class Set
    {
        // Similar to the Get class, create methods to retrieve all entities stored in the Db CurrentDbContext object
        public static void SetConfigItems()
        {
            // Placeholder implementation to set ConfigItems
            Console.WriteLine("Setting ConfigItems...");   
        }

        public static void SetNodes()
        {
            Console.WriteLine("Setting Nodes...");   
        }

        public static void SetHosts()
        {
            Console.WriteLine("Setting Hosts...");   
        }

        public static void SetServices()
        {
            Console.WriteLine("Setting Services...");   
        }

        public static void SetSoftware()
        {
            Console.WriteLine("Setting Software...");    
        }

        public static void SetNetworkUsers()
        {
            Console.WriteLine("Setting NetworkUsers...");
        }
    }
}
