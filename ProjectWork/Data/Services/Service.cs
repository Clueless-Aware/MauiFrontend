using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

// Service of Angular
namespace ProjectWork.Data.Services
{
    public class Service<T>
    {
        public readonly string URL = "";
        public HttpClient _httpClient = new HttpClient();
        public static MediaTypeWithQualityHeaderValue _mediaType = new("application/json");
        public Service(string url)
        {
            URL = url;
        }
        /// <summary>
        /// Get Items from api endpoint
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<T>> GetItems()
        {
            Debug.WriteLine("get items service");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(_mediaType);
            List<T> items = new();
            try
            {
                Task<Stream> streamTask = _httpClient.GetStreamAsync(URL);
                Stream stream = await streamTask;
                ValueTask<List<T>> resObjectTask = JsonSerializer.DeserializeAsync<List<T>>(stream);
                items = await resObjectTask;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.GetType() + " " + e.Message);
            }
            return items;
        }
        /// <summary>
        /// Post Item in api endpoint
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual async Task<(bool status, string message)> AddItem(T item)
        {
            Debug.WriteLine("Add item service");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(_mediaType);
            HttpResponseMessage httpResponseMessage = new();
            try
            {
                var serializedObj = JsonSerializer.Serialize(item);
                Task<HttpResponseMessage> streamTask = _httpClient.PostAsync($"{URL}",
                                 new StringContent(serializedObj, _mediaType));
                httpResponseMessage = await streamTask;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.GetType() + " " + e.Message);
            }
            Debug.WriteLine(httpResponseMessage.ToString());
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return (httpResponseMessage.IsSuccessStatusCode, await httpResponseMessage.Content.ReadAsStringAsync());
            }
            return (httpResponseMessage.IsSuccessStatusCode, await httpResponseMessage.Content.ReadAsStringAsync());
        }
        /// <summary>
        /// Get Item in api endpoint
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> GetItem(int id)
        {
            Debug.WriteLine("get item service");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(_mediaType);
            T item;
            try
            {
                Task<Stream> streamTask = _httpClient.GetStreamAsync(URL);
                Stream stream = await streamTask;
                ValueTask<T> resObjectTask = JsonSerializer.DeserializeAsync<T>(stream);
                item = await resObjectTask;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.GetType() + " " + e.Message);
            }
            return default;
        }
        /// <summary>
        /// Put item in api endpoint
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual async Task<(bool status, string message)> PutItem(int id, T item)
        {
            Debug.WriteLine("put item service");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(_mediaType);
            HttpResponseMessage httpResponseMessage = new();
            try
            {
                var serializedObj = JsonSerializer.Serialize(item);
                Task<HttpResponseMessage> streamTask = _httpClient.PutAsync($"{URL}{id}/",
                                 new StringContent(serializedObj, _mediaType));
                httpResponseMessage = await streamTask;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.GetType() + " " + e.Message);
            }
            Debug.WriteLine(httpResponseMessage.ToString());
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return (httpResponseMessage.IsSuccessStatusCode, await httpResponseMessage.Content.ReadAsStringAsync());
            }
            return (httpResponseMessage.IsSuccessStatusCode, await httpResponseMessage.Content.ReadAsStringAsync());
        }
        /// <summary>
        /// Patch item in api endpoint
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual async Task<(bool status, string message)> PatchItem(int id, T item)
        {
            Debug.WriteLine("put item service");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(_mediaType);
            HttpResponseMessage httpResponseMessage = new();
            try
            {
                var serializedObj = JsonSerializer.Serialize(item);
                Task<HttpResponseMessage> streamTask = _httpClient.PatchAsync($"{URL}{id}/",
                                 new StringContent(serializedObj, _mediaType));
                httpResponseMessage = await streamTask;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.GetType() + " " + e.Message);
            }
            Debug.WriteLine(httpResponseMessage.ToString());
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return (httpResponseMessage.IsSuccessStatusCode, await httpResponseMessage.Content.ReadAsStringAsync());
            }
            return (httpResponseMessage.IsSuccessStatusCode, await httpResponseMessage.Content.ReadAsStringAsync());
        }
        /// <summary>
        /// Delete method with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<(bool status, string message)> DeleteItem(int id)
        {
            Debug.WriteLine("delete movie service");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(_mediaType);
            HttpResponseMessage httpResponseMessage = new();
            try
            {
                Task<HttpResponseMessage> streamTask = _httpClient.DeleteAsync($"{URL}{id}/");
                httpResponseMessage = await streamTask;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.GetType() + " " + e.Message);
            }
            Debug.WriteLine(httpResponseMessage.ToString());
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return (httpResponseMessage.IsSuccessStatusCode, await httpResponseMessage.Content.ReadAsStringAsync());
            }
            return (httpResponseMessage.IsSuccessStatusCode, await httpResponseMessage.Content.ReadAsStringAsync());
        }

    }
}
