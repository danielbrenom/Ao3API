using System.Threading.Tasks;
using Ao3Api.Interfaces;
using Ao3Api.Models.Request;
using Ao3Api.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Ao3Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Route("[controller]/[action]")]
    public class WorksController : Controller
    {
        private readonly IWorksService _worksService;

        public WorksController(IWorksService worksService)
        {
            _worksService = worksService;
        }

        public async Task<JsonResult> Index()
        {
            var works = await _worksService.Works();
            return Json(new WorkListResponse
            {
                Works = works,
                Page = 1
            });
        }

        [HttpGet("/works/search")]
        public async Task<JsonResult> Search([FromQuery] SearchRequest request)
        {
            var works = await _worksService.Search(request);
            return Json(new WorkListResponse
            {
                Works = works,
                Page = int.Parse(request.Page ?? "1")
            });
        }

        [HttpGet("/works/{workId}")]
        public async Task<JsonResult> Work(int workId)
        {
            return Json(new WorkListResponse());
        }
    }
}