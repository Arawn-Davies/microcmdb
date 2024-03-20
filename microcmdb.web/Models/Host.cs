using System.ComponentModel.DataAnnotations;

namespace microcmdb.Web.Models
{
    public class Host
    {
        [Key]
        [Display(Name = "Host ID")]
        public int HostID { get; set; }

        [Required]
        [Display(Name = "Hostname")]
        public string Name { get; set; } = string.Empty;

        public int? NodeId { get; set; }
        public Node Node { get; set; }

        public ICollection<Service> Services { get; set; } = new List<Service>();
    }
}