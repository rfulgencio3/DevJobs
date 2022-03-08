namespace DevJobs.API.Entities
{
    public class JobApplication
    {
        public JobApplication(string applicantName, string applicantEmail, int idJobVacançy)
        {
            ApplicantName = applicantName;
            ApplicantEmail = applicantEmail;
            IdJobVacançy = idJobVacançy;
        }

        public int Id { get; private set; }
        public string ApplicantName { get; private set; }
        public string ApplicantEmail { get; private set; }
        public int IdJobVacançy { get; private set; }
    }
}
