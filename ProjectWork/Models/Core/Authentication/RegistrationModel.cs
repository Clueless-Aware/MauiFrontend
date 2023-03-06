using System.Text.Json.Serialization;

namespace ProjectWork.Models.Core.Authentication;

public class RegistrationModel
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("password1")]
    public string Password1 { get; set; }
    [JsonPropertyName("password2")]
    public string Password2 { get; set; }
}