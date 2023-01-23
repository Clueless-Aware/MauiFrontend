using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
//nei modelli scriviamo il corrispondente modello di django 
//json property name il campo restituito dal api
//required -__-
//ci sono altri jsonproperties 
namespace ProjectWork.Models
{
    public class Example
    {
        [Required]
        [JsonRequired]
        [JsonPropertyName("idJson")]
        public string Id { get; set; }

        [JsonPropertyName("nameJson")]
        public string Name { get; set; }

        [JsonPropertyName("descriptionJson")]
        public string Description { get; set; }
        [JsonPropertyName("show")]
        public bool Show { get; set; }

        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }


    }
}
