using DevJobs.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevJobs.API.Controllers
{
    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(AddVacancyModelDto addVacancyModelDto)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(UpdateJobVacancyDto updateJobVacancyDto)
        {
            return NoContent();
        }


    }
}
