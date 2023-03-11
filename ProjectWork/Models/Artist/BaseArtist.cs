using System;
using System.Collections.Generic;
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
        [JsonPropertyName("name")] 
        public string Name { get; set; }
        [JsonPropertyName("birth_data")] 
        public string BirthData { get; set; }
        [JsonPropertyName("profession")] 
        public string Profession { get; set; }
        [JsonPropertyName("school")] 
        public string School { get; set; }
        [JsonPropertyName("biography")] 
        public string Biography { get; set; }
        [JsonPropertyName("portrait")] 
        public string Portrait { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public IBrowserFile File { get; set; }
    }
}
