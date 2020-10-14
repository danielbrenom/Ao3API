using Newtonsoft.Json;

namespace Ao3Domain.Models.Data
{
    public class ChapterListing
    {
        [JsonProperty("Id")] public string Id { get; set; }
        [JsonProperty("Title")] public string Title { get; set; }
        [JsonProperty("CreationDate")] public string CreationDate { get; set; }
    }
}