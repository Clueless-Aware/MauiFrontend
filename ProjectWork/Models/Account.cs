using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectWork.Models
{
    public class Account
    {
        [JsonPropertyName("owner_id")]
        public int OwnerId { get; set; }
        [JsonPropertyName("owner")]
        public string Owner { get; set; }
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
    }
}
