using System;
using System.IO;
using System.Threading.Tasks;
using Ao3Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ao3Functions
{
    public class WorkChapter
    {
        private IWorksService _worksService;

        public WorkChapter(IWorksService worksService)
        {
            _worksService = worksService;
        }

        [FunctionName("WorkChapter")]
        public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "works/{workId:int}/chapters/{chapterId}")]
            HttpRequest req, int workId, int chapterId, ILogger log)
        {
            var workChapter = await _worksService.WorkChapter(workId, chapterId);
            return new OkObjectResult(workChapter);
        }
    }
}