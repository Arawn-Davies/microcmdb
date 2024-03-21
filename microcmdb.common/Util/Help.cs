using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcmdb.common.Util
{
    public class Help
    {
        static void DisplayHelp()
        {
            Console.WriteLine("Available Commands:");
            Console.WriteLine("  help               - Display available commands");
            Console.WriteLine("  get configitems   - Retrieve all ConfigItems");
            Console.WriteLine("  get nodes          - Retrieve all Nodes");
            Console.WriteLine("  get hosts          - Retrieve all Hosts");
            Console.WriteLine("  get services       - Retrieve all Services");
            Console.WriteLine("  exit               - Exit the CMDB CLI");
        }
    }
}
