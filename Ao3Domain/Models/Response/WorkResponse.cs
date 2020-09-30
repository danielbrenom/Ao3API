using System.Collections.Generic;
using Ao3Domain.Models.Data;
using Newtonsoft.Json;

namespace Ao3Domain.Models.Response
{
    public class WorkResponse
    {
        #nullable enable
        [JsonProperty("WorkDetails")]
        public Work? WorkDetails { get; set; }
        #nullable disable
        [JsonProperty("Chapters")]
        public List<ChapterListing> Chapters { get; set; }
    }
}