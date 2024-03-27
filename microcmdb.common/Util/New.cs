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
            string _purchasedStr = Console.ReadLine();
            DateTime _purchasedDT = DateTime.Now;

            // Try and parse the date string to a DateTime object without using any TryParse methods by analyzing the string for characters, and handle any exceptions
            // If the date string is invalid, print an error message and prompt the user to enter the date again
            // If the date string is valid, set the PurchaseDate property of the ConfigItem object to the parsed DateTime object
            if (!string.IsNullOrEmpty(_purchasedStr))
            {
                bool validDate = false;
                while (!validDate)
                {
                    try
                    {
                        // Split the string into three segments separated by '/'
                        string[] dateParts = _purchasedStr.Split('/');
                        // Store the day, month and year as integers
                        int day = Convert.ToInt32(dateParts[0]);
                        int month = Convert.ToInt32(dateParts[1]);
                        int year = Convert.ToInt32(dateParts[2]);
                        // Create a new DateTime object with the parsed day, month and year
                        _purchasedDT = new DateTime(year, month, day);
                        validDate = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid date. Use format DD/MM/YYYY - Please retry.");
                        _purchasedStr = Console.ReadLine();
                    }
                }
            }


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
