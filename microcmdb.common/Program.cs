namespace microcmdb.common
{
    internal class Program
    {
        static void Main()
        {
            if (Db.CurrentDbContext == null)
            {
                Db.CurrentDbContext = new Db();
                Db.CurrentDbContext.SeedDatabase();
            }


            Console.WriteLine("Welcome to the microCMDB CLI");
            Console.WriteLine("Type 'help' to see available commands.");

            while (true)
            {
                Console.Write("> ");


                string input = Console.ReadLine()?.ToLower();


                // Split the input into command and arguments

                string[] parts = input.Split(' ', 2);
                if (parts.Length > 0)
                {
                    // The command is the first part of the input
                    string command = parts[0];
                    // The arguments are the second part of the input, if it exists
                    string args = parts.Length > 1 ? parts[1] : string.Empty;

                    Console.WriteLine(" ");

                    switch (command)
                    {
                        case "":
                            // If the input is empty, skip the rest of the loop
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
                                    Util.Get.GetConfigItems();
                                    break;
                                case "nodes":
                                    Util.Get.GetNodes();
                                    break;
                                case "hosts":
                                    Util.Get.GetHosts();
                                    break;
                                case "services":
                                    Util.Get.GetServices();
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
                                    Util.Set.SetConfigItems();
                                    break;
                                case "nodes":
                                    Util.Set.SetNodes();
                                    break;
                                case "hosts":
                                    Util.Set.SetHosts();
                                    break;
                                case "services":
                                    Util.Set.SetServices();
                                    break;
                                default:
                                    Console.WriteLine("Invalid 'set' command. Type 'help set' for available queries.");
                                    break;
                            }
                            break;

                        case "new":
                            switch (args)
                            {
                                case "configitem":
                                    Util.New.NewConfigItem();
                                    break;
                                case "node":
                                    Util.New.NewNode();
                                    break;
                                case "host":
                                    Util.New.NewHost();
                                    break;
                                case "service":
                                    Util.New.NewService();
                                    break;
                                default:
                                    Console.WriteLine("Invalid 'new' command. Type 'help new' for available queries.");
                                    break;
                            }
                            break;

                        case "ver":
                            Console.WriteLine("microCMDB CLI v1.0");
                            break;
                        case "exit":
                            Console.WriteLine("Exiting CMDB CLI. Goodbye!");
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