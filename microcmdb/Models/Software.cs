using System.ComponentModel.DataAnnotations;

namespace microcmdb.Models
{
    public class Software
    {
        [Key]
        [Display(Name = "Software ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Software Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Developer/Publisher")]
        public string Developer { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Licence Type")]
        public string LicenceType { get; set; } = string.Empty;
        
        [Display(Name = "Installation executable")]
        public string? InstallExecPath { get; set; }

        [Display(Name = "Installed on:")]
        public Host Host { get; set; } = new Host();
        [Display(Name = "Installed on:")]
        public int HostId { get; set; }

    }
}
