using System;
using System.Threading.Tasks;
using Ao3Api.Interfaces;
using HtmlAgilityPack;

namespace Ao3Api.Client
{
    public class Ao3HtmlWeb : HtmlWeb, IHtmlWeb
    {
        public new Task<HtmlDocument> LoadFromWebAsync(string url)
        {
            var fullUrl = Ao3Routes.BaseUrl + url;
            return LoadFromWebAsync(new Uri(fullUrl), null, null);
        }
    }
}