using System.Collections.Generic;

namespace Ao3Domain.Models.Data
{
    public class WorkHistory
    {
        public int WorkId { get; set; }
        public Dictionary<string, bool> ChapterRead { get; set; } = new Dictionary<string, bool>();
    }
}