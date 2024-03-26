/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Model class to represent NetworkUsers in the microCMDB backend.

using System.ComponentModel.DataAnnotations;

namespace microCMDB.common.Models
{
    public class NetworkUser : Entity
    {
        public NetworkUser() : base()
        {
            Db.CurrentDbContext.NetworkUsers.Add(this);
        }

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

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Username:\t" + Username);
            Console.WriteLine("Email:\t" + Email);
            Console.WriteLine("First Name:\t" + Firstname);
            Console.WriteLine("Last Name:\t" + Lastname);
        }

        public override string ExportObject()
        {
            // Return a string representation of the NetworkUser object containing every property
            return $"NetworkUser,{Id},{DbTag},{Username},{Email},{Firstname},{Lastname}";
        }

    }
}
