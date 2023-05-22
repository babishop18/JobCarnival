using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace JobCarnival.Mvc.Data.Entities
{
    public class JobEntity
    {
        [Key]
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public int? JobSalary { get; set; }
        public int? JobHourlyPay { get; set; }
        public string JobLocation { get; set; }
        public string JobRequirements { get; set; }
        public string JobSummary { get; set; }
        public string? JobDescription { get; set; }
        [ForeignKey("Company")]
        public int CompanyFKey { get; set; }
        public virtual CompanyEntity Company { get; set; }
        public virtual List<ApplicationEntity> JobApps { get; set; } = new List<ApplicationEntity>();
        public bool JobIsAvailable { get; set; }
        public DateTimeOffset DateJobPosted { get; set; }
    }
}
