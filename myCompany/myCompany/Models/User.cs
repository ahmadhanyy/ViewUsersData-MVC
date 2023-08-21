using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace myCompany.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
