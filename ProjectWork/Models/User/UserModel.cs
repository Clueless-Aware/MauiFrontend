﻿#nullable enable
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ProjectWork.Models.Artwork;
using ProjectWork.Models.Requests;

namespace ProjectWork.Models.Core.User;

public class UserModel
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("favorite_artist")] public int? FavoriteArtist { get; set; }

    [JsonPropertyName("profile_picture")] public string ProfilePicture { get; set; }

    [JsonPropertyName("last_login")] public DateTime LastLogin { get; set; }

    [Required]
    [JsonPropertyName("username")] public string Username { get; set; }

    [JsonPropertyName("first_name")] public string? FirstName { get; set; }

    [JsonPropertyName("last_name")] public string? LastName { get; set; }

    [Required]
    [JsonPropertyName("email")] public string Email { get; set; }

    [JsonPropertyName("is_staff")] public bool IsStaff { get; set; }

    [JsonPropertyName("date_joined")] public DateTime DateJoined { get; set; }

    [JsonPropertyName("biography")] public string? Biography { get; set; }

    [JsonPropertyName("bookmarked_artworks")]
    public List<SlimArtworkModel> BookmarkedArtworks { get; set; }

    [JsonPropertyName("user_bookmarks")] public List<int> BookmarksIds { get; set; }

    [JsonPropertyName("user_email_info")] public List<RequestModel> Requests { get; set; }
}