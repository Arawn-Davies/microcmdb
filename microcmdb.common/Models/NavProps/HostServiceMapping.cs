/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Model class to represent Host/Service mappings in the microCMDB backend.
namespace microCMDB.common.Models
{
    public class HostServiceMapping : Entity
    {
        public override string DbTagPrefix => "HSM";

        public HostServiceMapping() : base()
        {
            Db.CurrentDbContext.HostServiceMappings.Add(this);
        }

        public Host? Host { get; set; }
        
        public Service? Service { get; set; }
        
        public int HostID { get; set; }
        
        public int ServiceID { get; set; }


        public override string ExportObject()
        {
            // Return a string representation of the HostServiceMapping object containing every property
            return $"HostServiceMapping,{Id},{DbTag},{Name},{Description},{CreatedDate},{ModifiedDate},{HostID},{ServiceID}";
        }
    }
}
