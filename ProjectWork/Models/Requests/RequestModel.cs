using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectWork.Models.Requests;

public class RequestModel
{
    [Required]
    [JsonPropertyName("content")] public string Content { get; set; }
    [Required]
    [JsonPropertyName("date")] public DateOnly Date { get; set; }
    [JsonPropertyName("critical")] public bool IsCritical { get; set; }
    [JsonPropertyName("seen")] public bool IsSeen { get; set; }
    [Required]
    [JsonPropertyName("subject")] public string Subject { get; set; }

    [JsonPropertyName("from_user")] public int UserId { get; set; }

    [JsonPropertyName("email")] public string UserEmail { get; set; }

    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("completed")] public bool IsCompleted { get; set; }

    public override string ToString()
    {
        return $"{Content} - {Subject} - {Date}";
    }
}