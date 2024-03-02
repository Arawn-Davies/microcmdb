﻿using System.ComponentModel.DataAnnotations;

namespace microcmdb.Models
{
    public class Service
    {
        [Key]
        [Display(Name = "Service ID")]
        public int ServiceID { get; set; }

        [Required]
        [Display(Name = "Service Protocol")]
        public string Protocol { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Location")]
        public string URL { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Port Number")]
        public int PortNum{ get; set; }

        public Host? Host { get; set; }
        public int? HostID { get; set; }
    }
}
