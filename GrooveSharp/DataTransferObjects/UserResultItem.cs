using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    public class UserResultItem
    {
        [DataMember(Name = "About")]
        public string About { get; set; }

        [DataMember(Name = "City")]
        public string City { get; set; }

        [DataMember(Name = "Country")]
        public string Country { get; set; }

        [DataMember(Name = "FName")]
        public string FName { get; set; }

        [DataMember(Name = "Flags")]
        public string Flags { get; set; }

        [DataMember(Name = "IsActive")]
        public string IsActive { get; set; }

        [DataMember(Name = "IsPremium")]
        public string IsPremium { get; set; }

        [DataMember(Name = "LName")]
        public string LName { get; set; }

        [DataMember(Name = "MName")]
        public string MName { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "NotificationEmailPrefs")]
        public string NotificationEmailPrefs { get; set; }

        [DataMember(Name = "Picture")]
        public string Picture { get; set; }

        [DataMember(Name = "Privacy")]
        public string Privacy { get; set; }

        [DataMember(Name = "Score")]
        public double Score { get; set; }

        [DataMember(Name = "Sex")]
        public string Sex { get; set; }

        [DataMember(Name = "State")]
        public string State { get; set; }

        [DataMember(Name = "TOSVersion")]
        public string TOSVersion { get; set; }

        [DataMember(Name = "TSAdded")]
        public string TimeSpanAdded { get; set; }

        [DataMember(Name = "TSDOB")]
        public string TSDOB { get; set; }

        [DataMember(Name = "UploadsEnabled")]
        public string UploadsEnabled { get; set; }

        [DataMember(Name = "UserID")]
        public string UserId { get; set; }

        [DataMember(Name = "Username")]
        public string Username { get; set; }

        [DataMember(Name = "Zip")]
        public string Zip { get; set; }
    }
}
