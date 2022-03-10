using DevJobs.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevJobs.API.Data.Repositories
{
    public class JobVacancyRepository : IJobVacancyRepository
    {
        private readonly DevJobsContext _devJobsContext;
        public JobVacancyRepository(DevJobsContext devJobsContext)
        {
            _devJobsContext = devJobsContext;
        }
        public void Add(JobVacancy jobVacancy)
        {
            _devJobsContext.Add(jobVacancy);
            _devJobsContext.SaveChanges();  
        }

        public void AddApplication(JobApplication jobApplication)
        {
            _devJobsContext.JobApplications.Add(jobApplication);
            _devJobsContext.SaveChanges();
        }

        public List<JobVacancy> GetAll()
        {
            return _devJobsContext.JobVacancies
                .ToList();
        }

        public JobVacancy GetById(int id)
        {
            return _devJobsContext.JobVacancies
                .Include(jv => jv.Applications)
                .SingleOrDefault(j => j.Id == id);
        }

        public void Update(JobVacancy jobVacancy)
        {
            _devJobsContext.JobVacancies.Update(jobVacancy);
            _devJobsContext.SaveChanges();
        }
    }
}
