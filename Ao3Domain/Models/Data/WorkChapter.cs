using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ao3Domain.Models.Data
{
    public class WorkChapter
    {
        [JsonProperty("WorkDetails")]
        public WorkIndexing WorkDetails { get; set; }
        [JsonProperty("ChapterTitle")]
        public string ChapterTitle { get; set; }
        [JsonProperty("ChapterSummary")]
        public string ChapterSummary { get; set; }
        [JsonProperty("ChapterNotes")]
        public string ChapterNotes { get; set; }
        [JsonProperty("ChapterParagraphs")]
        public List<string> ChapterParagraphs { get; set; }
        
    }
}