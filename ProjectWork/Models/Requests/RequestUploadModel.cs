using System.Text.Json.Serialization;

namespace ProjectWork.Models.Requests;

public class RequestUploadModel
{
    [JsonPropertyName("content")] private string Content { get; set; }
    [JsonPropertyName("critical")] private bool IsCritical { get; set; }
    [JsonPropertyName("subject")] private string Subject { get; set; }
    [JsonPropertyName("from_user")] private int UserId { get; set; }
}