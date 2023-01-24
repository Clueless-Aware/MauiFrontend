using ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Data.Services
{
    public class ArtworkService : Service<Artwork>
    {
        public ArtworkService(string url) : base(url)
        {
        }
    }
}
