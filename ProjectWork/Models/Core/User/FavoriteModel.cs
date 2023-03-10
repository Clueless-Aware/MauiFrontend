using System.Text.Json.Serialization;

namespace ProjectWork.Models.Core.User;

public class FavoriteModel
{
    [JsonPropertyName("user")] public int UserId { get; set; }
    [JsonPropertyName("artwork")] private int ArtworkId { get; set; }
}