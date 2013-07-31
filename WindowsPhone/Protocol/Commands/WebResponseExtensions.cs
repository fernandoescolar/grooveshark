using System.IO;
using System.Net;
using ICSharpCode.SharpZipLib.GZip;

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
                    stream = new GZipInputStream(webResponse.GetResponseStream());
                    break;
                default:
                    stream = webResponse.GetResponseStream();
                    break;
            }
            return stream;
        }
    }
}
