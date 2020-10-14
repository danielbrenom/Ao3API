using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ao3Domain.Models.Data
{
    public class Work
    {
        [JsonProperty("WorkId")] public int WorkId { get; set; }
        [JsonProperty("Title")] public string Title { get; set; }
        [JsonProperty("Link")] public string Link { get; set; }
        [JsonProperty("Fandom")] public List<string> Fandom { get; set; }
        [JsonProperty("Relationships")] public List<string> Relationships { get; set; }
        [JsonProperty("Characters")] public List<string> Characters { get; set; }
        [JsonProperty("Tags")] public List<string> Tags { get; set; }
        [JsonProperty("Category")] public List<string> Category { get; set; }
        [JsonProperty("Author")] public string Author { get; set; }
        [JsonProperty("Summary")] public string Summary { get; set; }
        [JsonProperty("Language")] public string Language { get; set; }

        [JsonProperty("Words")] public int Words { get; set; }
        [JsonProperty("Comments")] public int Comments { get; set; }
        [JsonProperty("Kudos")] public int Kudos { get; set; }
    }
}