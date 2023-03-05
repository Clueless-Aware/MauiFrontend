using System.Text.Json.Serialization;

namespace ProjectWork.Models.Core.Authentication
{
    public class User
    {
        [JsonPropertyName("pk")]
        public int? PK { get; set; }
        [JsonPropertyName("username")]
        public string? Username { get; set; }
        [JsonPropertyName("email")]
        public string? Email { get; set; }
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }
    }
}
