using ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Data.ViewModels
{
    public interface IExampleViewModel
    {
        event PropertyChangedEventHandler PropertyChanged;
        bool IsShowed { get; set; }

        int ExampleItems { get;  }

        List<Movie> ExamplesList{ get;  }

        void GetExamples();
        List<Movie> MovieList{ get;  }

        Task GetMovies();
    }
}
