using Newtonsoft.Json;

namespace Ao3Domain.Models.Request
{
    public class SearchRequest
    {
        [JsonProperty("query")]
        public string Query { get; set; }
        [JsonProperty("page")]
        public string Page { get; set; }
    }
}