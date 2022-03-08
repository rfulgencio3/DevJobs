using DevJobs.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevJobs.API.Controllers
{

    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationDto addJobApplicationDto)
        {
            return NoContent();
        }
    }
}
