namespace microcmdb.common
{
    internal class Program
    {
        static void Main(string[] args)
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

                switch (input)
                {
                    case "":
                        break;
                    case "help":
                        Util.Help.DisplayHelp();
                        break;
                    case "get configitems":
                        Util.Get.GetConfigItems();
                        break;
                    case "get nodes":
                        Util.Get.GetNodes();
                        break;
                    case "get hosts":
                        Util.Get.GetHosts();
                        break;
                    case "get services":
                        Util.Get.GetServices();
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