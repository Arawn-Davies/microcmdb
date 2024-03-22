/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Model class to represent NetworkUsers in the microCMDB backend.

using System.ComponentModel.DataAnnotations;

namespace microcmdb.common.Models
{
    public class NetworkUser : Entity
    {
        [Key]
        [Display(Name = "User ID")]
        public int NetworkUserID { get; set; }

        public override string DbTagPrefix => "USR";

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
