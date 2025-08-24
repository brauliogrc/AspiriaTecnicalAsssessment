namespace AspiriaTechnicalAssessment.Toys.Toys.Domain
{
    public interface IToyRepository
    {
        List<Toy> GetAll();
        Toy GetById(int Id);
        bool Insert(Toy toy);
        bool Update(Toy toy);
        bool Delete(int Id);
    }
}
