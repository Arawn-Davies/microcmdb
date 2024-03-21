using System.ComponentModel.DataAnnotations;

namespace microcmdb.common.Models
{
    public class Service
    {
        [Key]
        [Display(Name = "Service ID")]
        public int ServiceID { get; set; }

        [Required]
        [Display(Name = "Service Protocol")]
        public string Protocol { get; set; } = string.Empty;

        [Display(Name = "Location")]
        public string? URL()
        {
            if (HostServiceMapping != null && HostServiceMapping.Host != null)
            {
                return HostServiceMapping.Host.IPaddr;
            }
            return string.Empty;
        }

        [Required]
        [Display(Name = "Port Number")]
        public int PortNum{ get; set; }

        public int? HostId { get; set; }
        public HostServiceMapping? HostServiceMapping { get; set; }
        
    }
}
