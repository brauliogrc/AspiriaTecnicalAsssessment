using AspiriaTechnicalAssessment.Toys.Toys.Application.Dto;

namespace AspiriaTechnicalAssessment.Toys.Toys.Application
{
    public interface IToyApplication
    {
        List<ToyDto> GetAll();
        ToyDto GetById(int id);
        bool Insert(ToyDto dto);
        bool Update(ToyDto dto);
        bool Delete(int id);
    }
}
