using JobCarnival.Mvc.Models.Job;

namespace JobCarnival.Mvc.Services.Job
{
    public interface IJobService
    {
        Task<bool> CreateJobAsync(JobCreate request);
        Task<bool> RemoveJobByIdAsync(int JobId);
        Task<List<JobListItem>> GetJobListAsync();
        Task<bool> UpdateJobByIdAsync(int jobId, JobUpdate update);
        Task<List<JobListItem>> GetAllJobsAsync();
        Task<JobDetail> GetJobByIdAsync(int id);
    }
}
