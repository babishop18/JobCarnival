using JobCarnival.Mvc.Data;
using JobCarnival.Mvc.Data.Entities;
using JobCarnival.Mvc.Models.Response;
using System.Security.Claims;

namespace JobCarnival.Mvc.Services.Response
{
    public class ResponseService : IResponseService
    {
        private readonly ApplicationDbContext _context;

        public ResponseService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> CreateResponseAsync(ResponseCreate request)
        {
            ResponseEntity newResponse = new ResponseEntity
            {
                //                ResponseStatus = request.ResponseStatus,
                AppResponseMessage = request.AppResponseMessage,
                DateResponded = DateTime.Now
            };
            _context.Responses.Add(newResponse);
            int numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }
    }
}
