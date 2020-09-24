using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Ao3Api.Client;
using Ao3Api.Models;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

namespace Ao3Api.Adapter
{
    public static class WorkAdapter
    {
        public static List<Work> ExtractWorks(HtmlDocument document)
        {
            var works = document.DocumentNode.QuerySelectorAll("ol.work li.work");
            return AdaptWorks(works);
        }

        private static List<Work> AdaptWorks(IEnumerable<HtmlNode> nodes)
        {
            var works = new List<Work>();
            foreach (var htmlNode in nodes)
            {
                try
                {
                    var titleAuthor = htmlNode.QuerySelectorAll("div.header h4.heading a").ToList();
                    var fandom = htmlNode.QuerySelectorAll("div.header h5.fandoms a").ToList();
                    var summary = htmlNode.QuerySelectorAll("blockquote.summary p").ToList();
                    var language = htmlNode.QuerySelector("dl.stats dd.language");
                    var words = htmlNode.QuerySelector("dl.stats dd.words");
                    var kudos = htmlNode.QuerySelector("dl.stats dd.kudos a");
                    var comments = htmlNode.QuerySelector("dl.stats dd.comments a");
                    works.Add(new Work
                    {
                        Title = titleAuthor.ElementAtOrDefault(0) is null ? "" : titleAuthor[0].InnerText,
                        Link = Ao3Routes.BaseUrl + titleAuthor.ElementAtOrDefault(0)?.Attributes["href"].Value,
                        Author = titleAuthor.ElementAtOrDefault(1) is null ? "" : titleAuthor[1].InnerText,
                        Fandom =  StringSanitizer.ListToListSanitizer(fandom.Select(fandoms => fandoms.InnerText).ToList()),
                        Summary = StringSanitizer.ListToStringSanitizer(summary.Select(sum => sum.InnerText).ToList()),
                        Language = language.InnerText ?? "",
                        Words = int.Parse(words is null ? "0" : StringSanitizer.NumberSanitizer(words.InnerText)),
                        Comments = int.Parse(comments is null ? "0" : StringSanitizer.NumberSanitizer(comments.InnerText)),
                        Kudos = int.Parse(kudos is null ? "0" : StringSanitizer.NumberSanitizer(kudos.InnerText)),
                    });
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            return works;
        }
    }
}