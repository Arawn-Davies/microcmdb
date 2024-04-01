/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Model class to represent NetworkUser/Node mappings in the microCMDB backend.

namespace microCMDB.CLI.Models
{
    public class NetworkUserMapping : Entity
    {
        public override string DbTagPrefix => "NUM";

        public NetworkUserMapping() : base()
        {
            Db.CurrentDbContext.NetworkUserMappings.Add(this);
        }

        public Node Node { get; set; }
        public NetworkUser NetworkUser { get; set; }
        public int NodeID { get; set; }
        public int NetworkUserID { get; set; }

        public override string ExportObject()
        {
            // Return a string representation of the NetworkUserMapping object containing every property
            return $"NetworkUserMapping,{Id},{DbTag},{Name},{Description},{CreatedDate},{ModifiedDate},{NodeID},{NetworkUserID}";
        }

    }
}
