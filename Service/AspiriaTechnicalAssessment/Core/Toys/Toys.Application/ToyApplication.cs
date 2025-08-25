using AspiriaTechnicalAssessment.Core.Toys.Toys.Application.Dto;
using AspiriaTechnicalAssessment.Core.Toys.Toys.Application.Validators;
using AspiriaTechnicalAssessment.Core.Toys.Toys.Domain;
using AspiriaTechnicalAssessment.Core.Transversal.Common;
using Mapster;

namespace AspiriaTechnicalAssessment.Core.Toys.Toys.Application
{
    public class ToyApplication : IToyApplication
    {
        protected readonly IToyRepository _toyRepository;

        public ToyApplication(IToyRepository toyRepository)
        {
            _toyRepository = toyRepository;
        }

        /// <summary>
        /// Restreive all toys from repository
        /// </summary>
        /// <returns></returns>
        public Response<List<ToyDto>> GetAll()
        {
            var response = new Response<List<ToyDto>>();
            try
            {
                var toys = _toyRepository.GetAll();
                if (!toys.Any()) throw new Exception("No toys found");
                response.Data = toys.Adapt<List<ToyDto>>();
                response.IsSuccess = true;
                response.Message = "Toys retrieved successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Retreive a toy by id from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Response<ToyDto> GetById(int id)
        {
            var response = new Response<ToyDto>();
            try
            {
                var toy = _toyRepository.GetById(id);
                if (toy == null) throw new Exception("Toy not found");
                response.Data = toy.Adapt<ToyDto>();
                response.IsSuccess = true;
                response.Message = "Toy retrieved successfully";
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Persists a new toy
        /// </summary>
        /// <param name="dto">New toy to be created</param>
        /// <returns></returns>
        public Response<bool> Insert(ToyDto dto)
        {
            Toy toy = dto.Adapt<Toy>();
            var response = ValidatorHelper.Validate(toy);
            if (response.Errors != null && response.Errors.Any()) return response;
            try
            {
                response.Data = _toyRepository.Insert(toy);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Toy inserted successfully";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Update existing toy
        /// </summary>
        /// <param name="dto">New toy data</param>
        /// <returns></returns>
        public Response<bool> Update(ToyDto dto)
        {
            Toy toy = dto.Adapt<Toy>();
            var response = ValidatorHelper.Validate(toy);
            if (response.Errors != null && response.Errors.Any()) return response;
            try
            {
                response.Data = _toyRepository.Update(toy);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Toy updated successfully";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Delete existing toy
        /// </summary>
        /// <param name="id">Toy id to be deleted</param>
        /// <returns></returns>
        public Response<bool> Delete(int id)
        {
            var response = new Response<bool>();
            try
            {
                var toy = _toyRepository.GetById(id);
                if (toy == null) throw new Exception("Toy not found");
                response.Data = _toyRepository.Delete(toy);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Toy deleted successfully";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
