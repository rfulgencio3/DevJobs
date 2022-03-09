using DevJobs.API.Entities;
using DevJobs.API.Models;
using DevJobs.API.Data;
using Microsoft.AspNetCore.Mvc;
using DevJobs.API.Data.Repositories;

namespace DevJobs.API.Controllers
{

    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IJobVacancyRepository _repository;
        public JobApplicationsController(IJobVacancyRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationDto addJobApplicationDto)
        {
            var jobVacancy = _repository.GetById(id);

            if (jobVacancy == null) 
                return NotFound();

            var jobApplication = new JobApplication(
                addJobApplicationDto.ApplicantName,
                addJobApplicationDto.ApplicantEmail,
                id);

            _repository.AddApplication(jobApplication);

            return NoContent();
        }
    }
}
