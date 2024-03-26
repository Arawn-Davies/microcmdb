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

namespace microCMDB.common.Util
{
    public class Help
    {
        public static void DisplayHelp()
        {
            Console.WriteLine("Available Commands:");
            Console.WriteLine("  help               - Display available commands");
            Console.WriteLine("  get                - Retrieve entities from the CMDB");
            Console.WriteLine("  set                - Set entities in the CMDB");
            Console.WriteLine("  new                - Create new entities in the CMDB");
            Console.WriteLine("  exit               - Exit the CMDB CLI");
        }

        public static void Get()
        {
            Console.WriteLine("Available 'get' Commands:");
            Console.WriteLine("  get configitems    - Retrieve ConfigItems from the CMDB");
            Console.WriteLine("  get nodes          - Retrieve Nodes from the CMDB");
            Console.WriteLine("  get hosts          - Retrieve Hosts from the CMDB");
            Console.WriteLine("  get services       - Retrieve Services from the CMDB");
            Console.WriteLine("  get software       - Retrieve Software from the CMDB");
            Console.WriteLine("  get networkusers   - Retrieve NetworkUsers from the CMDB");
        }

        public static void Set()
        {
            Console.WriteLine("Available 'set' Commands:");
            Console.WriteLine("  set configitems    - Set ConfigItems in the CMDB");
            Console.WriteLine("  set nodes          - Set Nodes in the CMDB");
            Console.WriteLine("  set hosts          - Set Hosts in the CMDB");
            Console.WriteLine("  set services       - Set Services in the CMDB");
            Console.WriteLine("  set software       - Set Software in the CMDB");
            Console.WriteLine("  set networkusers   - Set NetworkUsers in the CMDB");
        }

        public static void New()
        {
            Console.WriteLine("Available 'new' Commands:");
            Console.WriteLine("  new configitem     - Create a new ConfigItem in the CMDB");
            Console.WriteLine("  new node           - Create a new Node in the CMDB");
            Console.WriteLine("  new host           - Create a new Host in the CMDB");
            Console.WriteLine("  new user           - Create a new User in the CMDB");
            Console.WriteLine("  new service        - Create a new Service in the CMDB");
            Console.WriteLine("  new software       - Create a new Software in the CMDB");
        }
    }
}
