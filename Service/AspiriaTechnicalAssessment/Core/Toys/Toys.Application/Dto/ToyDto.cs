namespace AspiriaTechnicalAssessment.Core.Toys.Toys.Application.Dto
{
    public class ToyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AgeRestriction { get; set; } // TODO: accepted values from 0 to 100
        public string Company { get; set; }
        public double Price { get; set; } // TODO: accepted values from 1 to 1000
    }
}
