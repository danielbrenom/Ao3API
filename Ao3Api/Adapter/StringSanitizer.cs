using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ao3Api.Adapter
{
    public class StringSanitizer
    {
        public static string LineSpaceSanitizer(string text)
        {
            return Regex.Replace(text, "[\\n]+\\s+"," ");
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
            text.ForEach(element => { stringList.Add(LineSpaceSanitizer(element)); });
            return stringList;
        }

        public static string NumberSanitizer(string number)
        {
            return number == string.Empty ? "0" : Regex.Replace(number, ",", "");
        }
    }
}