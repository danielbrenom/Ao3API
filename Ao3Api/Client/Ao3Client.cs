using System.Threading.Tasks;
using Ao3Domain.Interfaces;
using HtmlAgilityPack;

namespace Ao3Api.Client
{
    public class Ao3Client: AgilityClient, IAo3Client
    {
        public Ao3Client(IHtmlWeb ao3HtmlWeb)
        {
            Client = ao3HtmlWeb;
        }
        public async Task<HtmlDocument> GetWorks()
        {
            return await Client.LoadFromWebAsync(Ao3Routes.Works);
        }

        public async Task<HtmlDocument> GetWorks(string query)
        {
            return await Client.LoadFromWebAsync(Ao3Routes.Search + query);
        }

        public async Task<HtmlDocument> GetWork(int workId)
        {
            return await Client.LoadFromWebAsync(Ao3Routes.Navigation(workId));
        }

        public async Task<HtmlDocument> GetWorkChapter(int workId, int chapterId)
        {
            return await Client.LoadFromWebAsync(Ao3Routes.Chapter(workId, chapterId));
        }
    }
}