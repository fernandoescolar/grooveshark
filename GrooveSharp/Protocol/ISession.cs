using GrooveSharp.Cryptography;
using GrooveSharp.DataTransferObjects;
using GrooveSharp.Parser;

namespace GrooveSharp.Protocol
{
    public interface ISession
    {
        string ServerUrl { get; }
        string Uuid { get; }
        string Client { get; }
        string ClientRevision { get; }
        string StreamClient { get; }
        string StreamClientRevision { get; }
        int Privacy { get; }
        Country Country { get; }
        string SessionId { get; }
        string SecretKey { get;}
        User User { get; }
        bool IsAuthenticated { get; }

        string Queue { get; }

        IHashFactory HashFactory { get; }
        IParser Parser { get; }
        
        void Initialize(string sessionId);
        void SetSessionToken(string token);
        string Tokenizer(string method);
        string Tokenizer(string method, bool streamMode);
        void SetUser(User user);
        void SetNoUser();
        void SetQueue(string queue);
    }
}