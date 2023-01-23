using ProjectWork.Data.Services;
using ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Data.ViewModels
{
    public class ExampleViewModel : INotifyPropertyChanged  
    {
        private ExampleService exampleService = new ExampleService();
        //public ExampleViewModel(ExampleService exampleService)
        //{
        //    this.exampleService = exampleService;
        //}
        private bool isBusy = false;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value; OnPropertyChanged();
            }
        }
        private bool _isShowed = false;

        public bool IsShowed {
            get => _isShowed;
            set
            {
                _isShowed= value;
                OnPropertyChanged();
            }
        }
        //public int ExampleItems {
        //    get {
        //        //return ExamplesList.Where(example=>example.Show.Equals(true)).Count();
        //    }
        //}
        private List<Movie> _examplesList = new();
        public List<Movie> ExamplesList {
            get => _examplesList;
            private set { 
                _examplesList= value;
                OnPropertyChanged();
            }
        }


        public void GetExamples() {
            Debug.WriteLine("vm");
            //_examplesList = this.exampleService.GetExamples().Result;
            Debug.WriteLine(_examplesList.Count);
            OnPropertyChanged(nameof(ExamplesList));
        }


        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private List<Movie> _movieList = new();
        public List<Movie> MovieList
        {
            get => _movieList;
            private set
            {
                _movieList = value;
                OnPropertyChanged();
            }
        } 

        public async Task GetMovies()
        {

            _movieList = await exampleService.GetMovies();
            Debug.WriteLine(_movieList.Count);
            //OnPropertyChanged(nameof(MovieList));
        }
    }
}
