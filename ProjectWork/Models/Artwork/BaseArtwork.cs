using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectWork.Models.Artwork
{
    public interface IArtWorkBase
    {
        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("author_id")]
        public int AuthorId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("technique")]
        public string Technique { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("form")]
        public string Form { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("timeframe")]
        public string TimeFrame { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }

    }
    public interface IDownloadArtwork : IArtWorkBase
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }
    }
    public interface IUploadArtwork  : IArtWorkBase
    {
        [JsonPropertyName("file")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public IBrowserFile File { get; set; }
    }
    public class BaseArtwork : IArtWorkBase, IUploadArtwork, IDownloadArtwork
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }


        [JsonPropertyName("author")]
        [Required]
        public string Author { get; set; }

        [JsonPropertyName("author_id")]
        [Required]
        public int AuthorId { get; set; }

        [JsonPropertyName("title")]
        [Required]
        public string Title { get; set; }

        [JsonPropertyName("date")]
        [Required]
        public string Date { get; set; }

        [JsonPropertyName("technique")]
        [Required]
        public string Technique { get; set; }

        [JsonPropertyName("location")]
        [Required]
        public string Location { get; set; }

        [JsonPropertyName("form")]
        [Required]
        public string Form { get; set; }
        [JsonPropertyName("type")]
        [Required]
        public string Type { get; set; }
        [JsonPropertyName("timeframe")]
        public string TimeFrame { get; set; }
        [JsonPropertyName("description")]
        [Required]
        public string Description { get; set; }

        [JsonPropertyName("file")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public IBrowserFile File { get; set; }
    }
}
