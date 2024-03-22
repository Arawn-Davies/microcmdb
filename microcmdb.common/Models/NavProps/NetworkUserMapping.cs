/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Model class to represent NetworkUser/Node mappings in the microCMDB backend.

namespace microcmdb.common.Models
{
    public class NetworkUserMapping
    {
        public Node Node { get; set; }
        public NetworkUser NetworkUser { get; set; }
        public int NodeID { get; set; }
        public int NetworkUserID { get; set; }

    }
}
