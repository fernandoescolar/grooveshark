using System;
using GrooveSharp.Cryptography;
using GrooveSharp.Parser;

namespace GrooveSharp.Protocol
{
    internal class DefaultSession : SessionBase
    {
        private string uuid;
        public override string ServerUrl { get { return "grooveshark.com"; } }
        public override string Uuid { get { return uuid ?? (uuid = Guid.NewGuid().ToString().ToUpper()); } }
        public override string Client { get { return "htmlshark"; } }
        public override string ClientRevision { get { return "20130520"; } }
        public override string StreamClient { get { return "jsqueue"; } }
        public override string StreamClientRevision { get { return "20130520"; } }
        public override int Privacy { get { return 0; } }

        protected override string Password { get { return "nuggetsOfBaller"; } }
        protected override string StreamPassword { get { return "chickenFingers"; } }

        public DefaultSession(IHashFactory hashFactory, IParser parser) : base(hashFactory, parser)
        {
            Initialize(Guid.NewGuid().ToString().Replace("-", string.Empty).ToLower());
        }
    }
}
