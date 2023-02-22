using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectWork.Models
{
    public interface IArtworkModel
    {
        public string Title { get; set; }
        //public string Description { get; set; }
        //public string Author { get; set; }
        public IBrowserFile File { get; set; }


    }
}
