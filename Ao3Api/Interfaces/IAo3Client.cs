using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Ao3Api.Interfaces
{
    public interface IAo3Client
    {
        public Task<HtmlDocument> GetWorks();
        public Task<HtmlDocument> GetWorks(string query);
        public Task<HtmlDocument> GetWork(int workId);
    }
}