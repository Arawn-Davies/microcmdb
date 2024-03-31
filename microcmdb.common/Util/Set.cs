/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Utility class to provide methods for editing entities in the microCMDB backend.

using microCMDB.common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microCMDB.common.Util
{
    internal class Set
    {
        private static string Name = "";
        private static DateTime PurchasedDate;
        private static DateTime UpdatedDate = DateTime.Now;
        private static string Notes = "";
        private static string DeployLoc = "";
        private static string OS_Version = "";
        private static string IP_Address = "";
        private static string CPU_Arch = "";
        private static double RAM = 0;
        private static double Storage = 0;

        // Create the method SetNodes that has the same behaviour as SetConfigItems, but for the Node entity
        // This method should collect user input for each property of the Node entity, and replace the specified Node entity with the new values
        // If no match is found, print a message to the console
        public static void SetNodes(string _tag)
        {
            bool found = false;
            foreach (Node node in Db.CurrentDbContext.Nodes)
            {
                if (node.DbTag.ToLower().StartsWith(_tag.ToLower()))
                {
                    node.PrintInfo();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No Nodes found with the tag: " + _tag);
            }
            else
            {
                // Collect user input for each property of the Node entity
                Console.Write("Enter the name:");
                Name = Console.ReadLine();
                Console.Write("Enter the OS version:");
                OS_Version = Console.ReadLine();
                Console.Write("Enter the CPU architecture:");
                CPU_Arch = Console.ReadLine();
                Console.Write("Enter the RAM:");
                RAM = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter the storage:");
                Storage = Convert.ToDouble(Console.ReadLine());


                foreach (Node node in Db.CurrentDbContext.Nodes)
                {
                    if (node.DbTag.ToLower().StartsWith(_tag.ToLower()))
                    {
                        // Check each of the collected user inputs
                        // If any of them are not null or empty, then replace the existing values with the new values
                        
                        node.ModifiedDate = UpdatedDate;
                    }
                }

            }
        }

        // Matches the specified string with the DbTag of any ICollection entities in the Db CurrentDbContext object.
        // If a match is found, print the entity information to the console
        // If no match is found, print a message to the console
        public static void SetConfigItems(string _tag)
        {
            bool found = false;
            foreach (ConfigItem configItem in Db.CurrentDbContext.ConfigItems)
            {
                if (configItem.DbTag.ToLower().StartsWith(_tag.ToLower()))
                {
                    configItem.PrintInfo();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No ConfigItems found with the tag: " + _tag);
            }
            else
            {
                Console.Write("Enter the name:");
                Name = Console.ReadLine();

                // Check if the user input is null or empty
                // If it is, then do not parse the date
                Console.Write("Enter the purchase date (DD/MM/YYYY):");
                
                // Parse the string as a DateTime object
                DateTime _purchasedDT = IO.GetDate(Console.ReadLine());

                Console.Write("Enter any notes:");
                Notes = Console.ReadLine();
                Console.Write("Enter the deployment location:");
                DeployLoc = Console.ReadLine();

                foreach (ConfigItem configItem in Db.CurrentDbContext.ConfigItems)
                {
                    if (configItem.DbTag.ToLower().StartsWith(_tag.ToLower()))
                    {
                        // Check each of the collected user inputs
                        // If any of them are not null or empty, then replace the existing values with the new values
                        if (!string.IsNullOrEmpty(Name))
                        {
                            configItem.Name = Name;
                        }
                        if (_purchasedDT != DateTime.MinValue)
                        {
                            configItem.PurchaseDate = _purchasedDT;
                        }
                        if (!string.IsNullOrEmpty(Notes))
                        {
                            configItem.Description = Notes;
                        }
                        if (!string.IsNullOrEmpty(DeployLoc))
                        {
                            configItem.DeployLoc = DeployLoc;
                        }
                        configItem.ModifiedDate = UpdatedDate;
                    }
                }

            }
        }


        // Create a method that collects user input for each property of the ConfigItem entity, and replaces the specified ConfigItem entity with the new values


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
