using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectWork.Models.Core.Authentication
{
    public class EmailRequest
    {
        [JsonPropertyName("from_user")]
        [Required]
        public int FromUser { get; set; }
        [Required]
        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [Required]
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [Required]
        [JsonPropertyName("critical")]
        public bool Critical { get; set; }
        [JsonPropertyName("seen")]
        public bool Seen { get; set; }
    }
}
