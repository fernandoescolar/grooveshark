using System;
using System.Linq;
using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    internal class ResultsFromSearchRequest
    {
        [DataMember(Name = "guts")]
        public string Guts { get; set; }

        [DataMember(Name = "query")]
        public string Query { get; set; }

        [DataMember(Name = "type")]
        public string[] TypeString { get; set; }

        public SearchType Type { get { return TypeGetter(); } set { TypeSetter(value); } }

        private void TypeSetter(SearchType value)
        {
            this.TypeString = (from SearchType item in Enum.GetValues(typeof(SearchType))
                               where (value & item) == item && item != SearchType.None
                               select item.ToString()).ToArray();
        }

        private SearchType TypeGetter()
        {
            var list = Enum.GetValues(typeof(SearchType)).Cast<SearchType>().ToList();

            var query = from s in this.TypeString
                        where list.Any(i => i.ToString() == s)
                        select list.First(i => i.ToString() == s);

            return query.Aggregate(SearchType.None, (current, item) => current | item);
        }
    }
}
