﻿using System.ComponentModel.DataAnnotations;

namespace microcmdb.common.Models
{
    public class NetworkUser : Entity
    {
        [Key]
        [Display(Name = "User ID")]
        public int NetworkUserID { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; } = string.Empty;

        [Display(Name = "Email Address")]
        public string? Email { get; set;}

        [Display(Name = "First Name")]
        public string? Firstname { get; set; }

        [Display(Name = "Last Name")]
        public string? Lastname { get; set; }

        public ICollection<NetworkUserMapping> AllowedNodes { get; set; }

    }
}
