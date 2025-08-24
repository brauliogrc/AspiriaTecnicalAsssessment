using AspiriaTechnicalAssessment.Persistence;
using AspiriaTechnicalAssessment.Toys.Toys.Domain;

namespace AspiriaTechnicalAssessment.Toys.Toys.Interface
{
    public class ToyRepository : IToyRepository
    {
        protected readonly ApplicationDbContext _context;

        public ToyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Toy> GetAll()
        {
            var res = _context.Toys.ToList();
            if (res == null || !res.Any()) return new List<Toy>();
            return res;
        }

        public Toy GetById(int Id)
        {
            var res = _context.Toys.Find(Id);
            if (res == null) return null;
            return res;
        }

        public bool Insert(Toy toy)
        {
            _context.Toys.Add(toy);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Toy toy)
        {
            _context.Toys.Update(toy);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            _context.Toys.Remove(_context.Toys.Find(Id));
            _context.SaveChanges();
            return true;
        }
    }
}
