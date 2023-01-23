using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectWork.Models
{
    public class Movie
    {
        [JsonPropertyName("slug")]
        public string Slug { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }
    }
}
