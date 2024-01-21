using System.ComponentModel.DataAnnotations;

namespace microcmdb.Models
{
    public class Service
    {
        [Key]
        [Display(Name = "Service ID")]
        public int Service_Id { get; set; }

        [Required]
        [Display(Name = "Protocol")]
        public string Service_Protocol { get; set; } = string.Empty;

        [Required]
        [Display(Name = "URL")]
        public string Service_URL { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Port")]
        public int Service_Port { get; set; }
    }
}
