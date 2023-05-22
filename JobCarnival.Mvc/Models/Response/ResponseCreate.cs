namespace JobCarnival.Mvc.Models.Response
{
    public class ResponseCreate
    {
        public enum ResponseStatus { Accepted, Denied, ContinueProcess }
        public string AppResponseMessage { get; set; }
    }
}
