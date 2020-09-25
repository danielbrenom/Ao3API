using Newtonsoft.Json;

namespace Ao3Api.Models.Data
{
    public class ChapterListing
    {
        [JsonProperty("Uri")] public string ChapterId { get; set; }
        [JsonProperty("Title")] public string Title { get; set; }
        [JsonProperty("CreationDate")] public string CreationDate { get; set; }
    }
}