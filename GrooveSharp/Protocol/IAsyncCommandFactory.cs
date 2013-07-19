using System;
using GrooveSharp.DataTransferObjects;
using GrooveSharp.Protocol.Commands;

namespace GrooveSharp.Protocol
{
    public interface IAsyncCommandFactory
    {
        IAsyncCommand<string> GetSession();
        IAsyncCommand<TRequestData, TResponseData> Create<TRequestData, TResponseData>(string method) where TRequestData : new();
        IAsyncCommand<StreamInfo, GrooveStream> Download(StreamInfo streamInfo);
        IAsyncCommand<TResponseData> Create<TResponseData, TSourceResponseData>(IAsyncCommand<TSourceResponseData> innerCommand, Func<TSourceResponseData, TResponseData> transformationCallback);
    }
}