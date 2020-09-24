﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ao3Api.Models
{
    public class Work
    {
        [JsonProperty("Title")] public string Title { get; set; }
        [JsonProperty("Link")] public string Link { get; set; }
        [JsonProperty("Fandom")] public List<string> Fandom { get; set; }
        [JsonProperty("Author")] public string Author { get; set; }
        [JsonProperty("Summary")] public string Summary { get; set; }
        [JsonProperty("Lang")] public string Language { get; set; }

        [JsonProperty("Words")] public int Words { get; set; }
        [JsonProperty("Comments")] public int Comments { get; set; }
        [JsonProperty("Kudos")] public int Kudos { get; set; }
    }
}