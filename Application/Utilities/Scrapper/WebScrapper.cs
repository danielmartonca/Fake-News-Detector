using Domain.Entities;
using System;
using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using System.Linq;

namespace Application.Utilities.Scrapper
{
    public class WebScrapper
    {
        private async static Task<string> GetHtmlFromLink(string url)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = await client.GetStringAsync(url);
            return response;
        }
        private static string GetTitle(HtmlDocument htmlDoc)
        {
            var h1 = htmlDoc.DocumentNode.Descendants().Where(node => node.Name == "h1").FirstOrDefault();
            return h1.InnerText;
        }
        private static string GetContent(HtmlDocument htmlDoc)
        {
            string content = "";
            var pEnumerable = htmlDoc.DocumentNode.Descendants().Where(node => node.Name == "article").First().Descendants();

            if (pEnumerable != null)
                foreach (var paragraph in pEnumerable)
                    if (paragraph.Name == "p")
                        content += paragraph.InnerText + ' ';
            return content;
        }

        private static string GetAuthor(HtmlDocument htmlDoc)
        {
            var pEnumerable = htmlDoc.DocumentNode.Descendants().Where(node => node.Name == "a");

            if (pEnumerable != null)
                foreach (var anchor in pEnumerable)
                {
                    var href = anchor.GetAttributeValue("href", null);
                    if (href != null && href.StartsWith("/profile/"))
                        return anchor.InnerHtml;
                }
            return "Unknown";
        }
        private static News ParseHtmlToNews(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            string title = GetTitle(htmlDoc);
            string content = GetContent(htmlDoc);
            string author = GetAuthor(htmlDoc);
            DateTime date = DateTime.Now;

            return new News(title, content, author, date);

        }
        public static News GetNewsFromUrl(string url)
        {
            string html = GetHtmlFromLink(url).Result;
            News news = ParseHtmlToNews(html);
            return news;
        }
    }
}
