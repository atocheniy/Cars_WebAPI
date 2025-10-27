using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars_WebAPI.Models
{
    [Table("MyCar")]
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(5)]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Phone]
        public string Speed { get; set; }

        [Required]
        public int Price { get; set; }
        public int Data { get; set; }
        public int Weight { get; set; }


        [Display(Name = "Владелец")]
        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }
    }
}
