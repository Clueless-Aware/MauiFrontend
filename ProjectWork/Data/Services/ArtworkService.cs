using Microsoft.AspNetCore.Components.Forms;
using ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;

namespace ProjectWork.Data.Services
{
    public class ArtworkService : Service<ArtworkUpload,ArtwokDownload>
    {
        public ArtworkService(string url) : base(url)
        {
        }
        public override async Task<(bool status, string message)> AddItem(ArtworkUpload item)
        {
            var json = JsonSerializer.Serialize<ArtworkUpload>(item);
            var jparser = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

            var file = item.File;
            using var content = new MultipartFormDataContent();
            if (!file.Equals(null))
            {

                var ms = new MemoryStream();
                await file.OpenReadStream().CopyToAsync(ms);
                ms.Position = 0;
                var fileStream = new StreamContent(ms);
                fileStream.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                content.Add(fileStream, "image_url", file.Name);
            }
            foreach (KeyValuePair<string, string> entry in jparser)
            {
                content.Add(new StringContent(entry.Value), entry.Key);
            }
            HttpResponseMessage httpResponseMessage = new();
            try
            {
                Task<HttpResponseMessage> streamAsync = base._httpClient.PostAsync(URL, content);
                httpResponseMessage = await streamAsync;
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
        public override async Task<(bool status, string message)> PutItem(int id, ArtwokDownload item)
        {
            var json = JsonSerializer.Serialize<ArtwokDownload>(item);
            var jparser = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            var file = item.File;
            using var content = new MultipartFormDataContent();
            if (file!=null)
            {

                var ms = new MemoryStream();
                await file.OpenReadStream().CopyToAsync(ms);
                ms.Position = 0;
                var fileStream = new StreamContent(ms);
                fileStream.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                content.Add(fileStream, "image_url", file.Name);
            }
            foreach (KeyValuePair<string, object> entry in jparser)
            {
                if (!entry.Key.Equals("id")|| !entry.Key.Equals("image_url"))
                    content.Add(new StringContent(entry.Value.ToString()), entry.Key);
            }
            HttpResponseMessage httpResponseMessage = new();
            try
            {
                Task<HttpResponseMessage> streamAsync = base._httpClient.PutAsync($"{URL}{id}/", content);
                httpResponseMessage = await streamAsync;
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
        public override async Task<(bool status, string message)> PatchItem(int id, ArtwokDownload item)
        {
            var json = JsonSerializer.Serialize<ArtwokDownload>(item);
            var jparser = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            var file = item.File;
            using var content = new MultipartFormDataContent();
            if (!file.Equals(null))
            {

                var ms = new MemoryStream();
                await file.OpenReadStream().CopyToAsync(ms);
                ms.Position = 0;
                var fileStream = new StreamContent(ms);
                fileStream.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                content.Add(fileStream, "image_url", file.Name);
            }
            foreach (KeyValuePair<string, object> entry in jparser)
            {
                if (!entry.Key.Equals("id")|| !entry.Key.Equals("image_url"))
                    content.Add(new StringContent(entry.Value.ToString()), entry.Key);
            }
            HttpResponseMessage httpResponseMessage = new();
            try
            {
                Task<HttpResponseMessage> streamAsync = base._httpClient.PatchAsync(URL, content);
                httpResponseMessage = await streamAsync;
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
