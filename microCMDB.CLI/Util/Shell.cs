using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microCMDB.CLI.Util
{
    public class Shell
    {
        // A boolean value to determine if microCMDB.OS is being used
        public static bool cmdbOS = false;
        // microCMDB.OS current build if applicable
        public static string OSbnum = "";
        // A boolean value to determine if the database should be seeded
        private static bool seed = true;
        // The system command to be passed to the OS
        public static string OScmd = "";

        /// <summary>
        /// Initialises the database and seeds it if required.
        /// </summary>
        /// <param name="init"></param>
        private static void InitDB(bool init = true)
        {
            //if (Db.CurrentDbContext == null)
            //{
                //if (init == true)
                //{
                    Console.WriteLine("Creating a new database...");
                    Db.CurrentDbContext.SeedDatabase();
                //}
            //}
        }

        /// <summary>
        /// Prepares the CLI for use by checking if a database is loaded and seeding it if required.
        /// </summary>
        public static void Prep()
        {
            Db.CurrentDbContext = new Db();
            seed = true;
            // Initialise the database if it is not already loaded, and seed it if required
            InitDB(seed);
            /*
            

            if (!Directory.Exists(IO.path + "\\cli.db"))
            {
                
            }
            else
            {
                seed = IO.GetYesNo("No database loaded. Would you like to seed the database?");
            }
            IO.resp = IO.GetYesNo("No database loaded. Would you like to seed the database?");
            seed = IO.resp;
            */
        }

        /// <summary>
        /// The main CLI loop for the microCMDB application.
        /// </summary>
        public static void CLI()
        {
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
                            Get.PrintEntityInfo(args);
                            break;
                        case "delete":
                            IO.DeleteEntity(args);
                            break;
                        case "ver":
                            Console.WriteLine("Copyright (C) 2024 Arawn Davies");
                            Console.WriteLine("microCMDB CLI Build: " + BuildInfo.BuildNumber);
                            if (cmdbOS == true)
                            {
                                Console.WriteLine("microCMDB.OS Build: " + OSbnum);
                            }
                            Console.WriteLine("Developed by Arawn Davies (2024) for Computer Science BSc Final Year Project");
                            break;
                        case "export":
                            if (IO.Hosted == false)
                            {
                                Console.WriteLine("Exporting data is currently not supported in microCMDB.OS");
                            }
                            else
                            {
                                try
                                {
                                    IO.Export();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("An error occurred while exporting data: " + e.Message);
                                }
                            }
                            break;
                        case "exit":
                            Console.WriteLine("Exiting CMDB CLI. Goodbye!");
                            Program.running = false;
                            return;
                        case "sys":
                            if (cmdbOS == false)
                            {
                                Console.WriteLine("System commands are only available in microCMDB.OS");
                                break;
                            }
                            else
                            {
                                // Remove the 'sys' prefix and space from the system command and pass to the OS
                                OScmd = input.Substring(4);
                                return;
                            }
                        default:
                            Console.WriteLine("Invalid command. Type 'help' for available commands.");
                            break;
                    }

                }
            }
        }
    }
}
