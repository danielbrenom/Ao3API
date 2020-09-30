using Newtonsoft.Json;
using Ao3Domain.Models.Data;
using System.Collections.Generic;

namespace Ao3Domain.Models.Response
{
    public class WorkListResponse
    {
        [JsonProperty("Works")] public List<Work> Works { get; set; }
        [JsonProperty("Total")] public int WorksCount => Works.Count;
        [JsonProperty("Page")] public int Page { get; set; }
    }
}