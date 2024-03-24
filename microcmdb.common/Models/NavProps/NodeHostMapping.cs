/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Model class to represent Node-Host mappings in the microCMDB backend.

namespace microcmdb.common.Models
{
    public class NodeHostMapping : Entity
    {
        public override string DbTagPrefix => "NHM";

        public NodeHostMapping() : base() 
        {
            Db.CurrentDbContext.NodeHostMappings.Add(this);
        }
        public Node Node { get; set; }
        public Host Host { get; set; }
        public int NodeID { get; set; }
        public int HostID { get; set; }
    }
}
