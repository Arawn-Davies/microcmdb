using System.ComponentModel.DataAnnotations;

namespace microcmdb.Models
{
    public class Host
    {
        [Key]
        [Display(Name = "Host ID")]
        public int Host_ID { get; set; }

        [Required]
        [Display(Name = "Hostname")]
        public string Host_Name { get; set; }

        [Required]
        [Display(Name = "IP Address")]
        public string Host_IP { get; set; }

        public ICollection<Service> Services { get; } = new List<Service>();
        public ICollection<Software> Software { get; } = new List<Software>();
        public ICollection<Node> NetworkNodes { get; } = new List<Node>();
        public ICollection<User> Users { get; } = new List<User>();
    }
}
