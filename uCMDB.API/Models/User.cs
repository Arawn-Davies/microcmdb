using System.ComponentModel.DataAnnotations;

namespace uCMDB.API.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }
    }
}
