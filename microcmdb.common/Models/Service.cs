/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose: Model class to represent Services in the microCMDB backend.

using System.ComponentModel.DataAnnotations;

namespace microcmdb.common.Models
{
    public class Service : Entity
    {
        [Key]
        [Display(Name = "Service ID")]
        public int ServiceID { get; set; }

        public override string DbTagPrefix => "SVC";

        [Required]
        [Display(Name = "Service Protocol")]
        public string Protocol { get; set; } = string.Empty;

        [Display(Name = "Location")]
        public string? URL()
        {
            if (HostServiceMapping != null && HostServiceMapping.Host != null)
            {
                return HostServiceMapping.Host.IPaddr;
            }
            return string.Empty;
        }

        [Required]
        [Display(Name = "Port Number")]
        public int PortNum{ get; set; }

        public int? HostId { get; set; }
        public HostServiceMapping? HostServiceMapping { get; set; }
        
    }
}
