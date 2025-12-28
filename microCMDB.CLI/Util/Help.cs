/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Utility class to provide methods for displaying help information in the microCMDB CLI.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microCMDB.CLI.Util
{
    public class Help
    {
        public static void DisplayHelp()
        {
            Console.WriteLine("Available Commands:");
            Console.WriteLine("  help\t\t\t- Display available commands");
            Console.WriteLine("  get\t\t\t- Retrieve entities from the CMDB");
            Console.WriteLine("  set\t\t\t- Set entities in the CMDB");
            Console.WriteLine("  new\t\t\t- Create new entities in the CMDB");
            Console.WriteLine("  find <dbtag>\t- Print info for a specific entity");
            Console.WriteLine("  delete <dbtag>\t- Delete a specific entity");
            Console.WriteLine("  export\t\t- Export entities from the CMDB");
            Console.WriteLine("  exit\t\t\t- Exit the CMDB CLI");
        }

        public static void Get()
        {
            Console.WriteLine("Available 'get' Commands:");
            Console.WriteLine("  get configitems\t- Retrieve ConfigItems from the CMDB");
            Console.WriteLine("  get nodes\t\t- Retrieve Nodes from the CMDB");
            Console.WriteLine("  get hosts\t\t- Retrieve Hosts from the CMDB");
            Console.WriteLine("  get services\t\t- Retrieve Services from the CMDB");
            Console.WriteLine("  get software\t\t- Retrieve Software from the CMDB");
            Console.WriteLine("  get networkusers\t- Retrieve NetworkUsers from the CMDB");
            // Get Developers
            Console.WriteLine("  get developers\t- Retrieve Developers from the CMDB");
            // Get Manufacturers
            Console.WriteLine("  get manufacturers\t- Retrieve Manufacturers from the CMDB");
            // Get Publishers
            Console.WriteLine("  get publishers\t- Retrieve Publishers from the CMDB");
        }

        public static void Set()
        {
            Console.WriteLine("Available 'set' Commands:");
            Console.WriteLine("  set configitems\t- Set ConfigItems in the CMDB");
            Console.WriteLine("  set nodes\t\t- Set Nodes in the CMDB");
            Console.WriteLine("  set hosts\t\t- Set Hosts in the CMDB");
            Console.WriteLine("  set services\t\t- Set Services in the CMDB");
            Console.WriteLine("  set software\t\t- Set Software in the CMDB");
            Console.WriteLine("  set networkusers\t- Set NetworkUsers in the CMDB");
        }

        public static void New()
        {
            Console.WriteLine("Available 'new' Commands:");
            Console.WriteLine("  new configitem\t- Create a new ConfigItem in the CMDB");
            Console.WriteLine("  new node\t\t- Create a new Node in the CMDB");
            Console.WriteLine("  new host\t\t- Create a new Host in the CMDB");
            Console.WriteLine("  new user\t\t- Create a new User in the CMDB");
            Console.WriteLine("  new service\t\t- Create a new Service in the CMDB");
            Console.WriteLine("  new software\t\t- Create a new Software in the CMDB");
        }
    }
}
