using System.ComponentModel.DataAnnotations;

namespace uCMDB.API.Models
{
    public class Service_Node
    {
        [Key]
        public int Node_Id { get; set; }
        [Required]
        public string Node_Name { get; set; }
        [Required]
        public string Node_CPU_Arch { get; set; }
        [Required]
        public int Node_RAM { get; set; }
        [Required]
        public int Node_Storage { get; set; }
        [Required]
        public string Node_OS_Ver { get; set; }

    }
}
