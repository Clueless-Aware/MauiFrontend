using System.Text.Json.Serialization;

namespace ProjectWork.Models.Core.User;

public class FavoriteModel
{
    [JsonPropertyName("user")] public int UserId { get; set; }
    [JsonPropertyName("artwork")] public int ArtworkId { get; set; }
}