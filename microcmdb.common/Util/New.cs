/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Utility class to provide methods for creating new entities in the microCMDB backend.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microCMDB.common.Util
{
    internal class New
    {
        // Similar to the Set and Get classes, create methods to create new entities in the Db CurrentDbContext object

        public static void NewConfigItem()
        {

            Console.WriteLine("Creating a new ConfigItem...");


            Console.WriteLine("Enter the name:");
            string? _name = Console.ReadLine();

            Console.WriteLine("Enter the purchase date:");
            // Parse the string as a DateTime object
            DateTime _purchasedDT = IO.GetDate(Console.ReadLine());

            Console.WriteLine("Enter when last updated:");
            DateTime _updatedDT = DateTime.Now;
            
            Console.WriteLine("Enter any notes:");
            string? _notes = Console.ReadLine();
            
            Console.WriteLine("Enter the deployment location:");
            string? _deployLoc = Console.ReadLine();

            Models.ConfigItem CI = new Models.ConfigItem
            {
                Name = _name,
                PurchaseDate = _purchasedDT,
                ModifiedDate = _updatedDT,
                Description = _notes,
                DeployLoc = _deployLoc
            };

            Db.CurrentDbContext.ConfigItems.Add(CI);

            CI.PrintInfo();


        }

        public static void NewNode()
        {
            // Placeholder implementation to create a new Node
            Console.WriteLine("Creating a new Node...");
            // Replace this with actual logic to create a new Node in the CMDB backend
        }

        public static void NewHost()
        {
            // Placeholder implementation to create a new Host
            Console.WriteLine("Creating a new Host...");
            // Replace this with actual logic to create a new Host in the CMDB backend
        }

        public static void NewUser()
        {
            // Placeholder implementation to create a new User
            Console.WriteLine("Creating a new User...");
            // Replace this with actual logic to create a new User in the CMDB backend
        }

        public static void NewService()
        {
            // Placeholder implementation to create a new Service
            Console.WriteLine("Creating a new Service...");
            // Replace this with actual logic to create a new Service in the CMDB backend
        }

        public static void NewSoftware()
        {
            // Placeholder implementation to create a new Software
            Console.WriteLine("Creating a new Software...");
            // Replace this with actual logic to create a new Software in the CMDB backend
        }
    }
}
