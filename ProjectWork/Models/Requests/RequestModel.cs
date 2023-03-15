using System.Text.Json.Serialization;

namespace ProjectWork.Models.Requests;

public class RequestModel
{
    [JsonPropertyName("content")] public string Content { get; set; }
    [JsonPropertyName("date")] public DateOnly Date { get; set; }
    [JsonPropertyName("critical")] public bool IsCritical { get; set; }
    [JsonPropertyName("seen")] public bool IsSeen { get; set; }
    [JsonPropertyName("subject")] public string Subject { get; set; }

    [JsonPropertyName("from_user")] public int UserId { get; set; }

    [JsonPropertyName("id")] public int Id { get; set; }
    //[JsonPropertyName("user_details")] private int UserModel { get; set; }

    public override string ToString()
    {
        return $"{Content} - {Subject} - {Date}";
    }
}