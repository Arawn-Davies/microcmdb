using System.ComponentModel.DataAnnotations;

namespace microcmdb.Models
{
    public class Software
    {
        // A unique identifier for the software
        [Key]
        [Display(Name = "Software ID")]
        public int SoftwareID { get; set; }

        // A required field for the title of the software
        [Required]
        [Display(Name = "Software Title")]
        public string Name { get; set; } = string.Empty;

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

        public NodeSoftwareMapping? NodeSoftwareMapping { get; set; }
    }
}