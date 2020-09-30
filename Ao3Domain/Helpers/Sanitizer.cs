using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ao3Domain.Helpers
{
    public static class Sanitizer
    {
        public static string LineSpaceSanitizer(string text)
        {
            return text is null ? string.Empty : text.Trim();
        }

        public static string ListToStringSanitizer(List<string> text)
        {
            var resultString = "";
            text.ForEach(element => { resultString += LineSpaceSanitizer(element); });
            return resultString;
        }
        
        public static List<string> ListToListSanitizer(List<string> text)
        {
            var stringList = new List<string>();
            text.ForEach(element => { if(element != string.Empty || element != "") stringList.Add(LineSpaceSanitizer(element)); });
            return stringList;
        }

        public static string NumberSanitizer(string number)
        {
            return number == string.Empty ? "0" : Regex.Replace(number, ",", "");
        }

        public static string IdSanitizer(string url)
        {
            return url == string.Empty ? "0" : Regex.Match(url, "\\d+").Value;
        }

        public static string ChapterSanitizer(string uri)
        {
            return uri == string.Empty ? "0" : Regex.Match(uri, "\\d+$").Value;
        }

        public static string ChapterToIdSanitizer(string uri)
        {
            return uri == string.Empty ? "0" : Regex.Match(uri, "\\d+").Value;
        }
    }
}