using System.ComponentModel.DataAnnotations;

namespace microcmdb.Models
{
    public class Node
    {
        // A unique identifier for the node
        [Key]
        [Display(Name = "Node ID")]
        public int NodeID { get; set; }
        
        // A required field for the name/description of the node
        [Required]
        [Display(Name = "Description")]
        public string Name { get; set; } = string.Empty;

        // A required field for the operating system version
        [Required]
        [Display(Name = "Operating System")]
        public string OS_Version { get; set; } = string.Empty;
        
        // A required field for the CPU architechture of the node
        [Required]
        [Display(Name = "CPU Architechture")]
        public string CPU_Arch { get; set; } = string.Empty;
        
        // A required field for the amount of RAM in megabytes
        [Display(Name = "RAM (MB)")]
        public double? RAM { get; set; }
        
        // A required field for the amount of storage in gigabytes
        [Display(Name = "Storage (GB)")]
        public double? Storage { get; set; } 
        
        // An optional field for the IP address of the node, if applicable
        [Display(Name = "IP Address")]
        public string? IPaddr { get; set; }

        // A required field for which ConfigItem the node is associated with
        [Display(Name = "Configuration Item")]
        public ConfigItem ConfigItem { get; set; }
        // A required field for the ConfigItemID
        public int ConfigItemID { get; set; }

        public Host? Host { get; set; }
        public int? HostID { get; set; }

        [Display(Name = "Installed Software")]
        public ICollection<NodeSoftwareMapping> InstalledSoftware { get; set; }

        public ICollection<NodeUserMapping>? Users { get; set; }
    }
}
