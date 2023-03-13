using System.Net;
using Microsoft.AspNetCore.Components.Forms;

namespace ProjectWork.Services.Core;

public interface IServiceAPI
{
    public UriBuilder UriBuilder { get; set; }
    Task<TR> PostItemAsJsonAsync<TS, TR>(TS item);
    Task<TR> AddItemAsMultipartAsync<TS, TR>(TS item, IBrowserFile file);
    Task<TR> UpdateAsMultipartAsync<TS, TR>(TS item, IBrowserFile file);
    Task<HttpStatusCode> DeleteItemAsync(int page);
    Task<HttpStatusCode> DeleteItemAsyncAiuola(int id);
    Task<K> GetDataWithPageAsync<K>(int currentPage);
    Task<K> GetDataWithParamAsync<K>(Dictionary<string, string> parameters);
    Task<K> GetDetailObject<K>();
    Task<TR> UpdateItemAsJsonAsync<TS, TR>(TS item);
}