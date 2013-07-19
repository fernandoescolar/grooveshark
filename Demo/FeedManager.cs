using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace GrooveSharp.Demo
{
    public class FeedManager
    {
        public async Task<IEnumerable<FeedItem>> ReadFeedAsync(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContinueTimeout = 20000;
            try
            {
                var response = await request.GetResponseAsync();
                return TransformResponse(response);
            }
            catch
            {
                return new List<FeedItem> { };
            }
        }

        private static IEnumerable<FeedItem> TransformResponse(WebResponse response)
        {
            var syndication = LoadFromResponse((HttpWebResponse)response);
            return syndication.Items.Select(f => new FeedItem
            {
                Title = f.Title.Text,
                Description = CleanUpDescription(f.Summary.Text),
                PublishDate = f.PublishDate.UtcDateTime,
                Link = SearchMp3Link(f)
            });
        }

        private static string SearchMp3Link(SyndicationItem item)
        {
            var links = item.Links.Select(l => l.Uri.ToString()).ToList();
            links.Add(item.Id);
            links.Add(item.Summary.Text);
            
            var link = links.Where(IsValidUrl).FirstOrDefault(l => l.ToLower().EndsWith(".mp3"));
            if (link == null)
                link = item.Id;

            return link;
        }

        private static bool IsValidUrl(string url)
        {
            var urlregex = new Regex(@"^(http|https|ftp)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&amp;%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{2}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&amp;%\$#\=~_\-]+))*$");
            return urlregex.Match(url).Success;
        }

        private static SyndicationFeed LoadFromResponse(HttpWebResponse response)
        {
            SyndicationFeed syndication;
            var responseStream = response.GetResponseStream();

            if (response.Headers["Content-Encoding"] != null && response.Headers["Content-Encoding"].ToLower().Contains("gzip"))
                responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
            else if (response.Headers["Content-Encoding"] != null && response.Headers["Content-Encoding"].ToLower().Contains("deflate"))
                responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);

            using(var reader = new StreamReader(responseStream))
            using (var xmlReader = new XmlTextReader(reader))
            {
                syndication = SyndicationFeed.Load(xmlReader);
            }

            response.Dispose();

            return syndication;
        }

        private static string CleanUpDescription(string description)
        {
            return Regex.Replace(description, @"<[^>]*>", string.Empty);
        }
    }
}
