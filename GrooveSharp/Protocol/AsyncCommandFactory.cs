using System;
using GrooveSharp.DataTransferObjects;
using GrooveSharp.Protocol.Commands;

namespace GrooveSharp.Protocol
{
    internal class AsyncCommandFactory : IAsyncCommandFactory
    {
        private readonly ISession session;

        public AsyncCommandFactory(ISession session)
        {
            this.session = session;
        }

        public IAsyncCommand<string> GetSession()
        {
            return new GetSessionIdAsyncCommand(this.session);
        }

        public IAsyncCommand<TRequestData, TResponseData> Create<TRequestData, TResponseData>(string method) where TRequestData : new()
        {
            return new AsyncCommand<TRequestData, TResponseData>(session, method);
        }

        public IAsyncCommand<StreamInfo, GrooveStream> Download(StreamInfo streamInfo)
        {
            return new DownloadStreamAsyncCommand(session, streamInfo);
        }

        public IAsyncCommand<TResponseData> Create<TResponseData, TSourceResponseData>(IAsyncCommand<TSourceResponseData> innerCommand, Func<TSourceResponseData, TResponseData> transformationCallback)
        {
            return new AsyncHandledCommand<TResponseData, TSourceResponseData>(innerCommand, transformationCallback);
        }
    }
}
