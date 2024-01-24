using System.ComponentModel.DataAnnotations;

namespace microcmdb.Models
{
    public class Software
    {
        // A unique identifier for the software
        [Key]
        [Display(Name = "Software ID")]
        public int Id { get; set; }

        // A required field for the name of the software
        [Required]
        [Display(Name = "Software Name")]
        public string Name { get; set; } = string.Empty;

        // A required field for the specific version of the software that is installed.
        [Required]
        [Display(Name = "Software Version")]
        public string Version { get; set; } = string.Empty;

        // An optional field for the developer or publisher of the software
        [Required]
        [Display(Name = "Developer/Publisher")]
        public string? Developer { get; set; }

        // An optional field for the type of license
        [Display(Name = "License Type")]
        public string? LicenseType { get; set; }

        // An optional field for which Node the software is installed on
        [Display(Name = "Node")]
        public Node? Node { get; set; }
        // An optional field for the NodeId
        public int? NodeId { get; set; }

    }
}
