using AspiriaTechnicalAssessment.Core.Persistence;
using AspiriaTechnicalAssessment.Core.Toys.Toys.Domain;

namespace AspiriaTechnicalAssessment.Modules.DataInitializer
{
    public static class DataInitializer
    {
        /// <summary>
        /// Initialize data in database
        /// </summary>
        /// <param name="context"></param>
        public static void LoadData(ApplicationDbContext context)
        {
            if (!context.Toys.Any())
            {
                context.Toys.AddRange(ToysGenerator());
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Generate a list of toys
        /// </summary>
        /// <returns></returns>
        private static List<Toy> ToysGenerator()
        {
            List<Toy> toys = new List<Toy>();
            foreach (int i in Enumerable.Range(1, 10))
            {
                toys.Add(new Toy
                {
                    Name = $"Toy {i}",
                    Description = $"This is the description for toy {i}",
                    AgeRestriction = i * 2,
                    Company = $"Company {i}",
                    Price = i * 10
                });
            };
            return toys;
        }
    }
}
