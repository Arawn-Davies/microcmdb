/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose: Model class to represent Nodes in the microCMDB backend.

using microCMDB.CLI.Util;
using System.ComponentModel.DataAnnotations;

namespace microCMDB.CLI.Models
{
    public class Node : Entity
    {
        public Node() : base()
        {
            if (CINodeMapping != null)
            {
                ConfigItemID = CINodeMapping.ConfigItemID;
            }
            else
            {
                ConfigItemID = 0;
            }
            Db.CurrentDbContext.Nodes.Add(this);
        }

        public Node(string oS_Version, string cPU_Arch, double rAM, double storage, int configItemID) : base()
        {
            OS_Version = oS_Version;
            CPU_Arch = cPU_Arch;
            RAM = rAM;
            Storage = storage;
            ConfigItemID = configItemID;
            Db.CurrentDbContext.Nodes.Add(this);
        }

        public override string DbTagPrefix => "NOD";

        // A required field for the model of the node
        [Required]
        [Display(Name = "Modelname")]
        public string Modelname { get; set; } = string.Empty;

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
        public double RAM { get; set; }
        
        // A required field for the amount of storage. This is a double to allow for decimal values as the default unit is gigabytes.
        [Display(Name = "Storage")]
        public double Storage { get; set; } 
        
        // A required field for which ConfigItem the node is associated with
        public int ConfigItemID { get; set; }
        [Display(Name = "Linked Configuration Item")]
        public CINodeMapping? CINodeMapping { get; set; }

        public NodeHostMapping? NodeHostMapping { get; set; }

        [Display(Name = "Installed Software")]
        public ICollection<SoftwareInstallation> InstalledSoftware { get; set; } = new List<SoftwareInstallation>();

        public ICollection<NetworkUserMapping>? NetworkUsers { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Table.PrintRow("OS Version:", OS_Version);
            Table.PrintRow("CPU Architecture:", CPU_Arch);
            if (RAM != null || RAM != 0) { Table.PrintRow("RAM", RAM.ToString()); } else { Table.PrintRow("RAM", "N/A"); }
            if (Storage != null || Storage != 0) { Table.PrintRow("Storage:", Storage.ToString()); } else { Table.PrintRow("Storage", "N/A"); }
        }

        public void PrintSoftware()
        {
            Table.PrintLine();
            Table.PrintRow("Installed Software:");
            foreach (var software in InstalledSoftware)
            {
                software.PrintInfo();
            }
            Table.PrintLine();
        }

        public override string ExportObject()
        {
            // Return a string representation of the ConfigItem object containing every property
            return $"{DbTag},{Name},{Description},{CreatedDate},{ModifiedDate},{OS_Version},{CPU_Arch},{RAM},{Storage},{ConfigItemID}";
        }
    }
}
