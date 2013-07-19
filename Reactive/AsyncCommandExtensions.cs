using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using GrooveSharp.Protocol;
using GrooveSharp.Protocol.Commands;

namespace GrooveSharp.Reactive
{
    public static class AsyncCommandExtensions
    {
        public static Func<IObservable<T>> AsObservable<T>(this IAsyncCommand<T> command)
        {
            return Observable.FromAsyncPattern<T>(command.BeginExecute, command.EndExecute);
        }

        public static void Subscribe<T>(this IAsyncCommand<T> command, Action<T> callback)
        {
            command.AsObservable().Invoke().ObserveOn(Scheduler.CurrentThread).Subscribe(callback);
        }
    }
}
