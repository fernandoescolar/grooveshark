using System.Net;

namespace GrooveSharp.Protocol.Commands
{
    internal class GetSessionIdAsyncCommand : AsyncCommandBase<string>
    {
        public GetSessionIdAsyncCommand(ISession session) : base(session)
        {
        }

        protected override WebRequest CreateWebRequest()
        {
            return WebRequest.Create(this.CreateUrl());
        }

        protected override string OnEndExecution(WebResponse webResponse)
        {
            var data = webResponse.Headers["set-Cookie"].Split(';')[0];

            return data.Split('=')[1];
        }

        private string CreateUrl()
        {
            return string.Format("http://{0}", this.Session.ServerUrl);
        }
    }
}
