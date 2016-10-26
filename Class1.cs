using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Text;

namespace ExtensionMethods
{
    public static class Class1
    {
        public static string HighlightKeyWords(this String text)
        {

            string keywords = "a";
            string cssClass = "yellow";
            if (text == String.Empty)
                return text;
            var words = keywords.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Select(word => "\\b" + word.Trim() + "\\b")
                        .Aggregate(text, (current, pattern) =>
                            Regex.Replace(current, pattern,string.Format("<span style=\"background-color:{0}\">{1}</span>",cssClass,"$0"),RegexOptions.IgnoreCase));

        }
    }
}

//<asp:Label ID="lblName" runat="server" Text='<%# Eval("Name").ToString().HighlightKeyWords() %>' />