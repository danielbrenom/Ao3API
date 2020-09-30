using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ao3Domain.Models.Data
{
    public class WorkChapter
    {
        [JsonProperty("WorkDetails")]
        public WorkIndexing WorkDetails { get; set; }
        [JsonProperty("ChapterTitle")]
        public string Title { get; set; }
        [JsonProperty("ChapterSummary")]
        public string Summary { get; set; }
        [JsonProperty("ChapterNotes")]
        public string Notes { get; set; }
        [JsonProperty("ChapterParagraphs")]
        public List<string> Paragraphs { get; set; }
        
    }
}