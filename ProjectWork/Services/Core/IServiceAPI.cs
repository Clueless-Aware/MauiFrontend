using Microsoft.AspNetCore.Components.Forms;
using ProjectWork.Models;
using ProjectWork.Models.Core;

namespace ProjectWork.Services.Core
{
    public interface IServiceAPI
    {
        Task<K> AddItemAsJsonAsync<K>(K item);
        Task<K> AddItemAsMultipartAsync<K>(K item, IBrowserFile file);
        Task<K> AddUpdateAsMultipartAsync<K>(int id, K item, IBrowserFile file);
        Task DeleteItemAsync(int page);
        Task<K> GetDataPageAsync<K>(int currentPage);
        Task<K> UpdateItemAsJsonAsync<K>(int id, K item);
    }
}