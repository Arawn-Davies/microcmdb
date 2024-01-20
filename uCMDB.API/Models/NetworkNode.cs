using System.ComponentModel.DataAnnotations;

namespace uCMDB.API.Models
{
    public class Service_Node
    {
        [Key]
        [Display(Name = "Node ID")]
        public int Node_Id { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Node_Name { get; set; }
        
        [Required]
        [Display(Name = "CPU Architecture")]
        public string Node_CPU_Arch { get; set; }
        
        [Required]
        [Display(Name = "RAM (MB)")]
        public int Node_RAM { get; set; }
        
        [Required]
        [Display(Name = "Storage (GB)")]
        public int Node_Storage { get; set; }
        
        [Required]
        [Display(Name = "Operating System")]
        public string Node_OS_Ver { get; set; }

    }
}
