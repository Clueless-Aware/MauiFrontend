using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace ProjectWork.Models.Core.Authentication
{
    public class UserEditModel
    {
        [JsonPropertyName("username")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UserName { get; set; }
        [JsonPropertyName("email")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Email { get; set; }
        [JsonPropertyName("biography")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Biography { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; } = true;
        [JsonPropertyName("profile_picture")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IBrowserFile ProfilePicture { get; set; }
    }
    /**
     * {
  "favorite_artist": 0,
  "profile_picture": "string",
  "password": "string",
  "username": "eXspT74c6-8XY2J77nu-H81BV-uJHt4dBL34eazQVu@L",
  "first_name": "string",
  "last_name": "string",
  "is_active": true,
  "biography": "string"
}
     */
}
