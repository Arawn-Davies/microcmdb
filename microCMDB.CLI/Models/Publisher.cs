/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose: Model class to represent Software in the microCMDB backend.

using microCMDB.CLI.Util;
using System.ComponentModel.DataAnnotations;

namespace microCMDB.CLI.Models
{
    public class Publisher : Entity
    {
        public Publisher() : base()
        {
            Db.CurrentDbContext.Publishers.Add(this);
        }

        public override string DbTagPrefix => "PUB";

        // An optional field for the year the publisher was founded
        [Display(Name = "Founding year")]
        public int FoundingYear { get; set; } = 1900;

        public override void PrintInfo()
        {
            base.PrintInfo();
            Table.PrintRow("Name:", Name);
            Table.PrintRow("Founded in:", FoundingYear.ToString()); 
        }
                

        public override string ExportObject()
        {
            // Return a string representation of the Software object containing every property
            return $"{DbTag},{Name},{FoundingYear}";
        }
    }
}