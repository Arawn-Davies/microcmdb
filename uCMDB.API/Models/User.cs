using System.ComponentModel.DataAnnotations;

namespace uCMDB.API.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }

        [Required]
        public string User_Name { get; set; }

        [Required]
        public string User_passwd { get; set;}
    }
}
