using JobCarnival.Mvc.Models.Response;

namespace JobCarnival.Mvc.Services.Response
{
    public interface IResponseService
    {
        Task<bool> CreateResponseAsync(ResponseCreate request);
    }
}
