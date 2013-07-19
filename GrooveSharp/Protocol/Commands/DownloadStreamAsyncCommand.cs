using System.IO;
using System.Net;
using GrooveSharp.DataTransferObjects;

namespace GrooveSharp.Protocol.Commands
{
    internal class DownloadStreamAsyncCommand : AsyncCommandBase<StreamInfo, GrooveStream>
    {
        private readonly StreamInfo parameters;

        public override StreamInfo Parameters { get { return this.parameters; } }

        public DownloadStreamAsyncCommand(ISession session, StreamInfo streamInfo) : base(session)
        {
            this.parameters = streamInfo;
        }

        protected override WebRequest CreateWebRequest()
        {
            var request = (HttpWebRequest)WebRequest.Create(this.parameters.StreamUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
           
            WriteRequest(request);

            return request;
        }

        protected override GrooveStream OnEndExecution(WebResponse webResponse)
        {
            var length = webResponse.ContentLength;
            return new GrooveStream(webResponse.GetResponseStream(), length);
        }

        private void WriteRequest(HttpWebRequest request)
        {
            var asyncState = request.BeginGetRequestStream(_ => { }, request);
            var stream = request.EndGetRequestStream(asyncState);

            using (var writer = new StreamWriter(stream))
            {
                writer.Write("streamKey=" + this.parameters.StreamKey);
            }
        }
    }
}
