using System;
using System.Net;

namespace GrooveSharp.Protocol.Commands
{
    internal abstract class AsyncCommandBase<TResponseData> : IAsyncCommand<TResponseData>
    {
        private readonly ISession session;

        private WebRequest webRequest;

        protected ISession Session { get { return this.session; } }

        protected AsyncCommandBase(ISession session)
        {
            this.session = session;
        }

        public IAsyncResult BeginExecute(AsyncCallback callback, object state)
        {
            if (webRequest != null)
            {
                throw new InvalidOperationException("You cannot call it twice.");
            }

            webRequest = this.CreateWebRequest();
            this.OnBeginExecution(webRequest);
            return webRequest.BeginGetResponse(callback, state);
        }

        public TResponseData EndExecute(IAsyncResult result)
        {
            if (webRequest == null)
            {
                throw new InvalidOperationException("You have to call 'BeginExecute' previously.");
            }

            var webResponse = webRequest.EndGetResponse(result);
            return this.OnEndExecution(webResponse);
        }

        protected abstract WebRequest CreateWebRequest();

        protected virtual void OnBeginExecution(WebRequest webRequest)
        {
        }

        protected abstract TResponseData OnEndExecution(WebResponse webResponse);
    }

    internal abstract class AsyncCommandBase<TRequestData, TResponseData> : AsyncCommandBase<TResponseData>, IAsyncCommand<TRequestData, TResponseData> where TRequestData : new()
    {
        public abstract TRequestData Parameters { get; }

        protected AsyncCommandBase(ISession session)
            : base(session)
        {
        }
    }
}
