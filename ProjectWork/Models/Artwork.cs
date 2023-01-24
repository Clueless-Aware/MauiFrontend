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
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("image_url")]
        public string Image_url { get; set; }
    
    }
}
