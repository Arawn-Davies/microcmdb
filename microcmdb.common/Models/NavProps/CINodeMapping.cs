/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Model class to represent ConfigItem/Node mappings in the microCMDB backend.
namespace microcmdb.common.Models
{
    public class CINodeMapping
    {
        public ConfigItem ConfigItem { get; set; }
        public Node Node { get; set; }
        public int ConfigItemID { get; set; }
        public int NodeID { get; set; }

    }
}
