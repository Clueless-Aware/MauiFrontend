using System.Text.Json.Serialization;

namespace ProjectWork.Models.Core.Authentication;

public class AuthTokens
{
    [JsonPropertyName("access_token")] public string? AccessToken { get; set; }

    [JsonPropertyName("refresh_token")] public string? RefreshToken { get; set; }
}