using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ao3Api.Adapter;
using Ao3Api.Interfaces;
using Ao3Api.Models;
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
            return _cache.GetOrCreate("WorksCache", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                entry.SetPriority(CacheItemPriority.High);
                return WorkAdapter.ExtractWorks(webDocument);
            });
        }

        public async Task<List<Work>> Search(SearchRequest request)
        {
            var searchPattern = request.Query is null ? "" : Regex.Replace(request.Query, @"\s+|\,+", "+");
            searchPattern += string.IsNullOrEmpty(request.Page)  ? "&page=1" : $"&page={request.Page}";
            var webDocument = await _client.GetWorks(searchPattern);
            return _cache.GetOrCreate("WorksCache", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                entry.SetPriority(CacheItemPriority.High);
                return WorkAdapter.ExtractWorks(webDocument);
            });
        }
    }
}