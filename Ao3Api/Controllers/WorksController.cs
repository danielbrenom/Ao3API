﻿using System.Threading.Tasks;
using Ao3Api.Interfaces;
using Ao3Domain.Models.Request;
using Ao3Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Ao3Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WorksController : Controller
    {
        private readonly IWorksService _worksService;

        public WorksController(IWorksService worksService)
        {
            _worksService = worksService;
        }

        [HttpGet("/works")]
        public async Task<JsonResult> Index()
        {
            var works = await _worksService.Works();
            return Json(new WorkListResponse
            {
                Works = works,
                Page = 1
            });
        }

        // [HttpGet("/works/search")]
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
            var work = await _worksService.Work(workId);
            return Json(new WorkResponse
            {
                WorkDetails = work,
                Chapters = work.Chapters
            });
        }

        [HttpGet("/works/{workId}/chapters/{chapterId}")]
        public async Task<JsonResult> WorkChapter(int workId, int chapterId)
        {
            var chapter = await _worksService.WorkChapter(workId, chapterId);
            return Json(chapter);
        }
    }
}