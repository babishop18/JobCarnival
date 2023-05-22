using JobCarnival.Mvc.Models.Application;

namespace JobCarnival.Mvc.Services.Application
{
    public interface IApplicationService
    {
        Task<bool> CreateAppAsync(ApplicationCreate request);
        Task<IEnumerable<UserAppListItem>> GetUsersAppListAsync();
        Task<IEnumerable<ApplicationListItem>> GetJobsAppListAsync(int jobId);
        Task<ApplicationDetail> GetAppByIdAsync(int AppId);
    }
}
