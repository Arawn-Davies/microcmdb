/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose: Model class to represent Developers in the microCMDB backend.

using microCMDB.CLI.Util;
using System.ComponentModel.DataAnnotations;

namespace microCMDB.CLI.Models
{
    public class Developer : Entity
    {
        public Developer() : base()
        {
            Db.CurrentDbContext.Developers.Add(this);
        }

        public override string DbTagPrefix => "DEV";

        // An optional field for the year the publisher was founded
        [Display(Name = "Founding year")]
        public int FoundingYear { get; set; } = 1900;

        public override void PrintInfo()
        {
            base.PrintInfo();
            Table.PrintRow("Founded in:", FoundingYear.ToString());
        }

        public override string ExportObject()
        {
            // Return a string representation of the Software object containing every property
            return $"{DbTag},{Name},{FoundingYear}";
        }
    }
}