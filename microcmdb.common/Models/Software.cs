/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose: Model class to represent Software in the microCMDB backend.

using System.ComponentModel.DataAnnotations;

namespace microcmdb.common.Models
{
    public class Software : Entity
    {
        public Software() : base()
        {
            Db.CurrentDbContext.Software.Add(this);
        }

        public override string DbTagPrefix => "STW";

        // A required field for the specific version of the software that is installed.
        [Required]
        [Display(Name = "Software Version")]
        public string Version { get; set; } = string.Empty;

        // An optional field for the developer or publisher of the software
        [Display(Name = "Developer")]
        public string? Developer { get; set; }

        // An optional field for the type of license
        [Display(Name = "License Type")]
        public string? LicenseType { get; set; }

        [Display(Name = "Installed On")]
        public ICollection<SoftwareInstallation> Installations { get; set; } = new List<SoftwareInstallation>();

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Version:\t" + Version);
            Console.WriteLine("Developer:\t" + Developer);
            Console.WriteLine("License Type:\t" + LicenseType);
            Console.WriteLine("Installed On:");
            foreach (var installation in Installations)
            {
                Console.WriteLine(installation.Node.Name);
            }
            Console.WriteLine("=================================================");
        }
    }
}