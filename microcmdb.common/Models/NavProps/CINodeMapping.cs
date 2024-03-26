/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Model class to represent ConfigItem/Node mappings in the microCMDB backend.
namespace microCMDB.common.Models
{
    public class CINodeMapping : Entity
    {
        public override string DbTagPrefix => "CIN";
        public CINodeMapping() : base() 
        {
            Db.CurrentDbContext.CINodeMappings.Add(this);
        }

        public ConfigItem ConfigItem { get; set; }
        public Node Node { get; set; }
        public int ConfigItemID { get; set; }
        public int NodeID { get; set; }


        public override string ExportObject()
        {
            // Return a string representation of the CINodeMapping object containing every property
            return $"CINodeMapping,{Id},{DbTag},{Name},{Description},{CreatedDate},{ModifiedDate},{ConfigItemID},{NodeID}";
        }

    }
}
