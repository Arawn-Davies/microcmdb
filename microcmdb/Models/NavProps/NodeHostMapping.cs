﻿namespace microcmdb.Models
{
    public class NodeHostMapping
    {
        public Node Node { get; set; }
        public Host Host { get; set; }
        public int NodeID { get; set; }
        public int HostID { get; set; }
    }
}
