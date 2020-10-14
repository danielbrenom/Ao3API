using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ao3Api.Interfaces;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

namespace Ao3Api.Client
{
    public class Ao3HtmlWeb : HtmlWeb, IHtmlWeb
    {
        public new Task<HtmlDocument> LoadFromWebAsync(string url)
        {
            var fullUrl = Ao3Routes.BaseUrl + url;
            var checkAdultContent = LoadFromWebAsync(new Uri(fullUrl), null, null);
            if (checkAdultContent.Result.DocumentNode.QuerySelector("div#main p.caution") is null)
                return checkAdultContent;
            fullUrl += Regex.IsMatch(fullUrl, "\\?") ? "&view_adult = true" : "?view_adult=true";
            return LoadFromWebAsync(new Uri(fullUrl), null, null);
        }
    }
}