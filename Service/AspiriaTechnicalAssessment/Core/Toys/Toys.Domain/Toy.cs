using System.ComponentModel.DataAnnotations;

namespace AspiriaTechnicalAssessment.Core.Toys.Toys.Domain
{
    public class Toy
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Name has a limit of 50 characters")]
        public string Name { get; set; }

        [MaxLength(100, ErrorMessage = "Description has a liminit of 100 characters")]
        public string Description { get; set; }

        [Range(0, 100, ErrorMessage = "Age range must be between 0 and 100")]
        public int AgeRestriction { get; set; }

        [MaxLength(50, ErrorMessage = "Company name couldn't be higher than 50 characters")]
        public string Company { get; set; }

        [Range(1, 1000, ErrorMessage = "A Toy couldn't has a price higher than 1000")]
        public double Price { get; set; }
    }
}
