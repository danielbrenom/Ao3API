using System;
using System.Collections.Generic;
using System.Linq;
using Ao3Api.Client;
using Ao3Domain.Helpers;
using Ao3Domain.Models.Data;
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

        public static WorkIndexing ExtractWork(HtmlDocument document)
        {
            var index = document.DocumentNode.QuerySelector("div.works-navigate");
            return AdaptWork(index);
        }

        private static List<Work> AdaptWorks(IEnumerable<HtmlNode> nodes)
        {
            var works = new List<Work>();
            foreach (var htmlNode in nodes)
            {
                try
                {
                    var titleAuthor = htmlNode.QuerySelectorAll("div.header h4.heading a").ToList();
                    var words = htmlNode.QuerySelector("dl.stats dd.words");
                    var kudos = htmlNode.QuerySelector("dl.stats dd.kudos a");
                    var comments = htmlNode.QuerySelector("dl.stats dd.comments a");
                    works.Add(new Work
                    {
                        WorkId = titleAuthor.ElementAtOrDefault(0) is null
                            ? 0
                            : int.Parse(Sanitizer.IdSanitizer(titleAuthor[0].Attributes["href"].Value)),
                        Title = titleAuthor.ElementAtOrDefault(0) is null ? "" : titleAuthor[0].InnerText,
                        Link = Ao3Routes.BaseUrl + titleAuthor.ElementAtOrDefault(0)?.Attributes["href"].Value,
                        Author = titleAuthor.ElementAtOrDefault(1) is null ? "" : titleAuthor[1].InnerText,
                        Fandom = Sanitizer.ListToListSanitizer(htmlNode.QuerySelectorAll("div.header h5.fandoms a").Select(fandoms => fandoms.InnerText).ToList()),
                        Summary = Sanitizer.ListToStringSanitizer(htmlNode.QuerySelectorAll("blockquote.summary p").Select(sum => sum.InnerText).ToList()),
                        Language = htmlNode.QuerySelector("dl.stats dd.language").InnerText ?? "",
                        Tags = Sanitizer.ListToListSanitizer(htmlNode.QuerySelectorAll("ul.tags li").Select(el => el.QuerySelector("a").InnerText).ToList()),
                        Words = int.Parse(words is null ? "0" : Sanitizer.NumberSanitizer(words.InnerText)),
                        Comments = int.Parse(comments is null ? "0" : Sanitizer.NumberSanitizer(comments.InnerText)),
                        Kudos = int.Parse(kudos is null ? "0" : Sanitizer.NumberSanitizer(kudos.InnerText)),
                    });
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            return works;
        }

        private static WorkIndexing AdaptWork(HtmlNode node)
        {
            var workInfo = node.QuerySelectorAll("h2.heading a").ToList();
            var chapters = node.QuerySelectorAll("ol.chapter li").ToList();
            var indexStructure = new List<ChapterListing>();
            chapters.ForEach(chapter =>
            {
                var details = chapter.QuerySelector("a");
                indexStructure.Add(new ChapterListing
                {
                    ChapterId = Sanitizer.ChapterSanitizer(details.Attributes["href"].Value), 
                    Title = details.InnerText
                });
            });
            return new WorkIndexing
            {
                Chapters = indexStructure,
                WorkId = workInfo.ElementAtOrDefault(0) is null
                    ? 0
                    : int.Parse(Sanitizer.IdSanitizer(workInfo[0].Attributes["href"].Value)),
                Title = workInfo.ElementAtOrDefault(0) is null ? "" : workInfo[0].InnerText,
                Author = workInfo.ElementAtOrDefault(1) is null ? "" : workInfo[1].InnerText,
            };
        }
    }
}