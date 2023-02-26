using Microsoft.AspNetCore.Components.Forms;
using System.Text.Json.Serialization;

namespace ProjectWork.Models.Artwork
{
    public interface IArtWorkBase
    {
        public string Artist { get; set; }

        public string Title { get; set; }

        public string PictureData { get; set; }

        public string FileInfo { get; set; }

        public string Date { get; set; }

        public string Type { get; set; }

        public string Size { get; set; }

        public string Museum { get; set; }
    }
    public interface IDownloadArtwork : IArtWorkBase
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
    public interface IUploadArtwork  : IArtWorkBase
    {
        public IBrowserFile File { get; set; }
    }
    public class BaseArtwork : IArtWorkBase, IUploadArtwork, IDownloadArtwork
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }
        [JsonPropertyName("artist")]
        public string Artist { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("picture_data")]
        public string PictureData { get; set; }

        [JsonPropertyName("file_info")]
        public string FileInfo { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("size")]
        public string Size { get; set; }

        [JsonPropertyName("museum")]
        public string Museum { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        [JsonPropertyName("file")]
        public IBrowserFile File { get; set; }
    }
}
