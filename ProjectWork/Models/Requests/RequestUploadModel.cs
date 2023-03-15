using System.Text.Json.Serialization;

namespace ProjectWork.Models.Requests;

public class RequestUploadModel
{
    [JsonPropertyName("content")] public string Content { get; set; }
    [JsonPropertyName("critical")] public bool IsCritical { get; set; }
    [JsonPropertyName("subject")] public string Subject { get; set; }
    [JsonPropertyName("from_user")] public int UserId { get; set; }
}