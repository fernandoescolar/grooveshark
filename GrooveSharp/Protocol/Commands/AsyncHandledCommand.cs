using System;

namespace GrooveSharp.Protocol.Commands
{
    internal class AsyncHandledCommand<TResponseData, TSourceResponseData> : IAsyncCommand<TResponseData>
    {
        private readonly Func<TSourceResponseData, TResponseData> handler;
        private readonly IAsyncCommand<TSourceResponseData> innerCommand;

        public AsyncHandledCommand(IAsyncCommand<TSourceResponseData> command, Func<TSourceResponseData, TResponseData> handler)
        {
            this.innerCommand = command;
            this.handler = handler;
        }

        public IAsyncResult BeginExecute(AsyncCallback callback, object state)
        {
            return this.innerCommand.BeginExecute(callback, state);
        }

        public TResponseData EndExecute(IAsyncResult result)
        {
            var obj = this.innerCommand.EndExecute(result);
            return handler(obj);
        }
    }
}
