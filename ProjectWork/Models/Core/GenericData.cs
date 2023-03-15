using System.Text.Json.Serialization;

namespace ProjectWork.Models.Core;

public class GenericData<T>
{
    [JsonPropertyName("count")] public int Count { get; set; }

    [JsonPropertyName("next")] public string Next { get; set; }

    [JsonPropertyName("previous")] public string Previous { get; set; }

    [JsonPropertyName("results")] public IEnumerable<T> Data { get; set; } = new List<T>();
}