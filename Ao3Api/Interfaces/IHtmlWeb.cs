using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Ao3Api.Interfaces
{
    public interface IHtmlWeb
    {
        public Task<HtmlDocument> LoadFromWebAsync(string url);
    }
}