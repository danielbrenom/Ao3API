using System.Collections.Generic;
using Ao3Api.Client;

namespace Ao3Api.Mock.Client.Responses
{
    public class Ao3ResponseBook
    {
        public const string WorksResponse = "Mock/Client/Responses/Html/works.html";
        public const string SearchResponse = "Mock/Client/Responses/Html/search.html";
        
        public static readonly Dictionary<string, string> RouteBook = new Dictionary<string, string>
        {
            {Ao3Routes.Works, WorksResponse},
            {Ao3Routes.Search, SearchResponse},
        };
    }
}