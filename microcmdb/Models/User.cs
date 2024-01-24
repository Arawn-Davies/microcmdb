using System.ComponentModel.DataAnnotations;

namespace microcmdb.Models
{
    public class User
    {
        [Key]
        [Display(Name = "User ID")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; } = string.Empty;

        [Display(Name = "Email Address")]
        public string? Email { get; set;}

        [Display(Name = "First Name")]
        public string? Firstname { get; set; }

        [Display(Name = "Last Name")]
        public string? Lastname { get; set; }

    }
}
