namespace DevJobs.API.Models
{
    public record AddJobApplicationDto(
        string ApplicantName,
        string ApplicantEmail, 
        int IdJobVacancy)
    {
    }
}