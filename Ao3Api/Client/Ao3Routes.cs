namespace Ao3Api.Client
{
    public class Ao3Routes
    {
        public const string BaseUrl = "https://archiveofourown.org";
        public const string Works = "/works";
        public const string Search = "/works/search?utf8=%E2%9C%93&work_search%5Bquery%5D=";
        public static string Navigation(int work)
        {
            return $"/works/{work}/navigate";
        }

        public static string Chapter(int work, int chapter)
        {
            return $"/works/{work}/chapters/{chapter}";
        }
    }
}