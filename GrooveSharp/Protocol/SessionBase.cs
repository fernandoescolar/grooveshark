using GrooveSharp.Cryptography;
using GrooveSharp.DataTransferObjects;
using GrooveSharp.Parser;

namespace GrooveSharp.Protocol
{
    internal abstract class SessionBase : ISession
    {
        private readonly IHashFactory hashFactory;
        private readonly IParser parser;
        private string token;

        protected SessionBase(IHashFactory hashFactory, IParser parser)
        {
            this.hashFactory = hashFactory;
            this.parser = parser;
        }

        public abstract string ServerUrl { get; }
        public abstract string Uuid { get; }
        public abstract string Client { get; }
        public abstract string ClientRevision { get; }
        public abstract string StreamClient { get; }
        public abstract string StreamClientRevision { get; }

        public abstract int Privacy { get; }

        public Country Country { get; protected set; }
        public string SessionId { get; protected set; }
        public string SecretKey { get { return this.HashFactory.Md5(this.SessionId); } }

        public User User { get; protected set; }
        public bool IsAuthenticated { get { return this.User != null; } }

        public IHashFactory HashFactory { get { return this.hashFactory; } }
        public IParser Parser { get { return this.parser; } }

        protected abstract string Password { get; }
        protected abstract string StreamPassword { get; }

        public void Initialize(string sessionId)
        {
            this.SessionId = sessionId;
            this.GetCountry();
        }

        public virtual void SetSessionToken(string tokenString)
        {
            this.token = tokenString;
        }

        public string Tokenizer(string method)
        {
            return Tokenizer(method, false);
        }

        public string Tokenizer(string method, bool streamMode)
        {
            var random = "abecfd"; //random lenght 6
            var key = method + ":" + token + ":" + (streamMode ? this.StreamPassword : this.Password) + ":" + random;
            return random + this.hashFactory.Sha1(key);
        }

        public void SetUser(User user)
        {
            this.User = user;
        }

        public void SetNoUser()
        {
            this.User = null;
        }

        private void GetCountry()
        {
            this.Country = new Country { Id = "1", Cc1 = "0", Cc2 = "0", Cc3 = "0", Cc4 = "0", Dma = 0, Ipr = "1" }; //spain??
        }
    }
}