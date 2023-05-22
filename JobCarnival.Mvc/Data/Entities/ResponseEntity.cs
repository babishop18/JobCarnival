using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobCarnival.Mvc.Data.Entities
{
    public class ResponseEntity
    {
        [Key]
        public int ResponseId { get; set; }
        public enum ResponseStatus { Accepted, Denied, ContinueProcess }
        public string AppResponseMessage { get; set; }
        public DateTimeOffset DateResponded { get; set; }
        [ForeignKey("Application")]
        public int AppFKey { get; set; }
    }
}
