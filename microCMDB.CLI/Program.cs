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
        /// <summary>
        /// A boolean value to determine if the CLI is running.
        /// </summary>
        public static bool running = false;
        /// <summary>
        /// The main entry point for the microCMDB CLI application.
        /// </summary>
        private static void Main()
        {
            IO.path = Directory.GetCurrentDirectory();
            IO.Hosted = true;
            running = true;
            Shell.Prep();
            while (running == true)
            {
                Shell.CLI();
            }
            running = false;
        }

        
    }
}