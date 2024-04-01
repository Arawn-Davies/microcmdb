using System.ComponentModel.DataAnnotations;

namespace microCMDB.Web.Models
{
    public class ConfigItem
    {
        /// <summary>
        /// A unique identifier for the ConfigItem
        /// </summary>
        [Key]
        public int ConfigItemID { get; set; }

        /// <summary>
        /// A required field for the name of the ConfigItem
        /// </summary>
        [Display(Name = "Config Tag")]
        [Required]
        public string Name { get; set; } = string.Empty;

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

        public Node? Node { get; set; }

    }
}
