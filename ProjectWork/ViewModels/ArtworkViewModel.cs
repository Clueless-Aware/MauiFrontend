using ProjectWork.Models.Artwork;
using ProjectWork.Models.Core;
using ProjectWork.Resources.Static;
using ProjectWork.Services.Core;
using ProjectWork.Utilities;

namespace ProjectWork.ViewModels
{
    public class ArtworkViewModel : BaseViewModel<BaseArtwork>
    {
        //Declare a Service pass the url end point
        private readonly ServiceAPI _artworkService = new ServiceAPI("http://localhost/api/accounts/");
        /// <summary>
        /// Get Generic data of T from api service and set the state of paginator if get some data
        /// </summary>
        /// <returns></returns>
        public override async Task GetGenericDataFromPageAsync()
        {
            IsBusy = true;
            GenericData = await _artworkService.GetDataPageAsync<GenericData<BaseArtwork>>(Parameters.dictionary);
            if (GenericData != null && GenericData.Data.Count > 0)
            {
                Paginator.SetActualState(Parameters, this.GetGenericDataFromPageAsync, GenericData.Count);
            }
            else
            {
                await UtilityToolkit.CreateToast("Not items found");
            }
            IsBusy = false;
        }
        /// <summary>
        /// Delete Item T with id calling the service delete
        /// </summary>
        /// <param name="id">Item id</param>
        /// <returns></returns>
        public override async Task DeleteItemAsync(int id)
        {
            IsBusy = true;
            await _artworkService.DeleteItemAsync(id);
            IsBusy = false;
        }
        /// <summary>
        /// Add item with image
        /// </summary>
        /// <param name="artwork"></param>
        /// <returns></returns>
        public override async Task AddItemAsync(BaseArtwork artwork)
        {
            IsBusy = true;
            var newItem = await _artworkService.AddItemAsMultipartAsync<BaseArtwork,BaseArtwork>(artwork, artwork.File);
            if (newItem is not null)
            {
                await UtilityToolkit.CreateToast($"Created new element: {newItem.Id} {newItem.Title} ");
            }
            IsBusy = false;
        }
        /// <summary>
        /// Update item from item input
        /// </summary>
        /// <param name="artwork"></param>
        /// <returns></returns>
        public override async Task UpdateItemAsync(BaseArtwork artwork)
        {
            IsBusy = true;
            var updatedItem = await _artworkService.AddUpdateAsMultipartAsync(artwork.Id, artwork, artwork.File);
            if (updatedItem is not null)
            {
                await UtilityToolkit.CreateToast($"Created new element: {updatedItem.Id} {updatedItem.Title} ");
            }
            IsBusy = false;
        }
    }
}
