using JobCarnival.Mvc.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobCarnival.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}
        public DbSet<ApplicationEntity> JobApps { get; set; }
        public DbSet<JobEntity> Jobs { get; set; }
        public DbSet<ApplicationEntity> Applications { get; set; }
        public DbSet<ResponseEntity> Responses { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<ApplicantEntity> Applicants { get; set; }
    }
}