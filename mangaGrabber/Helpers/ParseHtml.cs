using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mangaGrabber.Helpers
{
    public static class ParseHtml
    {
        public static async Task<HtmlNode> GetHtml(string url)
        {
            HttpClient client = new HttpClient();
            var content = await client.GetStringAsync(url);
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);
            return htmlDoc.DocumentNode.SelectSingleNode("//body");
        }
    }
}
