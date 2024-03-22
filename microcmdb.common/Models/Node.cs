/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose: Model class to represent Nodes in the microCMDB backend.

using System.ComponentModel.DataAnnotations;

namespace microcmdb.common.Models
{
    public class Node : Entity
    {
        // A unique identifier for the node
        [Key]
        [Display(Name = "Node ID")]
        public int NodeID { get; set; }

        public override string DbTagPrefix => "NOD";

        // A required field for the operating system version
        [Required]
        [Display(Name = "Operating System")]
        public string OS_Version { get; set; } = string.Empty;
        
        // A required field for the CPU architechture of the node
        [Required]
        [Display(Name = "CPU Architechture")]
        public string CPU_Arch { get; set; } = string.Empty;
        
        // A required field for the amount of RAM. This is a double to allow for decimal values as the default unit is megabytes.
        [Display(Name = "RAM")]
        public double? RAM { get; set; }
        
        // A required field for the amount of storage. This is a double to allow for decimal values as the default unit is gigabytes.
        [Display(Name = "Storage")]
        public double? Storage { get; set; } 
        
        // A required field for which ConfigItem the node is associated with
        public int? ConfigItemID { get; set; }
        [Display(Name = "Linked Configuration Item")]
        public CINodeMapping? CINodeMapping { get; set; }

        public NodeHostMapping? NodeHostMapping { get; set; }

        [Display(Name = "Installed Software")]
        public ICollection<SoftwareInstallation> InstalledSoftware { get; set; } = new List<SoftwareInstallation>();

        public ICollection<NetworkUserMapping>? NetworkUsers { get; set; }
    }
}
