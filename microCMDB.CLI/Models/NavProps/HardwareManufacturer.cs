using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace microCMDB.CLI.Models.NavProps
{
    public class HardwareManufacturer : Entity
    {
        public override string DbTagPrefix => "SDE";
        public HardwareManufacturer() : base()
        {
            Db.CurrentDbContext.HardwareManufacturers.Add(this);
        }
        public Manufacturer Manufacturer { get; set; }
        public Node Node { get; set; }
        public int ManufacturerID { get; set; }
        public int NodeID { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Manufacturer:\t" + Manufacturer.Name);
            Console.WriteLine("Model:\t" + Node.Modelname);
        }

        public override string ExportObject()
        {
            // Return a string representation of the SoftwareInstallation object containing every property
            return $"{Id},{DbTag},{Name},{Description},{CreatedDate},{ModifiedDate},{ManufacturerID},{NodeID}";
        }
    }
}
