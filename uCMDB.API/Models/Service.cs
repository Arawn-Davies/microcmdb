using System.ComponentModel.DataAnnotations;

namespace uCMDB.API.Models
{
    public class Service
    {
        [Key]
        [Display(Name = "Service ID")]
        public int Service_Id { get; set; }

        [Required]
        [Display(Name = "Protocol")]
        public string Service_Protocol { get; set; }

        [Required]
        [Display(Name = "Port")]
        public string Service_Port { get; set; }

        [Required]
        [Display(Name = "URL")]
        public string Service_URL { get; set; }
    }
}
