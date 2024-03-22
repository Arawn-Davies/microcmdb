/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Model class for ConfigItem objects. Inherits from Entity class.

using System.ComponentModel.DataAnnotations;

namespace microcmdb.common.Models
{
    public class ConfigItem : Entity
    {
        /// <summary>
        /// A unique identifier for the ConfigItem
        /// </summary>
        [Key]
        public int ConfigItemID { get; set; }

        public override string DbTagPrefix => "CFG";
        
        /// <summary>
        /// An optional field for the date the ConfigItem was purchased
        /// </summary>
        [Display(Name = "Date purchased")]
        public DateTime? PurchaseDate { get; set; }

        /// <summary>
        /// An optional field for the date the ConfigItem was last updated
        /// </summary>
        [Display(Name = "Last updated")]
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// An optional field for any notes or comments about the ConfigItem in particular
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        ///  An optional field for the deployment location of the ConfigItem (e.g. datacenter, office, mobile etc.)
        /// </summary>
        [Display(Name = "Deployment location")]
        public string DeployLoc{ get; set; } = string.Empty;

        public CINodeMapping CINodeMapping { get; set; }

    }
}
