using System;
using System.IO;
using System.Threading.Tasks;
using Ao3Api.Interfaces;
using Ao3Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ao3Functions.Work
{
    public class WorkDetails
    {
        private IWorksService _worksService;

        public WorkDetails(IWorksService worksService)
        {
            _worksService = worksService;
        }
        
        [FunctionName("WorkDetails")]
        public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "works/{workId:int}")]
            HttpRequest req, int workId, ILogger log)
        {
            var work = await _worksService.Work(workId);
            return new OkObjectResult(new WorkResponse
            {
                WorkDetails = work,
                Chapters = work.Chapters
            });
        }
    }
}