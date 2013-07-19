namespace GrooveSharp.Parser
{
    public interface IParser
    {
        T GetObjectFromString<T>(string str);
        string GetStringFromObject<T>(T obj);
    }
}