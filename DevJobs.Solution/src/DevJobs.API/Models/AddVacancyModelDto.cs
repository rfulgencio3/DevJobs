namespace DevJobs.API.Models
{
    public record AddVacancyModelDto(
        string Title,
        string Description,
        string Company,
        bool IsRemote,
        string SalaryRange)
    {
    }
}
