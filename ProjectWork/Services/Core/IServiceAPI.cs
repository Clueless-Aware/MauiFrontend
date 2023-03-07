using Microsoft.AspNetCore.Components.Forms;
using ProjectWork.Models;
using ProjectWork.Models.Core;

namespace ProjectWork.Services.Core
{
    public interface IServiceAPI
    {
        public UriBuilder Uri { get; set; }   
        Task<TR> PostItemAsJsonAsync<TS,TR>(TS item);
        Task<TR> AddItemAsMultipartAsync<TS,TR>(TS item, IBrowserFile file);
        Task<K> AddUpdateAsMultipartAsync<K>(int id, K item, IBrowserFile file);
        Task DeleteItemAsync(int page);
        Task<K> GetDataPageAsync<K>(int currentPage);
        Task<K> GetDataPageAsync<K>(Dictionary<string, string> parameters);
        Task<K> GetDetailObject<K>(int id);
        Task<K> UpdateItemAsJsonAsync<K>(int id, K item);
    }
}