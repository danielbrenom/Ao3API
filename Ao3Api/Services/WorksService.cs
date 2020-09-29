using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ao3Api.Adapter;
using Ao3Api.Interfaces;
using Ao3Api.Models.Data;
using Ao3Api.Models.Request;
using Microsoft.Extensions.Caching.Memory;

namespace Ao3Api.Services
{
    public class WorksService : IWorksService
    {
        private readonly IAo3Client _client;
        private readonly IMemoryCache _cache;

        public WorksService(IAo3Client client, IMemoryCache cache)
        {
            _client = client;
            _cache = cache;
        }

        public async Task<List<Work>> Works()
        {
            var webDocument = await _client.GetWorks();
            _cache.GetOrCreate("WorksCache", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15);
                entry.SetPriority(CacheItemPriority.High);
                return WorkAdapter.ExtractWorks(webDocument);
            });
            return WorkAdapter.ExtractWorks(webDocument);
        }

        public async Task<List<Work>> Search(SearchRequest request)
        {
            var searchPattern = request.Query is null ? "" : Regex.Replace(request.Query, @"\s+|\,+", "+");
            searchPattern += string.IsNullOrEmpty(request.Page) ? "&page=1" : $"&page={request.Page}";
            var webDocument = await _client.GetWorks(searchPattern);
            var works = WorkAdapter.ExtractWorks(webDocument);
            _cache.GetOrCreate("WorksCache", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15);
                entry.SetPriority(CacheItemPriority.High);
                return works;
            });
            return works;
        }

        public async Task<WorkIndexing> Work(int workId)
        {
            var webDocument = await _client.GetWork(workId);
            Work cachedWork = null;
            if (_cache.TryGetValue("WorksCache", out List<Work> cachedWorks))
            {
                cachedWork = cachedWorks.FirstOrDefault(work => work.WorkId == workId);
            }

            var workAdapted = WorkAdapter.ExtractWork(webDocument);
            if (cachedWork is null) return workAdapted;
            workAdapted.Title = cachedWork.Title;
            workAdapted.Comments = cachedWork.Comments;
            workAdapted.Kudos = cachedWork.Kudos;
            workAdapted.Fandom = cachedWork.Fandom;
            workAdapted.Language = cachedWork.Language;
            workAdapted.Link = cachedWork.Link;
            workAdapted.Words = cachedWork.Words;
            _cache.GetOrCreate("WorkIndexedCache", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15);
                entry.SetPriority(CacheItemPriority.High);
                return workAdapted;
            });
            return workAdapted;
        }

        public async Task<WorkChapter> WorkChapter(int workId, int chapterId)
        {
            var webDocument = await _client.GetWorkChapter(workId, chapterId);
            WorkIndexing cachedWork = null;
            var chapterAdapted = ChapterAdapter.ExtractChapter(webDocument);
            if (_cache.TryGetValue("WorkIndexedCache", out WorkIndexing cachedWorkIndexed))
            {
                cachedWork = cachedWorkIndexed.WorkId == chapterAdapted.WorkDetails.WorkId ? cachedWorkIndexed : null;
            }

            if (cachedWork is null) return chapterAdapted;
            chapterAdapted.WorkDetails.Title = cachedWork.Title;
            chapterAdapted.WorkDetails.Comments = cachedWork.Comments;
            chapterAdapted.WorkDetails.Kudos = cachedWork.Kudos;
            chapterAdapted.WorkDetails.Fandom = cachedWork.Fandom;
            chapterAdapted.WorkDetails.Language = cachedWork.Language;
            chapterAdapted.WorkDetails.Link = cachedWork.Link;
            chapterAdapted.WorkDetails.Words = cachedWork.Words;
            return chapterAdapted;
        }
    }
}