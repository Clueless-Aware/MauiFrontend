#nullable enable
using System.Text.Json.Serialization;
using ProjectWork.Models.Core.User;

namespace ProjectWork.Models.Core.Authentication;

public class LoginResponse
{
    [JsonPropertyName("access_token")] public string? AccessToken { get; set; }

    [JsonPropertyName("refresh_token")] public string? RefreshToken { get; set; }

    [JsonPropertyName("user")] public UserModel? User { get; set; }
}