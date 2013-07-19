namespace GrooveSharp.Cryptography
{
    public interface IHashFactory
    {
        string Md5(string originalPassword);
        string Sha1(string originalPassword);
    }
}