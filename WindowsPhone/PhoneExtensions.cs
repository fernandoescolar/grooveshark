using GrooveSharp.Protocol.Commands;
using System.Threading.Tasks;

namespace GrooveSharp
{
    public static class PhoneExtensions
    {
        public async static Task<T> ExecuteAsync<T>(this IAsyncCommand<T> command)
        {
            var task = command.CreateTask();
            //task.Start();
            return await task;
        }

        public static Task<T> CreateTask<T>(this IAsyncCommand<T> command)
        {
            return Task.Factory.FromAsync<T>(command.BeginExecute, command.EndExecute, TaskCreationOptions.None);
        }
    }
}
