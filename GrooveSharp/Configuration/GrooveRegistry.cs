using GrooveSharp.Cryptography;
using GrooveSharp.Parser;
using GrooveSharp.Protocol;
using StructureMap.Configuration.DSL;

namespace GrooveSharp.Configuration
{
    public class GrooveRegistry : Registry
    {
        public GrooveRegistry()
        {
            For<IParser>().Use<JsonParser>();
            For<IHashFactory>().Use<HashFactory>();
            For<IAsyncCommandFactory>().Use<AsyncCommandFactory>();

            For<ISession>().Singleton().Use<DefaultSession>();

            For<IGrooveConnection>().Singleton().Use<GrooveConnection>();
        }
    }
}
