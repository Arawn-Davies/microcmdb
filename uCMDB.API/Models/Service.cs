using System.ComponentModel.DataAnnotations;

namespace uCMDB.API.Models
{
    public class Service
    {
        [Key]
        public int Service_Id { get; set; }

        [Required]
        public string Service_Protocol { get; set; }

        [Required]
        public string Service_Port { get; set; }

        [Required]
        public string Service_URL { get; set; }
    }
}
