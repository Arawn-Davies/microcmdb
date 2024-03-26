/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Model class for ConfigItem objects. Inherits from Entity class.

using microcmdb.common.Util;
using System.ComponentModel.DataAnnotations;

namespace microcmdb.common.Models
{
    public class ConfigItem : Entity
    {
        public ConfigItem() : base()
        {
            Db.CurrentDbContext.ConfigItems.Add(this);
        }

        /// <summary>
        /// Overrides the DbTagPrefix property in the Entity class to set the prefix for ConfigItem objects
        /// </summary>
        public override string DbTagPrefix => "CFG";
        
        /// <summary>
        /// An optional field for the date the ConfigItem was purchased
        /// </summary>
        [Display(Name = "Date purchased")]
        public DateTime? PurchaseDate { get; set; }

        /// <summary>
        ///  An optional field for the deployment location of the ConfigItem (e.g. datacenter, office, mobile etc.)
        /// </summary>
        [Display(Name = "Deployment location")]
        public string DeployLoc{ get; set; } = string.Empty;

        public CINodeMapping CINodeMapping { get; set; }

        /// <summary>
        /// Print the ConfigItem's information to the console
        /// </summary>
        public override void PrintInfo()
        {
            base.PrintInfo();
            Table.PrintRow("Purchase date:", PurchaseDate.ToString());
            Table.PrintRow("Deployed:", DeployLoc);
        }

        public override string ExportObject()
        {
            // Return a string representation of the ConfigItem object containing every property
            return $"ConfigItem,{Id},{DbTag},{Name},{Description},{CreatedDate},{ModifiedDate},{PurchaseDate},{DeployLoc}";
        }

    }
}
