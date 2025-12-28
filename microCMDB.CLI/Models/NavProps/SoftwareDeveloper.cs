using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microCMDB.CLI.Models.NavProps
{
    public class SoftwareDeveloper : Entity
    {
        public override string DbTagPrefix => "SDE";
        public SoftwareDeveloper() : base()
        {
            Db.CurrentDbContext.SoftwareDevelopers.Add(this);
        }
        public Developer Dev { get; set; }
        public Software Software { get; set; }
        public int DeveloperID { get; set; }
        public int SoftwareID { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Developer:\t" + Dev.Name);
            Console.WriteLine("Software:\t" + Software.Name);
        }

        public override string ExportObject()
        {
            // Return a string representation of the SoftwareInstallation object containing every property
            return $"{Id},{DbTag},{Name},{Description},{CreatedDate},{ModifiedDate},{DeveloperID},{SoftwareID}";
        }

    }
}
