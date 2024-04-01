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
        public static bool running = false;
        private static void Main()
        {
            IO.path = Directory.GetCurrentDirectory() + Path.PathSeparator + "microCMDB";
            IO.Hosted = true;
            running = true;
            while (running == true)
            {
                Shell.CLI();
            }
            running = false;
        }

        
    }
}