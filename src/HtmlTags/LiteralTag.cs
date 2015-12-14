using System;
#if DNXCORE50 || DNX451
using Microsoft.AspNet.Html;
#else
using System.Web.UI;
#endif


namespace HtmlTags
{
    /// <summary>
    /// HtmlTag that *only outputs the literal html put into it in the 
    /// constructor function
    /// </summary>
    public class LiteralTag : HtmlTag
    {
        public LiteralTag(string html) : base("div")
        {
            Text(html);
            Encoded(false);
        }

        protected override void WriteHtml(HtmlTextWriter html)
        {
            html.Write(Text());
        }
    }

    public static class LiteralTagExtensions
    {
        /// <summary>
        /// Adds a LiteralTag to the Children collection
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="html"></param>
        /// <returns></returns>
        public static HtmlTag AppendHtml(this HtmlTag tag, string html)
        {
            return tag.Append(new LiteralTag(html));
        }
    }
}