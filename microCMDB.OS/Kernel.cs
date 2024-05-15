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
        private static string[] files_list;

        public static CosmosVFS vFS;

        /// <summary>
        /// microCMDB OS pre-boot setup
        /// </summary>
        protected override void BeforeRun()
        {
            vFS = new CosmosVFS();
            VFSManager.RegisterVFS(vFS);
            IO.path = driveID + "\\ucmdb\\";
            IO.Hosted = false;
            var fs_type = vFS.GetFileSystemType(@"0:\");
            Console.WriteLine("File System Type: " + fs_type);
            files_list = Directory.GetFiles(@"0:\");
            Directory.SetCurrentDirectory(IO.path);
            
            Program.running = true;
            Shell.Prep();
            Console.Clear();
        }
        /// <summary>
        /// Run the microCMDB OS. main kernel loop.
        /// </summary>
        protected override void Run()
        {
            

            // While microCMDB.CLI.Running is true, run the CLI
            while (Program.running == true)
            {
                try
                {
                    Shell.ucmdbOS = true;
                    Shell.CLI();
                    switch (Shell.OScmd)
                    {
                        case "dir":
                            files_list = Directory.GetFiles(@"0:\");
                            foreach (var file in files_list)
                            {
                                Console.WriteLine(file);
                            }
                            break;
                        case "exit":
                            Program.running = false;
                            break;
                        default:
                            break;
                    }
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
