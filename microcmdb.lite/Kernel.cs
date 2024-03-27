using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using microCMDB.common;
namespace microCMDB.lite
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.Clear();
        }

        protected override void Run()
        {
            Program.running = true;
            // While microCMDB.CLI.Running is true, run the CLI
            while (Program.running == true)
            {
                Program.CLI();
            }
            Sys.Power.Shutdown();


        }
    }
}
