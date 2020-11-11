using System.Collections.Generic;

namespace Ao3Domain.Models.Data
{
    public class StorageData
    {
        public List<Work> FavoriteWorks { get; set; } = new List<Work>();
        public List<WorkHistory> ReadedChapters { get; set; } = new List<WorkHistory>();
        public List<WorkChapter> DownloadedChapters { get; set; } = new List<WorkChapter>();  
    }
}