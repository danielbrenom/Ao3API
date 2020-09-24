using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ao3Api.Models.Response
{
    public class WorksResponse
    {
        [JsonProperty("Works")] public List<Work> Works { get; set; }
        [JsonProperty("Total")] public int WorksCount => Works.Count;
        [JsonProperty("Page")] public int Page { get; set; }
    }
}