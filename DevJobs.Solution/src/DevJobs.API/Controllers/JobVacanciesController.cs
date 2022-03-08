using DevJobs.API.Entities;
using DevJobs.API.Models;
using DevJobs.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevJobs.API.Controllers
{
    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {
        private readonly DevJobsContext _devJobsContext;
        public JobVacanciesController(DevJobsContext devJobsContext)
        {
            _devJobsContext = devJobsContext;   
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var jobVacancies = _devJobsContext.JobVacancies;
            return Ok(jobVacancies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var jobVacancy = _devJobsContext.JobVacancies
                .SingleOrDefault(j => j.Id == id);

            if (jobVacancy == null) 
                return NotFound();
            
            return Ok(jobVacancy);  
        }

        [HttpPost]
        public IActionResult Post(AddVacancyModelDto addVacancyModelDto)
        {
            var jobVacancy = new JobVacancy(
                addVacancyModelDto.Title,
                addVacancyModelDto.Description,
                addVacancyModelDto.Company,
                addVacancyModelDto.IsRemote,
                addVacancyModelDto.SalaryRange
                );
            _devJobsContext.JobVacancies.Add(jobVacancy);

            return CreatedAtAction("GetById", 
                new { id = jobVacancy.Id}, 
                jobVacancy);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyDto updateJobVacancyDto)
        {
            var jobVacancy = _devJobsContext.JobVacancies
                .SingleOrDefault(j => j.Id == id);

            if (jobVacancy == null)
                return NotFound();

            jobVacancy.Update(updateJobVacancyDto.Title, 
                updateJobVacancyDto.Description);

            return NoContent();
        }
    }
}
