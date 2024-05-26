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

namespace microCMDB.CLI.Util
{
    public class New
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
            Console.WriteLine("Creating a new Node...");
            Console.WriteLine("Enter ConfigItem ID");
            // Parse the string as an integer, handling any exceptions
            int _ciID = IO.GetInt();
            Console.WriteLine("Enter the name:");
            string? _name = Console.ReadLine();
            Console.WriteLine("Enter the operating system version:");
            string? _os = Console.ReadLine();
            Console.WriteLine("Enter the CPU architechture:");
            string? _cpu = Console.ReadLine();
            Console.WriteLine("Enter the amount of RAM:");
            double _ram = IO.GetDouble();
            Console.WriteLine("Enter the amount of storage:");
            double _storage = IO.GetDouble();
            Console.WriteLine("Enter any notes:");
            string? _notes = Console.ReadLine();

            Models.Node N = new Models.Node
            {
                ConfigItemID = _ciID,
                Name = _name,
                OS_Version = _os,
                CPU_Arch = _cpu,
                RAM = _ram,
                Storage = _storage,
                ModifiedDate = DateTime.Now,
                Description = _notes,
            };
            
        }

        public static void NewHost()
        {
            Console.WriteLine("Creating a new Host...");
            
        }

        public static void NewUser()
        {
            Console.WriteLine("Creating a new User item...");
            Console.WriteLine("Enter the name:");
            string _name = Console.ReadLine();
            Console.WriteLine("Enter the email address:");
            string _email = Console.ReadLine();
            Console.WriteLine("Enter the first name");
            string _firstname = Console.ReadLine();
            Console.WriteLine("Enter the last name");
            string _lastname = Console.ReadLine();
            Console.WriteLine("Enter the password");
            string _password = Console.ReadLine();
            
             
            Models.NetworkUser NU = new Models.NetworkUser
            {
                Name = _name,
                Firstname = _firstname,
                Lastname = _lastname,
                Password = _password,
                Email = _email
            };
        }

        public static void NewService()
        {
            // Placeholder implementation to create a new Service
            Console.WriteLine("Creating a new Service item...");
            // Replace this with actual logic to create a new Service in the CMDB backend
        }

        public static void NewSoftware()
        {
            // Placeholder implementation to create a new Software
            Console.WriteLine("Creating a new Software item...");
            // Replace this with actual logic to create a new Software in the CMDB backend
        }
    }
}
