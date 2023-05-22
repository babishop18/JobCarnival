namespace JobCarnival.Mvc.Models.Response
{
    public class ResponseDetail
    {
        public enum ResponseStatus { Accepted, Denied, ContinueProcess }
        public string ResponseMessage { get; set; }
        public int ResponseId { get; set; }
    }
}
