using System.ComponentModel.DataAnnotations;

namespace uCMDB.API.Models
{
    public class Software
    {
        [Key]
        public int Software_ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Developer { get; set; }

        public string LicenceType { get; set; }

        public string InstallExecPath { get; set; }

    }
}
