/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose: Model class to represent Pulishers in the microCMDB backend.

using microCMDB.CLI.Util;
using System.ComponentModel.DataAnnotations;

namespace microCMDB.CLI.Models
{
    public class Manufacturer : Entity
    {
        public Manufacturer() : base()
        {
            Db.CurrentDbContext.Manufacturers.Add(this);
        }

        public override string DbTagPrefix => "MAN";

        // A required field for the specific version of the software that is installed.
        [Required]
        [Display(Name = "Founded in:")]
        public int FoundingYear { get; set; } = 0;

        public override void PrintInfo()
        {
            base.PrintInfo();
            Table.PrintRow("Name:", Name);
            Table.PrintRow("Founded in:", FoundingYear.ToString());
        }

        public override string ExportObject()
        {
            // Return a string representation of the Software object containing every property
            return $"{DbTag},{Name}";
        }
    }
}