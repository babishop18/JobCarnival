using JobCarnival.Mvc.Data;
using JobCarnival.Mvc.Data.Entities;
using JobCarnival.Mvc.Models.Job;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace JobCarnival.Mvc.Services.Job
{
    public class JobService : IJobService
    {
        private readonly int _companyFKey;
        private readonly ApplicationDbContext _context;
        public JobService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<bool> CreateJobAsync(JobCreate request)
        {
            JobEntity newJob = new JobEntity
            {
                JobTitle = request.JobTitle,
                JobSalary = request.JobSalary,
                JobHourlyPay = request.JobHourlyPay,
                JobLocation = request.JobLocation,
                JobRequirements = request.JobRequirements,
                JobSummary = request.JobSummary,
                JobDescription = request.JobDescription,
                JobIsAvailable = request.JobIsAvailable,
                CompanyFKey = _companyFKey

            };
            _context.Jobs.Add(newJob);
            int numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> RemoveJobByIdAsync(int JobId)
        {
            var jobToRemove = await _context.Jobs.Where(entity => entity.CompanyFKey == _companyFKey).FirstOrDefaultAsync(s => s.JobId == JobId);

            if (jobToRemove == null)
            {
                return false;
            }
            if (jobToRemove.JobApps.Count != 0)
            {
                return false;
            }
            _context.Jobs.Remove(jobToRemove);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<List<JobListItem>> GetJobListAsync()
        {
            List<JobListItem> JobsToDisplay = await _context.Jobs.Where(entity => entity.CompanyFKey == _companyFKey)
                .Select(entity => new JobListItem
                {
                    JobTitle = entity.JobTitle,
                    JobId = entity.JobId,
                    JobSalary = entity.JobSalary,
                    JobHourlyPay = entity.JobHourlyPay,
                    JobLocation = entity.JobLocation,
                    JobSummary = entity.JobSummary
                }).ToListAsync();

            return JobsToDisplay;
        }

        public async Task<List<JobListItem>> GetAllJobsAsync()
        {
            List<JobListItem> JobsToDisplay = await _context.Jobs
                .Select(entity => new JobListItem()
                {
                    JobTitle = entity.JobTitle,
                    JobId = entity.JobId,
                    JobSalary = entity.JobSalary,
                    JobHourlyPay = entity.JobHourlyPay,
                    JobLocation = entity.JobLocation,
                    JobSummary = entity.JobSummary
                }).ToListAsync();

            return JobsToDisplay;
        }

        public async Task<JobDetail> GetJobByIdAsync(int id)
        {
            JobEntity? job = await _context.Jobs
                .Include(r => r.JobApps)
                .FirstOrDefaultAsync(r => r.JobId == id);
            if (job is null)
            {
                return null;
            }
            JobDetail jobDetail = new JobDetail()
            {
                JobTitle = job.JobTitle,
                JobSalary = job.JobSalary,
                JobHourlyPay = job.JobHourlyPay,
                JobLocation = job.JobLocation,
                JobRequirements = job.JobRequirements,
                JobSummary = job.JobSummary,
                JobDescription = job.JobDescription,
                JobIsAvailable = job.JobIsAvailable,
            };
            return jobDetail;
        }

        public async Task<bool> UpdateJobByIdAsync(int jobId, JobUpdate update)
        {
            var jobEntity = await _context.Jobs.FirstOrDefaultAsync(c => c.JobId == jobId);
            if (jobEntity == null)
                return false;

            jobEntity.JobTitle = update.JobTitle;
            jobEntity.JobSalary = update.JobSalary;
            jobEntity.JobHourlyPay = update.JobHourlyPay;
            jobEntity.JobLocation = update.JobLocation;
            jobEntity.JobRequirements = update.JobRequirements;
            jobEntity.JobSummary = update.JobSummary;
            jobEntity.JobDescription = update.JobDescription;
            jobEntity.JobIsAvailable = update.JobIsAvailable;


            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;

        }
    }
}
