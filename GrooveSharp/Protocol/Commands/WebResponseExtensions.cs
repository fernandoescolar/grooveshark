using System.IO;
using System.IO.Compression;
using System.Net;

namespace GrooveSharp.Protocol.Commands
{
    public static class WebResponseExtensions
    {

        internal static Stream GetStreamForResponse(this WebResponse webResponse)
        {
            var response = (HttpWebResponse)webResponse;
            Stream stream;
            switch (response.ContentEncoding.ToUpperInvariant())
            {
                case "GZIP":
                    stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    break;
                default:
                    stream = webResponse.GetResponseStream();
                    break;
            }
            return stream;
        }
    }
}
