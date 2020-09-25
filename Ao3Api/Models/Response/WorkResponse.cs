using System.Collections.Generic;
using Ao3Api.Models.Data;
using Newtonsoft.Json;

namespace Ao3Api.Models.Response
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