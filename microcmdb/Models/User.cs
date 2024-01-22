using System.ComponentModel.DataAnnotations;

namespace microcmdb.Models
{
    public class User
    {
        [Key]
        [Display(Name = "User ID")]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [Display(Name = "User Password")]
        public string Passwd { get; set;} = string.Empty;

        public ICollection<Host> Hosts { get; } = new List<Host>();

    }
}
