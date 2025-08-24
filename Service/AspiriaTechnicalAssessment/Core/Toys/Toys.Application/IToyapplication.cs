using AspiriaTechnicalAssessment.Core.Toys.Toys.Application.Dto;
using AspiriaTechnicalAssessment.Core.Transversal.Common;

namespace AspiriaTechnicalAssessment.Core.Toys.Toys.Application
{
    public interface IToyApplication
    {
        Response<List<ToyDto>> GetAll();
        Response<ToyDto> GetById(int id);
        Response<bool> Insert(ToyDto dto);
        Response<bool> Update(ToyDto dto);
        Response<bool> Delete(int id);
    }
}