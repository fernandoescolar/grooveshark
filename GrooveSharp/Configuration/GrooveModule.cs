using Autofac;
using GrooveSharp.Cryptography;
using GrooveSharp.Parser;
using GrooveSharp.Protocol;

namespace GrooveSharp.Configuration
{
    public class GrooveModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(c => new HashFactory())
                .As<IHashFactory>();

            builder
                .Register(c => new JsonParser())
                .As<IParser>();

            builder
                .Register(c => new DefaultSession(c.Resolve<IHashFactory>(), c.Resolve<IParser>()))
                .As<ISession>()
                .SingleInstance();

            builder
                .Register(c => new AsyncCommandFactory(c.Resolve<ISession>()))
                .As<IAsyncCommandFactory>();

            builder
                .Register(c => new GrooveConnection(c.Resolve<ISession>(), c.Resolve<IAsyncCommandFactory>()))
                .As<IGrooveConnection>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}
