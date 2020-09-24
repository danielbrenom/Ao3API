using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ao3Api.Client;
using Ao3Api.Interfaces;
using Ao3Api.Mock.Client.Responses;
using AutoMapper.Internal;
using HtmlAgilityPack;

namespace Ao3Api.Mock.Client
{
    public class Ao3HtmlWebMock : IHtmlWeb
    {
        public Task<HtmlDocument> LoadFromWebAsync(string url)
        {
            var htmlDocument = new HtmlDocument();
            var file = "";
            Ao3ResponseBook.RouteBook.ForAll(routes =>
            {
                if (Regex.IsMatch(url, Regex.Replace(routes.Key, "([/?+])", "\\$1")))
                    file = File.ReadAllText(routes.Value);
            });
            htmlDocument.LoadHtml(file);

            return Task.FromResult(htmlDocument);
        }
    }
}