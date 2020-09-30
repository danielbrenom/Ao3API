using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ao3Domain.Models.Data
{
    public class WorkIndexing : Work
    {
        [JsonProperty("Chapters")] public List<ChapterListing> Chapters { get; set; }
    }
}