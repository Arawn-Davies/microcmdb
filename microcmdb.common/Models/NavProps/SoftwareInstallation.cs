/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Model class to represent Software Installations in the microCMDB backend.

using System.ComponentModel.DataAnnotations;

namespace microcmdb.common.Models
{
    public class SoftwareInstallation : Entity
    {
        public override string DbTagPrefix => "SWI";
        public SoftwareInstallation() : base() 
        {
            Db.CurrentDbContext.SoftwareInstallations.Add(this);
        }
        public Node Node { get; set; }
        public Software Software { get; set; }
        public int NodeID { get; set; }
        public int SoftwareID { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Node:\t" + Node.Name);
            Console.WriteLine("Software:\t" + Software.Name);
            Console.WriteLine("=================================================");
        }
    }
}
