using System.ComponentModel.DataAnnotations;

namespace AspiriaTechnicalAssessment.Toys.Toys.Domain
{
    public class Toy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public int AgeRestriction { get; set; } // TODO: accepted values from 0 to 100

        [MaxLength(50)]
        public string Company { get; set; }

        public double Price { get; set; } // TODO: accepted values from 1 to 1000
    }
}
