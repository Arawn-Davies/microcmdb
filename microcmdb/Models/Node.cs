using System.ComponentModel.DataAnnotations;

namespace microcmdb.Models
{
    public class Node
    {
        [Key]
        [Display(Name = "Node ID")]
        public int Id { get; set; } 

        [Required]
        [Display(Name = "Description")]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "CPU Architecture")]
        public string CPU_Arch { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "RAM (MBs)")]
        public int RAM { get; set; }
        
        [Required]
        [Display(Name = "Storage (GBs)")]
        public int Storage { get; set; } 
        
        [Required]
        [Display(Name = "Operating System")]
        public string OS_Version { get; set; } = string.Empty;

    }
}
