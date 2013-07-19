using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    public class SearchResult
    {
        [DataMember(Name = "result")]
        public SearchResultSet ResultSet { get; set; }

        [DataMember(Name = "assignedVersion")]
        public string AssignedVersion { get; set; }

        [DataMember(Name = "version")]
        public string Version { get; set; }

        [DataMember(Name = "askForSuggestion")]
        public bool AskForSuggestion { get; set; }
    }
}