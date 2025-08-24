using AspiriaTechnicalAssessment.Toys.Toys.Application.Dto;
using AspiriaTechnicalAssessment.Toys.Toys.Domain;

namespace AspiriaTechnicalAssessment.Toys.Toys.Application
{
    public class ToyApplication : IToyApplication
    {
        protected readonly IToyRepository _toyRepository;
        // TODO: Validators

        public ToyApplication(IToyRepository toyRepository)
        {
            _toyRepository = toyRepository;
        }

        public List<ToyDto> GetAll()
        {
            //return _toyRepository.GetAll();
            throw new NotImplementedException();
        }

        public ToyDto GetById(int id)
        {
            //return _toyRepository.GetById(id);
            throw new NotImplementedException();
        }

        public bool Insert(ToyDto dto)
        {
            Toy toy = MapToDomain(dto);
            return _toyRepository.Insert(toy);
        }

        public bool Update(ToyDto dto)
        {
            Toy toy = MapToDomain(dto);
            return _toyRepository.Update(toy);
        }

        public bool Delete(int id)
        {
            return _toyRepository.Delete(id);
        }

        private Toy MapToDomain(ToyDto dto)
        {
            return new Toy()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                AgeRestriction = dto.AgeRestriction,
                Company = dto.Company,
                Price = dto.Price
            };
        }
    }
}
