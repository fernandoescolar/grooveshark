using System;

namespace GrooveSharp.Protocol.Commands
{
    public interface IAsyncCommand<TResponseData> 
    {
        IAsyncResult BeginExecute(AsyncCallback callback, object state);
        TResponseData EndExecute(IAsyncResult result);
    }

    public interface IAsyncCommand<out TRequestData, TResponseData> : IAsyncCommand<TResponseData>
        where TRequestData : new()
    {
        TRequestData Parameters { get; }
    }
}