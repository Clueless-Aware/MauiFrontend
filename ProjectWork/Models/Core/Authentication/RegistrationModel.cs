using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.Forms;

namespace ProjectWork.Models.Core.Authentication;

public class RegistrationModel
{
    [JsonPropertyName("username")]
    [Required]
    public string Username { get; set; }
    [Required]
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [Required]
    [JsonPropertyName("password1")]
    public string Password1 { get; set; }
    [JsonPropertyName("password2")]
    [Required]
    public string Password2 { get; set; }

    [JsonPropertyName("biography")]
    public string Biography { get; set; }
    [JsonPropertyName("profile_picture")]
    public IBrowserFile ProfilePicture { get; set; }
    [JsonPropertyName("favorite_artist")]
    public int FavoriteArtistId { get; set; }

}