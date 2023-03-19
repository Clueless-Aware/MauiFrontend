using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace ProjectWork.Models.Artist
{
    public class BaseArtist
    {
        [JsonPropertyName("id")] 
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("name")] 
        public string Name { get; set; }
        [Required]
        [JsonPropertyName("birth_data")] 
        public string BirthData { get; set; }
        [Required]
        [JsonPropertyName("profession")] 
        public string Profession { get; set; }
        [Required]
        [JsonPropertyName("school")] 
        public string School { get; set; }
        [Required]
        [JsonPropertyName("biography")] 
        public string Biography { get; set; }
        [JsonPropertyName("portrait")] 
        public string Portrait { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public IBrowserFile File { get; set; }
    }
}
