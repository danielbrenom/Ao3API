using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Ao3Api.Interfaces
{
    public interface IHtmlWeb
    {
        Task<HtmlDocument> LoadFromWebAsync(string url);
    }
}