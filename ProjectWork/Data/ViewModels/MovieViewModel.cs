using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using ProjectWork.Data.Services;
using ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

//component.ts di angular
namespace ProjectWork.Data.ViewModels
{
    public class MovieViewModel : ObservableRecipient , IViewModel<Movie>
    {
        private readonly MovieService _movieService = new(url:"http://127.0.0.1:8000/api/v1/movies");
        private List<Movie> _movies = new();
        private Movie _movie;

        public Movie Movie
        {
            get => _movie;
            set => SetProperty(ref _movie, value);
        }
        public List<Movie> Items
        {
            get => _movies;
            set => SetProperty(ref _movies, value);
        }

        public async Task ReadItems()
        {
            Debug.WriteLine("READ");
            Items = await _movieService.GetItems();
        }

        public async Task DeleteItem(Movie movie)
        {
            Debug.WriteLine("DELETE");
            var response = await _movieService.DeleteItem(movie.Slug);
            Debug.WriteLine(response.message);
            if (response.status)
            {
                await ReadItems();
            }

        }
        public async Task CreateItem(Movie movie)
        {
            Debug.WriteLine("CREATE");
            var response = await _movieService.AddMovie(movie);
            Debug.WriteLine(response.message);
            if (response.status)
            {
                await ReadItems();
            }
        }



        public Task UpdateItem(Movie item)
        {
            Debug.WriteLine("UPDATE");
            throw new NotImplementedException();
        }

    }
}
