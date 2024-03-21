using System.ComponentModel.DataAnnotations;

namespace microcmdb.common.Models
{
    public class Host
    {
        [Key]
        [Display(Name = "Host ID")]
        public int HostID { get; set; }

        [Required]
        [Display(Name = "Hostname")]
        public string Name { get; set; } = string.Empty;

        // An optional field for the IP address of the node, if applicable
        [Display(Name = "IP Address")]
        public string? IPaddr { get; set; }

        public NodeHostMapping? NodeHostMapping { get; set; }

        public ICollection<HostServiceMapping> Services { get; set; } = new List<HostServiceMapping>();
    }
}