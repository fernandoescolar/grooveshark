using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [Serializable]
    [Obsolete("We have defined all DTO explicitly")]
    internal class DataTransferDictionary<K, V> : ISerializable
    {
        readonly Dictionary<K, V> dict = new Dictionary<K, V>();

        public DataTransferDictionary() { }

        protected DataTransferDictionary(SerializationInfo info, StreamingContext context)
        {
            
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            foreach (K key in dict.Keys)
            {
                info.AddValue(key.ToString(), dict[key]);
            }
        }

        public void Add(K key, V value)
        {
            dict.Add(key, value);
        }

        public V this[K index]
        {
            set { dict[index] = value; }
            get { return dict[index]; }
        }
    }
}
