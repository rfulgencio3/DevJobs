using DevJobs.API.Entities;
using DevJobs.API.Models;
using DevJobs.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevJobs.API.Data.Repositories;

namespace DevJobs.API.Controllers
{
    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {
        private readonly IJobVacancyRepository _repository;
        public JobVacanciesController(IJobVacancyRepository repository)
        {
            _repository = repository;   
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var jobVacancies = _repository.GetAll();
            return Ok(jobVacancies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var jobVacancy = _repository.GetById(id);

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

            _repository.Add(jobVacancy);

            return CreatedAtAction("GetById", 
                new { id = jobVacancy.Id}, 
                jobVacancy);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyDto updateJobVacancyDto)
        {
            var jobVacancy = _repository.GetById(id);

            if (jobVacancy == null)
                return NotFound();
            
            jobVacancy.Update(updateJobVacancyDto.Title, updateJobVacancyDto.Description);
            
            _repository.Update(jobVacancy);

            return NoContent();
        }
    }
}
