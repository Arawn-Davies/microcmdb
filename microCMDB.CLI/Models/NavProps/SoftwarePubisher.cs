using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace microCMDB.CLI.Models.NavProps
{
    public class SoftwarePublisherMapping : Entity
    {
        public override string DbTagPrefix => "SWP";
        public SoftwarePublisherMapping() : base()
        {
            Db.CurrentDbContext.SoftwarePublisherMappings.Add(this);
        }
        public Publisher Publisher { get; set; }
        public Software Software { get; set; }
        public int PublisherID { get; set; }
        public int SoftwareID { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Publisher:\t" + Publisher.Name);
            Console.WriteLine("Software:\t" + Software.Name);
        }

        public override string ExportObject()
        {
            // Return a string representation of the SoftwareInstallation object containing every property
            return $"{Id},{DbTag},{Name},{Description},{CreatedDate},{ModifiedDate},{PublisherID},{SoftwareID}";
        }

    }
}
