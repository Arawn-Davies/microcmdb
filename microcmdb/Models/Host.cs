using System.ComponentModel.DataAnnotations;

namespace microcmdb.Models
{
    public class Host
    {
        [Key]
        [Display(Name = "Host ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Hostname")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public Node Node { get; set; } = new Node();
        [Required]
        public int NodeId { get; set; }

        public IList<User> Users { get; set; } = new List<User>();
        public IList<Service> Services { get; } = new List<Service>();      
        public IList<Software> Software { get; } = new List<Software>();    }
}
