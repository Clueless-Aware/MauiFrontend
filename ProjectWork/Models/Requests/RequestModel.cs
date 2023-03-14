using System.Text.Json.Serialization;

namespace ProjectWork.Models.Requests;

public class RequestModel
{
    [JsonPropertyName("content")] private string Content { get; set; }
    [JsonPropertyName("date")] private DateOnly Date { get; set; }
    [JsonPropertyName("critical")] private bool IsCritical { get; set; }
    [JsonPropertyName("seen")] private bool IsSeen { get; set; }
    [JsonPropertyName("subject")] private string Subject { get; set; }

    [JsonPropertyName("from_user")] private int UserId { get; set; }
    //[JsonPropertyName("user_details")] private int UserModel { get; set; }

    public override string ToString()
    {
        return $"{Content} - {Subject} - {Date}";
    }
}