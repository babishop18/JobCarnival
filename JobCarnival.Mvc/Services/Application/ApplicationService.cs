using JobCarnival.Mvc.Data;
using JobCarnival.Mvc.Data.Entities;
using JobCarnival.Mvc.Models.Application;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace JobCarnival.Mvc.Services.Application
{
    public class ApplicationService : IApplicationService
    {
        private readonly int _applicantFKey;
        private readonly ApplicationDbContext _context;

        public ApplicationService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> CreateAppAsync(ApplicationCreate request)
        {
            ApplicationEntity newApp = new ApplicationEntity
            {
                JobId = request.JobId,
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                FullAddress = request.FullAddress,
                Education = request.Education,
                Experience = request.Experience,
                DesiredPay = request.DesiredPay,
                HasResponse = false,
                DateSubmitted = DateTime.Now
            };
            _context.JobApps.Add(newApp);
            int numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        // ASK HOW TO REFERENCE JOB TITLE THAT THIS APPLICATION IS CONNECTED WITH
        public async Task<IEnumerable<UserAppListItem>> GetUsersAppListAsync()
        {
            var AppToDisplay = await _context.JobApps.Where(entity => entity.ApplicantFKey == _applicantFKey)
                .Select(entity => new UserAppListItem
                {
                    JobTitle = entity.Job.JobTitle
                }).ToListAsync();

            return AppToDisplay;
        }

        public async Task<IEnumerable<ApplicationListItem>> GetJobsAppListAsync(int jobId)
        {
            var AppToDisplay = await _context.JobApps.Where(entity => entity.JobId == jobId)
                .Select(entity => new ApplicationListItem
                {
                    FullName = entity.FullName,
                    DateSubmitted = entity.DateSubmitted,
                    HasResponse = entity.HasResponse,
                    PhoneNumber = entity.PhoneNumber,
                    AppId = entity.AppId

                }).ToListAsync();

            return AppToDisplay;
        }

        public async Task<ApplicationDetail> GetAppByIdAsync(int AppId)
        {
            ApplicationEntity entity = await _context.JobApps.FindAsync(AppId);
            if (entity is null)
                return null;

            var AppDetail = new ApplicationDetail
            {
                AppId = entity.AppId,
                FullName = entity.FullName,
                PhoneNumber = entity.PhoneNumber,
                FullAddress = entity.FullAddress,
                Education = entity.Education,
                Experience = entity.Experience,
                DesiredPay = entity.DesiredPay,
                HasResponse = false,
                DateSubmitted = DateTime.Now
            };
            return AppDetail;
        }
    }
}
