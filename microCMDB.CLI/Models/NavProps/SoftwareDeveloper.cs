using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microCMDB.CLI.Models.NavProps
{
    public class SoftwareDeveloperMapping : Entity
    {
        public override string DbTagPrefix => "SDE";
        public SoftwareDeveloperMapping() : base()
        {
            Db.CurrentDbContext.SoftwareDeveloperMappings.Add(this);
        }
        public Developer Developer { get; set; }
        public Software Software { get; set; }
        public int DeveloperID { get; set; }
        public int SoftwareID { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Developer:\t" + Developer.Name);
            Console.WriteLine("Software:\t" + Software.Name);
        }

        public override string ExportObject()
        {
            // Return a string representation of the SoftwareInstallation object containing every property
            return $"{Id},{DbTag},{Name},{Description},{CreatedDate},{ModifiedDate},{DeveloperID},{SoftwareID}";
        }

    }
}
