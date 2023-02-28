using ProjectWork.Models.Artwork;
using ProjectWork.Models.Core;

namespace ProjectWork.ViewModels
{
    public interface IViewModel<T>
    {
        //For ListView
        GenericData<T> GenericData { get; set; }
        Parameters Parameters { get; set; }
        Paginator Paginator { get; set; }
        Task GetGenericDataFromPageAsync();
        //For Anti-Spam
        bool IsBusy { get; set; }

        //For AddItem
        Task AddItemAsync(T artwork);
        //For deleteItem
        Task DeleteItemAsync(int id);
        //For UpdateItem
        Task UpdateItemAsync(T artwork);
    }
}