using FluentValidation.Results;

namespace AspiriaTechnicalAssessment.Core.Transversal.Common
{
    public class Response<T>
    {
        /// <summary>
        /// Contains the data of the response
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Indicates if the request was successful
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Stores a message relatd to the response
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Enumeration of errors using FluentValidation
        /// </summary>
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
