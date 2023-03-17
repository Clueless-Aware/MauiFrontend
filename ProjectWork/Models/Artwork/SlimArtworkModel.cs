using System.Text.Json.Serialization;

namespace ProjectWork.Models.Artwork;

public class SlimArtworkModel
{
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("author")] public string Author { get; set; }
    [JsonPropertyName("image_url")] public string ImageUrl { get; set; }
}