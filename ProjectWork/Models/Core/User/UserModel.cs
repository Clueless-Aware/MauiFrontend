#nullable enable
using System.Text.Json.Serialization;
using ProjectWork.Models.Artwork;

namespace ProjectWork.Models.Core.User;

public class UserModel
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("favorite_artist")] public int? FavoriteArtist { get; set; }

    [JsonPropertyName("profile_picture")] public string ProfilePicture { get; set; }

    [JsonPropertyName("last_login")] public DateTime LastLogin { get; set; }

    [JsonPropertyName("username")] public string Username { get; set; }

    [JsonPropertyName("first_name")] public string? FirstName { get; set; }

    [JsonPropertyName("last_name")] public string? LastName { get; set; }

    [JsonPropertyName("email")] public string Email { get; set; }

    [JsonPropertyName("is_staff")] public bool IsStaff { get; set; }

    [JsonPropertyName("date_joined")] public DateTime DateJoined { get; set; }

    [JsonPropertyName("biography")] public string? Biography { get; set; }

    [JsonPropertyName("bookmarked_artworks")]
    public List<BaseArtwork?> BookmarkedArtworks { get; set; }

    [JsonPropertyName("user_bookmarks")] public List<int?> BookmarksIds { get; set; }
}