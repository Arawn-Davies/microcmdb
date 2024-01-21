using System.ComponentModel.DataAnnotations;

namespace microcmdb.Models
{
    public class Software
    {
        [Key]
        [Display(Name = "Software ID")]
        public int Software_ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Developer/Publisher")]
        public string Developer { get; set; }

        [Required]
        [Display(Name = "Licence Type")]
        public string LicenceType { get; set; }
        
        [Display(Name = "Installation executable")]
        public string? InstallExecPath { get; set; }

    }
}
