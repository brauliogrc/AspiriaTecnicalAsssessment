using AspiriaTechnicalAssessment.Core.Toys.Toys.Domain;
using AspiriaTechnicalAssessment.Core.Transversal.Common;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;

namespace AspiriaTechnicalAssessment.Core.Toys.Toys.Application.Validators
{
    public static class ValidatorHelper
    {
        /// <summary>
        /// Validate the Toy model using Data Annotations
        /// </summary>
        /// <param name="model"></param>
        public static Response<bool> Validate(Toy model)
        {
            var context = new ValidationContext(model);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            var isValid = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

            if (isValid)
            {
                return new Response<bool>
                {
                    Data = true,
                    IsSuccess = true,
                    Message = "Validación exitosa"
                };
            }
            else
            {
                return new Response<bool>
                {
                    Data = false,
                    IsSuccess = false,
                    Message = "Errores de validación",
                    Errors = results.Select(r => new ValidationFailure(
                        string.Join(", ", r.MemberNames),
                        r.ErrorMessage))
                };
            }
        }
    }
}
