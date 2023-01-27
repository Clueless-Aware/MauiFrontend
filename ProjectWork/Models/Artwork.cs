using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectWork.Models
{
    public class Artwork
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("image_url")]
        public string Image_url { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public IBrowserFile File { get; set; }

    }
    public class ArtwokDownload : IArtworkModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("image_url")]
        public string Image_url { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public IBrowserFile File { get; set; }
    }
    public class ArtworkUpload : IArtworkModel
    {

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public IBrowserFile File { get; set; }
    }
}
