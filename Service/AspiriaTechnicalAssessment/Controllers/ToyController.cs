using AspiriaTechnicalAssessment.Toys.Toys.Application;
using AspiriaTechnicalAssessment.Toys.Toys.Application.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspiriaTechnicalAssessment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToyController : Controller
    {
        protected readonly IToyApplication _toyApplication;

        public ToyController(IToyApplication toyApplication)
        {
            _toyApplication = toyApplication;
        }

        [HttpGet, ActionName("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_toyApplication.GetAll());
        }


        [HttpGet("{id}"), ActionName("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_toyApplication.GetById(id));
        }
        
        [HttpPost, ActionName("Create")]
        public IActionResult Create([FromBody] ToyDto toyDto)
        {
            return Ok(_toyApplication.Insert(toyDto));
        }

        [HttpPut, ActionName("Update")]
        public IActionResult Update([FromBody] ToyDto toyDto)
        {
            return Ok(_toyApplication.Update(toyDto));
        }

        [HttpDelete("{id}"), ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_toyApplication.Delete(id));
        }
    }
}
