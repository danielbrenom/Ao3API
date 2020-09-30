using System;
using System.Linq;
using Ao3Api.Models.Data;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

namespace Ao3Api.Adapter
{
    public static class ChapterAdapter
    {
        public static WorkChapter ExtractChapter(HtmlDocument document)
        {
            var chapter = document.DocumentNode.QuerySelector("div.work");
            return AdaptChapter(chapter);
        }

        private static WorkChapter AdaptChapter(HtmlNode node)
        {
            var preface = node.QuerySelector("div#workskin div.preface");
            var chapter = node.QuerySelector("div#workskin div.chapter");
            var details = node.QuerySelector("div.wrapper dl.work");
            var words = details.QuerySelector("dd.stats dl.stats dd.words");
            var kudos = details.QuerySelector("dd.stats dl.stats dd.kudos");
            var comments = details.QuerySelector("dd.stats dl.stats dd.comments");
            var workChapter = new WorkChapter
            {
                Title = chapter.QuerySelector("div.chapter h3.title a")?.InnerText,
                Summary = Sanitizer.LineSpaceSanitizer(preface.QuerySelector("div.summary blockquote p")?.InnerText),
                Notes = Sanitizer.LineSpaceSanitizer(chapter.QuerySelector("div.chapter div.notes p")?.InnerText),
                WorkDetails = new WorkIndexing
                {
                    Author = preface.QuerySelector("h3.heading a").InnerText,
                    Title = Sanitizer.LineSpaceSanitizer(preface.QuerySelector("h2.title").InnerText),
                    WorkId = int.Parse(Sanitizer.ChapterToIdSanitizer(chapter
                        .QuerySelector("div.chapter h3.title a")
                        .Attributes["href"].Value)),
                    Fandom = Sanitizer.ListToListSanitizer(details
                        .QuerySelectorAll("dd.fandom ul.commas li").Select(el => el.QuerySelector("a").InnerText)
                        .ToList()),
                    Relationships = Sanitizer.ListToListSanitizer(details
                        .QuerySelectorAll("dd.relationship ul.commas li").Select(el => el.QuerySelector("a").InnerText)
                        .ToList()),
                    Characters = Sanitizer.ListToListSanitizer(details
                        .QuerySelectorAll("dd.character ul.commas li")
                        .Select(el => el.QuerySelector("a").InnerText).ToList()),
                    Category = Sanitizer.ListToListSanitizer(details.QuerySelectorAll("dd.category ul.commas li")
                        .Select(el => el.QuerySelector("a").InnerText).ToList()),
                    Tags = Sanitizer.ListToListSanitizer(details
                        .QuerySelectorAll("dd.tags ul.commas li")
                        .Select(el => el.QuerySelector("a").InnerText).ToList()),
                    Language = Sanitizer.LineSpaceSanitizer(details.QuerySelector("dd.language").InnerText),
                    Words = int.Parse(words is null ? "0" : Sanitizer.NumberSanitizer(words.InnerText)),
                    Comments = int.Parse(comments is null ? "0" : Sanitizer.NumberSanitizer(comments.InnerText)),
                    Kudos = int.Parse(kudos is null ? "0" : Sanitizer.NumberSanitizer(kudos.InnerText))
                },
                Paragraphs = Sanitizer.ListToListSanitizer(chapter.QuerySelectorAll("div.userstuff p")
                    .Select(el => el.InnerText).ToList())
            };
            return workChapter;
        }
    }
}