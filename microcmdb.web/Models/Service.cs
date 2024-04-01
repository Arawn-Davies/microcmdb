using System.ComponentModel.DataAnnotations;

namespace microCMDB.Web.Models
{
    public class Service
    {
        [Key]
        [Display(Name = "Service ID")]
        public int ServiceID { get; set; }

        [Required]
        [Display(Name = "Service Protocol")]
        public string Protocol { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Location")]
        public string URL { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Port Number")]
        public int PortNum{ get; set; }

        public int? HostId { get; set; }
        public Host Host { get; set; }
        
    }
}
