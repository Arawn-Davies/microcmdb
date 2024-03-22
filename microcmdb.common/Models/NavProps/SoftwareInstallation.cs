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
    public class SoftwareInstallation
    {
        public Node Node { get; set; }
        public Software Software { get; set; }
        public int NodeID { get; set; }
        public int SoftwareID { get; set; }
    }
}
