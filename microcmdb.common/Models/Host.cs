/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Model class to represent Hosts in the microCMDB backend.

using System.ComponentModel.DataAnnotations;

namespace microcmdb.common.Models
{
    public class Host : Entity
    {
        public Host() : base()
        {
            Db.CurrentDbContext.Hosts.Add(this);
        }

        // Host entity tag prefix
        public override string DbTagPrefix => "HST";

        // An optional field for the IP address of the node, if applicable
        public string? IPaddr { get; set; }

        public NodeHostMapping? NodeHostMapping { get; set; }

        public ICollection<HostServiceMapping> Services { get; set; } = new List<HostServiceMapping>();

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("IP Address:\t" + IPaddr);
            Console.WriteLine("Services:");
            foreach (var service in Services)
            {
                PrintInfo();
            }
            Console.WriteLine("=================================================");
        }
    }
}