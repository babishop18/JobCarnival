namespace JobCarnival.Mvc.Data.Entities
{
    public class CompanyEntity
    {
        public string CompanyName { get; set; }
        public string CompanyCategory { get; set; }
        public string CompanyDescription { get; set; }
        public virtual List<JobEntity> Jobs { get; set; } = new List<JobEntity>();
    }
}
