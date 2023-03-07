using System.Text.Json.Serialization;

namespace ProjectWork.Models.Core.Authentication
{
    public class User
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [JsonPropertyName("favorite_artist")]
        public string? FavoriteArtist { get; set; }
        [JsonPropertyName("profile_picture")]
        public string? ProfilePicture { get; set; }
        [JsonPropertyName("last_login")]
        public DateTime LastLogin { get; set; }
        [JsonPropertyName("username")]
        public string? Username { get; set; }
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }
        [JsonPropertyName("email")]
        public string? Email { get; set; }
        [JsonPropertyName("is_staff")]
        public bool? IsStaff { get; set; }
        [JsonPropertyName("date_joined")]
        public DateTime? DateJoined { get; set; }
        [JsonPropertyName("biography")]
        public string? Biography { get; set; }
    }
}
/*
 * "user": {
        "id": 12,
        "favorite_artist": null,
        "profile_picture": "http://192.168.30.184/images/users/default/unknown.jpg",
        "last_login": "2023-03-07T12:10:40.406658Z",
        "is_superuser": false,
        "username": "Postino",
        "first_name": "",
        "last_name": "",
        "email": "",
        "is_staff": false,
        "is_active": true,
        "date_joined": "2023-03-06T13:32:28.858858Z",
        "biography": null,
        "groups": [],
        "user_permissions": []
    }
 */
