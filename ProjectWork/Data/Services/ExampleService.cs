using CommunityToolkit.Mvvm.Collections;
using ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectWork.Data.Services
{
    public class ExampleService
    {
        const string URL = "http://127.0.0.1:8000/api/v1/movies/";
        private static HttpClient _httpClient = new HttpClient();
        private MediaTypeWithQualityHeaderValue _mediaType = new ("application/json");



        //public async IReadOnlyObservableGroup<Movie> getMovies ()
        //{
        //    return 
        //}
        public async Task<List<Movie>> GetMovies()
        {
            Debug.WriteLine("getExamples");
            List<Movie> examples = new();
            //try
            //{
            //    var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts/1");
            //    string text = response.Content.ReadAsStringAsync().Result;
            //    Debug.WriteLine($"{text}");
            //}
            //catch (Exception e)
            //{

            //    Debug.WriteLine(e);
            //}
            try
            {
                Task<Stream> streamTask = _httpClient.GetStreamAsync(URL);
                //Task<Stream> streamTask = httpClient.GetStreamAsync("https://nonesiste.fr"); //HttpRequestException.
                Stream stream = await streamTask;

                ValueTask<List<Movie>> resObjectTask = JsonSerializer.DeserializeAsync<List<Movie>>(stream);
                examples = await resObjectTask;
            }
            catch (ArgumentNullException e)
            {
                Debug.WriteLine("(ArgumentNullException) " + e.Message);
                Console.WriteLine("(ArgumentNullException) " + e.Message);
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("(HttpRequestException) " + e.Message);
                Console.WriteLine("(HttpRequestException) " + e.Message);
            }
            catch (TaskCanceledException e)
            {
                Debug.WriteLine("(TaskCanceledException) " + e.Message);
                Console.WriteLine("(TaskCanceledException) " + e.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine("(Exception) " + e.Message);
                Console.WriteLine("(Exception) " + e.Message);
            }
            return examples;
        }
    }
}
