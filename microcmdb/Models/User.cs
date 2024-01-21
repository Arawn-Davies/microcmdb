using System.ComponentModel.DataAnnotations;

namespace microcmdb.Models
{
    public class User
    {
        [Key]
        [Display(Name = "User ID")]
        public int User_ID { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string User_Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "User Password")]
        public string User_passwd { get; set;} = string.Empty;

    }
}
