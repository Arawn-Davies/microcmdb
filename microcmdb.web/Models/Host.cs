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

        public NodeHostMapping NodeHostMapping { get; set; }

        public ICollection<HostServiceMapping> HostServices { get; set; } = new List<HostServiceMapping>();
    }
}