using System.IO;
using System.IO.Compression;
using System.Net;

namespace GrooveSharp.Protocol.Commands
{
    public static class WebResponseExtensions
    {

        internal static Stream GetStreamForResponse(this WebResponse webResponse)
        {
            Stream stream;
            var encoding = webResponse.Headers["Content-Encoding"];
            encoding = string.IsNullOrEmpty(encoding) ? string.Empty : encoding.ToUpperInvariant();
            switch (encoding)
            {
                case "GZIP":
                    stream = new GZipStream(webResponse.GetResponseStream(), CompressionMode.Decompress);
                    break;
                default:
                    stream = webResponse.GetResponseStream();
                    break;
            }
            return stream;
        }
    }
}
