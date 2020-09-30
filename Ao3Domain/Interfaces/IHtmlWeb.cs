using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Ao3Domain.Interfaces
{
    public interface IHtmlWeb
    {
        Task<HtmlDocument> LoadFromWebAsync(string url);
    }
}