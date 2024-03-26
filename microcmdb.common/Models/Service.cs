/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose: Model class to represent Services in the microCMDB backend.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace microcmdb.common.Models
{
    public class Service : Entity
    {
        public Service() : base() 
        {
            Db.CurrentDbContext.Services.Add(this);
        }
        // This method could take multiple forms (Dictionary<int,string>, switch/case, but the current implementation
        // is a simple if/else statement to return the correct URI prefix based on the port number. It could be improved by allowing methods for adding custom service types.
        private string URI_PREFIX 
        {
            get
            {
                return Protocol.ToLower() + "://";
            }
        }

        public override string DbTagPrefix => "SVC";

        [Required]
        [Display(Name = "Service Protocol")]
        public string Protocol 
        {
            get
            {
                if (PortNum == 80)
                {
                    return "HTTP";
                }
                else if (PortNum == 443)
                {
                    return "HTTPS";
                }
                else if (PortNum == 22)
                {
                    return "SSH";
                }
                else if (PortNum == 21)
                {
                    return "FTP";
                }
                else if (PortNum == 25)
                {
                    return "SMTP";
                }
                else if (PortNum == 25565)
                {
                    return "Minecraft";
                }
                else
                {
                    return "N/A";
                }
            }
        }

        [Display(Name = "Location")]
        public string URL()
        {
            // Return the URL based on the associated host's IP address and the port number
            return URI_PREFIX + HostServiceMapping?.Host?.IPaddr + ":" + PortNum;
            

        }

        [Required]
        [Display(Name = "Port Number")]
        public int PortNum{ get; set; }

        public int? HostId { get; set; }
        public HostServiceMapping? HostServiceMapping { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Port:\t\t\t" + PortNum);
            Console.WriteLine("Protocol:\t\t" + Protocol);
            Console.WriteLine("URL:\t\t\t" + URL());
        }

        public override string ExportObject()
        {
            // Return a string representation of the Service object containing every property
            return $"Service,{Id},{DbTag},{Name},{Description},{CreatedDate},{ModifiedDate},{PortNum},{Protocol},{HostId}";
        }
    }
}
