using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using microCMDB.CLI;
using microCMDB.CLI.Util;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using System.IO;

namespace microCMDB.lite
{
    public class Kernel : Sys.Kernel
    {
        private static string driveID = @"0:\";

        public static CosmosVFS vFS;

        protected override void BeforeRun()
        {
            vFS = new CosmosVFS();
            VFSManager.RegisterVFS(vFS);
            IO.path = driveID + "\\ucmdb\\";
            var fs_type = vFS.GetFileSystemType(@"0:\");
            Console.WriteLine("File System Type: " + fs_type);
            var files_list = Directory.GetFiles(@"0:\");
            foreach (var file in files_list)
            {
                Console.WriteLine(file);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Directory.SetCurrentDirectory(IO.path);

        }

        protected override void Run()
        {
            Program.running = true;

            // While microCMDB.CLI.Running is true, run the CLI
            while (Program.running == true)
            {
                try
                {
                    Program.CLI();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //Console.WriteLine(ex.StackTrace);
                    Console.WriteLine("An error occurred. Press any key to continue...");
                    Console.ReadKey(true);
                }
                
            }
            Sys.Power.Shutdown();


        }
    }
}
