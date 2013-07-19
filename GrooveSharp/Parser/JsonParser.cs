using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace GrooveSharp.Parser
{
    internal class JsonParser : IParser
    {
        public T GetObjectFromString<T>(string str)
        {
            T result;
            var serializer = new DataContractJsonSerializer(typeof(T));
            var byteArray = Encoding.UTF8.GetBytes(str);
            using (var reader = new MemoryStream(byteArray))
            {
                result = (T)serializer.ReadObject(reader);
            }

            return result;
        }

        public string GetStringFromObject<T>(T obj)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var writter = new MemoryStream())
            {
                serializer.WriteObject(writter, obj);
                writter.Position = 0;
                using (var reader = new StreamReader(writter))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
