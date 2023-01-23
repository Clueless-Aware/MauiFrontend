using CommunityToolkit.Mvvm.ComponentModel;
using ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectWork.Data.Services
{
    public class MovieService : Service<Movie>
    {
        //const string URL = "http://127.0.0.1:8000/api/v1/movies";
        //private static HttpClient _httpClient = new HttpClient();
        //private static MediaTypeWithQualityHeaderValue _mediaType = new("application/json");

        //public async Task<List<Movie>> GetMovies()
        //{
        //    Debug.WriteLine("get movies service");
        //    _httpClient.DefaultRequestHeaders.Accept.Clear();
        //    _httpClient.DefaultRequestHeaders.Accept.Add(_mediaType);
        //    List<Movie> movies = new();
        //    try
        //    {
        //        Task<Stream> streamTask = _httpClient.GetStreamAsync(URL);
        //        //Task<Stream> streamTask = httpClient.GetStreamAsync("https://nonesiste.fr"); //HttpRequestException.
        //        Stream stream = await streamTask;

        //        ValueTask<List<Movie>> resObjectTask = JsonSerializer.DeserializeAsync<List<Movie>>(stream);
        //        movies = await resObjectTask;
        //    }
        //    catch (ArgumentNullException e)
        //    {
        //        Debug.WriteLine("(ArgumentNullException) " + e.Message);
        //        Console.WriteLine("(ArgumentNullException) " + e.Message);
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Debug.WriteLine("(HttpRequestException) " + e.Message);
        //        Console.WriteLine("(HttpRequestException) " + e.Message);
        //    }
        //    catch (TaskCanceledException e)
        //    {
        //        Debug.WriteLine("(TaskCanceledException) " + e.Message);
        //        Console.WriteLine("(TaskCanceledException) " + e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine("(Exception) " + e.Message);
        //        Console.WriteLine("(Exception) " + e.Message);
        //    }
        //    return movies;
        //}
        //public async Task<(bool status, string message)> DeleteMovie(string slug)
        //{
        //    Debug.WriteLine("delete movie service");
        //    _httpClient.DefaultRequestHeaders.Accept.Clear();
        //    _httpClient.DefaultRequestHeaders.Accept.Add(_mediaType);
        //    HttpResponseMessage httpResponseMessage = null;
        //    try
        //    {
        //        Task<HttpResponseMessage> streamTask = _httpClient.DeleteAsync($"{URL}/{slug}");
        //        //Task<Stream> streamTask = httpClient.GetStreamAsync("https://nonesiste.fr"); //HttpRequestException.
        //        httpResponseMessage = await streamTask;
        //    }
        //    catch (ArgumentNullException e)
        //    {
        //        Debug.WriteLine("(ArgumentNullException) " + e.Message);
        //        Console.WriteLine("(ArgumentNullException) " + e.Message);
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Debug.WriteLine("(HttpRequestException) " + e.Message);
        //        Console.WriteLine("(HttpRequestException) " + e.Message);
        //    }
        //    catch (TaskCanceledException e)
        //    {
        //        Debug.WriteLine("(TaskCanceledException) " + e.Message);
        //        Console.WriteLine("(TaskCanceledException) " + e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine("(Exception) " + e.Message);
        //        Console.WriteLine("(Exception) " + e.Message);
        //    }
        //    Debug.WriteLine(httpResponseMessage.ToString());
        //    if (httpResponseMessage.IsSuccessStatusCode)
        //    {
        //        return (httpResponseMessage.IsSuccessStatusCode, await httpResponseMessage.Content.ReadAsStringAsync());
        //    }
        //    else
        //    {
        //        return (httpResponseMessage.IsSuccessStatusCode, await httpResponseMessage.Content.ReadAsStringAsync());
        //    }
        //}
        //public async Task<(bool status, string message)> AddMovie(Movie movie)
        //{
        //    Debug.WriteLine("Add movie service");
        //    _httpClient.DefaultRequestHeaders.Accept.Clear();
        //    _httpClient.DefaultRequestHeaders.Accept.Add(_mediaType);
        //    HttpResponseMessage httpResponseMessage = null;
        //    try
        //    {
        //        var serializedObj = JsonSerializer.Serialize<Movie>(movie);

        //        Task<HttpResponseMessage> streamTask = _httpClient.PostAsync($"{URL}/",new StringContent(serializedObj,Encoding.UTF8,"application/json"));
        //        //Task<Stream> streamTask = httpClient.GetStreamAsync("https://nonesiste.fr"); //HttpRequestException.
        //        httpResponseMessage = await streamTask;

        //    }
        //    catch (ArgumentNullException e)
        //    {
        //        Debug.WriteLine("(ArgumentNullException) " + e.Message);
        //        Console.WriteLine("(ArgumentNullException) " + e.Message);
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Debug.WriteLine("(HttpRequestException) " + e.Message);
        //        Console.WriteLine("(HttpRequestException) " + e.Message);
        //    }
        //    catch (TaskCanceledException e)
        //    {
        //        Debug.WriteLine("(TaskCanceledException) " + e.Message);
        //        Console.WriteLine("(TaskCanceledException) " + e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine("(Exception) " + e.Message);
        //        Console.WriteLine("(Exception) " + e.Message);
        //    }
        //    Debug.WriteLine(httpResponseMessage.ToString());
        //    if (httpResponseMessage.IsSuccessStatusCode)
        //    {
        //        return (httpResponseMessage.IsSuccessStatusCode, await httpResponseMessage.Content.ReadAsStringAsync());
        //    }
        //    else
        //    {
        //        return (httpResponseMessage.IsSuccessStatusCode, await httpResponseMessage.Content.ReadAsStringAsync());
        //    }
        //}
        public MovieService(string url) : base(url)
        {
        }
    }
}
