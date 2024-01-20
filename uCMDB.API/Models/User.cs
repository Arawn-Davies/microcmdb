using System.ComponentModel.DataAnnotations;

namespace uCMDB.API.Models
{
    public class User
    {
        [Key]
        [Display(Name = "User ID")]
        public int User_ID { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string User_Name { get; set; }

        [Required]
        [Display(Name = "User Password")]
        public string User_passwd { get; set;}

        public int? Service_HostID { get; set; }
        public Service_Host? Service_Host { get; set; }
    }
}
