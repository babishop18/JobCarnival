using System;

namespace JobCarnival.Mvc.Data.Entities
{
    public class ApplicantEntity
    {
        public string ApplicantName { get; set; }
        public int ApplicantAge { get; set; }
        public virtual List<ApplicationEntity> UserApps { get; set; } = new List<ApplicationEntity>();
    }
}
