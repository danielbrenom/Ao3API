using System.Collections.Generic;
using Ao3Api.Client;

namespace Ao3Api.Mock.Client.Responses
{
    public class Ao3ResponseBook
    {
        public const string WorksResponse = "Mock/Client/Responses/Html/works.html";
        public const string SearchResponse = "Mock/Client/Responses/Html/search.html";
        public const string WorkResponse = "Mock/Client/Responses/Html/navigate.html";
        public const string WorkChapterResponse = "Mock/Client/Responses/Html/chapter.html";
        
        public static readonly Dictionary<string, string> RouteBook = new Dictionary<string, string>
        {
            {Ao3Routes.Works, WorksResponse},
            {Ao3Routes.Search, SearchResponse},
            {"/works/\\d{1,}", WorkResponse},
            {"/works/\\d{1,}/chapters/\\d{1,}", WorkChapterResponse}
        };
    }
}