/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Model class to represent Host/Service mappings in the microCMDB backend.
namespace microcmdb.common.Models
{
    public class HostServiceMapping
    {
        public Host Host { get; set; }
        public Service Service { get; set; }
        public int HostID { get; set; }
        public int ServiceID { get; set; }
    }
}
