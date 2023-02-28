using Microsoft.AspNetCore.Components.Forms;
using ProjectWork.Models;
using ProjectWork.Models.Artwork;
using ProjectWork.Models.Core;
using ProjectWork.Services;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Web;

namespace ProjectWork.Services.Core
{
    public class ServiceAPI : IServiceAPI
    {
        private HeadersDirector _headersDirector = new();
        private HeadersBuilder _headersBuilder;
        private readonly string url;
        private readonly UriBuilder uriBuilder;

        public ServiceAPI(string url)
        {
            _headersBuilder = new HeadersBuilder(new HttpClient());
            _headersDirector.Builder = _headersBuilder;
            this.url = url;
            this.uriBuilder = new UriBuilder(url);
        }

        public async Task<K> GetDataPageAsync<K>(int currentPage)
        {
            _headersDirector.BuildGenericGetHeader();
            return await HandleRequest.Requested(_headersBuilder.GetHttpClient().GetFromJsonAsync<K>($"{url}?page={currentPage}"));
        }
        public async Task<K> GetDataPageAsync<K>(Dictionary<string,string> parameters)
        {
            BuildUri(parameters);
            return await HandleRequest.Requested(_headersBuilder.GetHttpClient().GetFromJsonAsync<K>(uriBuilder.Uri));

        }

        private void BuildUri(Dictionary<string, string> parameters)
        {
            uriBuilder.Query = "";
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            foreach (var item in parameters)
            {
                query[item.Key] = item.Value;
            }
            uriBuilder.Query = query.ToString();
        }

        public async Task<K> GetDetailObject<K>(int id)
        {
            _headersDirector.BuildGenericGetHeader();
            return await HandleRequest.Requested(_headersBuilder.GetHttpClient().GetFromJsonAsync<K>($"{url}{id}/"));
        }
        public async Task DeleteItemAsync(int page)
        {
            _headersDirector.AuthenticatedHeader();
            var tempMessage = await HandleRequest.Requested(_headersBuilder.GetHttpClient().DeleteAsync($"{url}{page}/"));
            await HandleResponse.Responded(tempMessage);
        }

        public async Task<K> AddItemAsJsonAsync<K>(K item)
        {
            _headersDirector.AuthenticatedHeader();
            var tempMessage = await HandleRequest.Requested(_headersBuilder.GetHttpClient().PostAsJsonAsync(url, item));
            return await HandleResponse.Responded<K>(tempMessage);
        }
        public async Task<K> AddItemAsMultipartAsync<K>(K item, IBrowserFile file)
        {
            _headersDirector.AuthenticatedHeader();
            var content = await HandleMultipart.Build(item, file);
            var tempMessage = await HandleRequest.Requested(_headersBuilder.GetHttpClient().PostAsync(url, content));
            return await HandleResponse.Responded<K>(tempMessage);
        }
        

        public async Task<K> UpdateItemAsJsonAsync<K>(int id,K item)
        {
            _headersDirector.AuthenticatedHeader();
            var tempMessage = await HandleRequest.Requested(_headersBuilder.GetHttpClient().PutAsJsonAsync($"{url}{id}/", item));
            return await HandleResponse.Responded<K>(tempMessage);
        }

        public async Task<K> AddUpdateAsMultipartAsync<K>(int id,K item, IBrowserFile file)
        {
            _headersDirector.AuthenticatedHeader();
            var content = await HandleMultipart.Build(item, file);
            var tempMessage = await HandleRequest.Requested(_headersBuilder.GetHttpClient().PatchAsync($"{url}{id}/", content));
            return await HandleResponse.Responded<K>(tempMessage);
        }

    }
}