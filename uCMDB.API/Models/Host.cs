﻿using System.ComponentModel.DataAnnotations;

namespace uCMDB.API.Models
{
    public class Service_Host
    {
        [Key]
        public int Host_ID { get; set; }
        [Required]
        public string Host_Name { get; set; }
        [Required]
        public string Host_IP { get; set; }

        public ICollection<Service> Services { get; } = new List<Service>();
        public ICollection<Software> Software { get; } = new List<Software>();
        public ICollection<Service_Node> NetworkNodes { get; } = new List<Service_Node>();
        public ICollection<User> Users { get; } = new List<User>();
    }
}
