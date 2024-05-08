/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Utility class for formatting output to the console in a table format.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microCMDB.CLI.Util
{
    internal class Table
    {
        // The width of the table, set to 79 characters for safe viewing on ASCII 80x25 terminals (microCMDB.OS uses text mode VGA)
        static int tableWidth = 79;

        // Prints an example table with 4 columns and 2 rows to the console.
        public static void Example()
        {
            PrintLine();
            PrintRow("Column 1", "Column 2", "Column 3", "Column 4");
            PrintLine();
            PrintRow("Example1", "Example2", "Example3", "Example4");
            PrintRow("Example5", "Example6", "Example7", "Example8");
            PrintLine();
        }

        // Print a line of '-' characters of the specified table width to the console.
        public static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public static void PrintRow(params string[] columns)
        {
            // Calculate the width of each column based on the table width.
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";
            // Loop through each column in the columns array.
            foreach (string column in columns)
            {
                // Add the column to the row, aligned to the centre of the cell.
                row += AlignCentre(column, width) + "|";
            }
            // Print the row to the console.
            Console.WriteLine(row);
        }

        /// <summary>
        /// Aligns text to the centre of a given width.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static string AlignCentre(string text, int width)
        {
            // If the text is greater than the width, truncate it to 'width - 3' and add ',,,' to the end.
            // Reassign the text variable to the new value.
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            // if the string is empty or null, return a string of spaces of the given width.
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                // Compare the width of the text to the given width.
                // If the width of the text is less than the given width, then split the difference between the two.
                // Then pad the text to the right and left of the text, and return.
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
