using System;
using System.IO;
using System.Threading.Tasks;
using Ao3Api.Interfaces;
using Ao3Domain.Models.Request;
using Ao3Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ao3Functions
{
    public class WorkSearch
    {
        private IWorksService _worksService;

        public WorkSearch(IWorksService worksService)
        {
            _worksService = worksService;
        }
        
        [FunctionName("WorkSearch")]
        public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "works/search")]
            HttpRequest req, ILogger log)
        {
            string query = req.Query["query"];
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<SearchRequest>(requestBody);
            switch (data)
            {
                case null when string.IsNullOrEmpty(query):
                    return new BadRequestObjectResult("You must pass data in the query or body");
                case null:
                    data = new SearchRequest{Query = query};
                    break;
            }
            var searchResult = await _worksService.Search(data);
            
            return new OkObjectResult(new WorkListResponse
            {
                Works = searchResult,
                Page = int.Parse(data.Page ?? "1")
            });
        }
    }
}