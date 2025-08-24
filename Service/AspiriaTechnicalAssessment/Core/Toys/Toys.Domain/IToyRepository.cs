namespace AspiriaTechnicalAssessment.Core.Toys.Toys.Domain
{
    public interface IToyRepository
    {
        List<Toy> GetAll();
        Toy GetById(int Id);
        bool Insert(Toy toy);
        bool Update(Toy toy);
        bool Delete(Toy toy);
    }
}
