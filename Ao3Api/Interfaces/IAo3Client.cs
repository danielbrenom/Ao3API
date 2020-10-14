using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Ao3Api.Interfaces
{
    public interface IAo3Client
    {
        Task<HtmlDocument> GetWorks();
        Task<HtmlDocument> GetWorks(string query);
        Task<HtmlDocument> GetWork(int workId);
        Task<HtmlDocument> GetWorkChapter(int workId, int chapterId);
    }
}