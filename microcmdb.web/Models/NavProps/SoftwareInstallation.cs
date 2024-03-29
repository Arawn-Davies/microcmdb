﻿using System.ComponentModel.DataAnnotations;

namespace microcmdb.Web.Models
{
    public class SoftwareInstallation
    {
        public Node Node { get; set; }
        public Software Software { get; set; }
        public int NodeID { get; set; }
        public int SoftwareID { get; set; }
    }
}
