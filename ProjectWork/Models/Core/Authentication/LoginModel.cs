using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectWork.Models.Core.Authentication
{
    public class LoginModel
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("password")]
        public  string Password { get; set; }  
    }
}
