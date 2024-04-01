/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// This file contains the main entry point for the microCMDB CLI application.

using microCMDB.CLI.Models;
using microCMDB.CLI.Util;

namespace microCMDB.CLI
{
    public class Program
    {
        public static bool running = false;
        private static void Main()
        {
            IO.path = "C:\\microCMDB\\";
            running = true;
            while (running == true)
            {
                CLI();
            }
            running = false;
        }

        public static void CLI()
        {
            if (Db.CurrentDbContext == null)
            {
                Db.CurrentDbContext = new Db();
                IO.resp = IO.GetYesNo("No database loaded. Would you like to seed the database?");
                if (IO.resp == true)
                {
                    Console.WriteLine("Creating a new database...");
                    Db.CurrentDbContext.SeedDatabase();
                }
            }


            Console.WriteLine("Welcome to the microCMDB CLI");
            Console.WriteLine("Type 'help' to see available commands.");

            while (true)
            {
                Console.Write("\n> ");


                string? input = Console.ReadLine()?.ToLower();


                // Split the input into command and arguments

                if (input == null)
                {
                    Console.WriteLine("Invalid command. Type 'help' for available commands.");
                    continue;
                }

                string[] parts = input.Split(' ');
                if (parts.Length > 0)
                {
                    // The command is the first part of the input
                    string command = parts[0];
                    // The arguments are the second part of the input, if it exists
                    string args = parts.Length > 1 ? parts[1] : string.Empty;

                    switch (command)
                    {
                        case "":
                            // If the input is empty, skip the rest of the loop
                            break;
                        case "cls":
                        case "clear":
                            Console.Clear();
                            break;
                        case "help":
                            switch (args)
                            {
                                case "get":
                                    Util.Help.Get();
                                    break;
                                case "set":
                                    Util.Help.Set();
                                    break;
                                case "new":
                                    Util.Help.New();
                                    break;
                                default:
                                    Util.Help.DisplayHelp();
                                    break;
                            }
                            break;
                        case "get":
                            switch (args)
                            {
                                case "configitems":
                                case "c":
                                    Util.Get.GetConfigItems();
                                    break;
                                case "nodes":
                                case "n":
                                    Util.Get.GetNodes();
                                    break;
                                case "hosts":
                                case "h":
                                    Util.Get.GetHosts();
                                    break;
                                case "services":
                                case "svc":
                                    Util.Get.GetServices();
                                    break;
                                case "software":
                                case "stw":
                                    Util.Get.GetSoftware();
                                    break;
                                default:
                                    Console.WriteLine("Invalid 'get' command. Type 'help get' for available queries.");
                                    break;
                            }
                            break;
                        case "set":
                            switch (args)
                            {
                                case "configitems":
                                case "c":
                                    Util.Set.SetConfigItems(parts[2]);
                                    break;
                                case "nodes":
                                case "n":
                                    Util.Set.SetNodes();
                                    break;
                                case "hosts":
                                case "h":
                                    Util.Set.SetHosts();
                                    break;
                                case "services":
                                case "svc":
                                    Util.Set.SetServices();
                                    break;
                                case "software":
                                case "stw":
                                    Util.Set.SetSoftware();
                                    break;
                                default:
                                    Console.WriteLine("Invalid 'set' command. Type 'help set' for available queries.");
                                    break;
                            }
                            break;

                        case "new":
                            switch (args)
                            {
                                case "db":
                                    if (Db.CurrentDbContext != null)
                                    {
                                        IO.resp = IO.GetYesNo("The currently loaded database will be lost. Make sure you export to avoid data loss." +
                                            "\nDo you want to continue?");
                                        if (IO.resp == false)
                                        {
                                            break;
                                        }
                                    }
                                    Db.CurrentDbContext = new Db();


                                    break;
                                case "configitem":
                                case "c":
                                    Util.New.NewConfigItem();
                                    break;
                                case "node":
                                case "n":
                                    Util.New.NewNode();
                                    break;
                                case "host":
                                case "h":
                                    Util.New.NewHost();
                                    break;
                                case "service":
                                case "svc":
                                    Util.New.NewService();
                                    break;
                                case "software":
                                case "stw":
                                    Util.New.NewSoftware();
                                    break;
                                default:
                                    Console.WriteLine("Invalid 'new' command. Type 'help new' for available queries.");
                                    break;
                            }
                            break;
                        case "find":
                            Get.Find(args);
                            break;
                        case "delete":
                            IO.DeleteEntity(args);
                            break;
                        case "ver":
                            Console.WriteLine("microCMDB CLI Build: " + BuildInfo.BuildNumber);
                            Console.WriteLine("Developed by Arawn Davies (2024) for Computer Science BSc Final Year Project");
                            break;
                        case "export":
                            //Util.Get.Export();
                            try
                            { 
                                IO.Export();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("An error occurred while exporting data: " + e.Message);
                            }
                            
                            break;
                        case "exit":
                            Console.WriteLine("Exiting CMDB CLI. Goodbye!");
                            running = false;
                            return;

                        default:
                            Console.WriteLine("Invalid command. Type 'help' for available commands.");
                            break;
                    }

                }
            }
        }
    }
}