using AspiriaTechnicalAssessment.Toys.Toys.Domain;
using Microsoft.EntityFrameworkCore;

namespace AspiriaTechnicalAssessment.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Toy> Toys { get; set; }
    }
}
