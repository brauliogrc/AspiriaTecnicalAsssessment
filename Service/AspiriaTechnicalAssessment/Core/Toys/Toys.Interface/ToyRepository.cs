using AspiriaTechnicalAssessment.Core.Persistence;
using AspiriaTechnicalAssessment.Core.Toys.Toys.Application.Dto;
using AspiriaTechnicalAssessment.Core.Toys.Toys.Domain;

namespace AspiriaTechnicalAssessment.Core.Toys.Toys.Interface
{
    public class ToyRepository : IToyRepository
    {
        protected readonly ApplicationDbContext _context;

        public ToyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Select all toys from database
        /// </summary>
        /// <returns></returns>
        public List<Toy> GetAll()
        {
            var res = _context.Toys.OrderBy(x => x.Id).ToList();
            if (res == null || !res.Any()) return new List<Toy>();
            return res;
        }

        /// <summary>
        /// Select a toy by id from database
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Toy GetById(int Id)
        {
            var res = _context.Toys.Find(Id);
            if (res == null) return null;
            return res;
        }

        /// <summary>
        /// Insert a new toy in database
        /// </summary>
        /// <param name="toy">Etitty Toy object</param>
        /// <returns></returns>
        public bool Insert(Toy toy)
        {
            _context.Toys.Add(toy);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Update existing toy in database
        /// </summary>
        /// <param name="toy">Entity Toy object</param>
        /// <returns></returns>
        public bool Update(Toy toy)
        {
            _context.Toys.Update(toy);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Delete existing toy in database
        /// </summary>
        /// <param name="Id">Toy id</param>
        /// <returns></returns>
        public bool Delete(Toy toy)
        {
            _context.Toys.Remove(toy);
            _context.SaveChanges();
            return true;
        }
    }
}
