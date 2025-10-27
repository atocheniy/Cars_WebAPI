using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars_WebAPI.Models
{
    [Table("MyOwner")]
    public class Owner
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(5)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
