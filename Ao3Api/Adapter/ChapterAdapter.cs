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
            var chapter = document.DocumentNode.QuerySelector("div#workskin");
            return AdaptChapter(chapter);
        }

        private static WorkChapter AdaptChapter(HtmlNode node)
        {
            var preface = node.QuerySelector("div.preface");
            var chapter = node.QuerySelector("div.chapter");
            return new WorkChapter
            {
                Title = chapter.QuerySelector("div.chapter h3.title a").InnerText,
                Summary = Sanitizer.LineSpaceSanitizer(preface.QuerySelector("div.summary blockquote p").InnerText),
                Notes = Sanitizer.LineSpaceSanitizer(chapter.QuerySelector("div.chapter div.notes p").InnerText),
                WorkDetails = new WorkIndexing
                {
                    Author = preface.QuerySelector("h3.heading a").InnerText,
                    Title = Sanitizer.LineSpaceSanitizer(preface.QuerySelector("h2.title").InnerText),
                    WorkId = int.Parse(Sanitizer.ChapterToIdSanitizer(chapter.QuerySelector("div.chapter h3.title a")
                        .Attributes["href"].Value))
                },
                Paragraphs = Sanitizer.ListToListSanitizer(chapter.QuerySelectorAll("div.userstuff p")
                    .Select(el => el.InnerText).ToList())
            };
        }
    }
}