using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "userID")]
        public int UserId { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "FName")]
        public string FullName { get; set; }

        [DataMember(Name = "LName")]
        public string LName { get; set; }

        [DataMember(Name = "isPremium")]
        public string IsPremium { get; set; }

        [DataMember(Name = "autoAutoplay")]
        public bool AutoAutoplay { get; set; }

        [DataMember(Name = "authRealm")]
        public int AuthRealm { get; set; }

        [DataMember(Name = "favoritesLimit")]
        public int FavoritesLimit { get; set; }

        [DataMember(Name = "librarySizeLimit")]
        public int LibrarySizeLimit { get; set; }

        [DataMember(Name = "uploadsEnabled")]
        public int UploadsEnabled { get; set; }

        [DataMember(Name = "themeID")]
        public string ThemeId { get; set; }

        [DataMember(Name = "authToken")]
        public string AuthToken { get; set; }

        [DataMember(Name = "badAuthToken")]
        public bool BadAuthToken { get; set; }

        [DataMember(Name = "Privacy")]
        public int Privacy { get; set; }

        [DataMember(Name = "Sex")]
        public string Sex { get; set; }

        [DataMember(Name = "TSDOB")]
        public string TSDOB { get; set; }

        [DataMember(Name = "flags")]
        public int Flags { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "City")]
        public string City { get; set; }

        [DataMember(Name = "Country")]
        public string Country { get; set; }

        [DataMember(Name = "Picture")]
        public string Picture { get; set; }

        [DataMember(Name = "State")]
        public string State { get; set; }

        [DataMember(Name = "TSAdded")]
        public string TimeSpanAdded { get; set; }

        [DataMember(Name = "userTrackingID")]
        public long UserTrackingId { get; set; }

        [DataMember(Name = "userPrivacyTokens")]
        public UserPrivacyTokens UserPrivacyTokens { get; set; }
    }
}
