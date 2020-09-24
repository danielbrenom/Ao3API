using System.Threading.Tasks;
using Ao3Api.Interfaces;
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
    }
}