using System.IO;
using System.Threading.Tasks;
using Ao3Api.Interfaces;
using Ao3Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ao3Functions
{
    public class WorkIndex
    {
        private IWorksService _worksService;

        public WorkIndex(IWorksService worksService)
        {
            _worksService = worksService;
        }

        [FunctionName("WorkIndex")]
        public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "works")]
            HttpRequest req, ILogger log)
        {
            var works = await _worksService.Works();
            return new OkObjectResult(new WorkListResponse
            {
                Works = works,
                Page = 1
            });
        }
    }
}