using DevJobs.API.Entities;
using DevJobs.API.Models;
using DevJobs.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevJobs.API.Controllers
{

    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly DevJobsContext _devJobsContext;
        public JobApplicationsController(DevJobsContext devJobsContext)
        {
            _devJobsContext = devJobsContext ?? throw new ArgumentNullException(nameof(devJobsContext));
        }

        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationDto addJobApplicationDto)
        {
            var jobVacançy = _devJobsContext.JobVacancies.SingleOrDefault(j => j.Id == id);

            if (jobVacançy == null) 
                return NotFound();

            var jobApplication = new JobApplication(
                addJobApplicationDto.ApplicantName,
                addJobApplicationDto.ApplicantEmail,
                id);

            jobVacançy.Applications.Add(jobApplication);

            return NoContent();
        }
    }
}
