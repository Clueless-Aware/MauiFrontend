using System.Net;
using ProjectWork.Models.Core;
using ProjectWork.Models.Artwork;
using ProjectWork.Services.Core;
using ProjectWork.Resources.Static;
using ProjectWork.Utilities;

namespace ProjectWork.ViewModels
{
    public class SearchArtworkVM : BaseViewModel<BaseArtwork>
    {
        //Declare a Service pass the url end point
        private readonly ServiceAPI _artworkService = new(Endpoints.GetArtworkEndpoint());
        /// <summary>
        /// Get Generic data of T from api service and set the state of paginator if get some data
        /// </summary>
        /// <returns></returns>
        public override async Task<(bool status, string message)> GetGenericDataFromPageAsync()
        {
            IsBusy = true;
            try
            {
                GenericData = await _artworkService.GetDataWithParamAsync<GenericData<BaseArtwork>>(Parameters.Dictionary);
                Paginator.SetActualState(Parameters, this.GetGenericDataFromPageAsync, GenericData.Count);
                IsBusy = false;
                return (true, "Success fetch");
            }
            catch (Exception e)
            {
                await UtilityToolkit.CreateToast(e.Message);
                IsBusy = false;
                return (false, e.Message);
            }
        }

        /// <summary>
        /// Delete Item T with id calling the service delete
        /// </summary>
        /// <param name="id">Item id</param>
        /// <returns></returns>
        public override async Task<(bool status, string message)> DeleteItemAsync(int id)
        {
            IsBusy = true;
            try
            {
                var statusCode = await _artworkService.DeleteItemAsync(id);
                if (statusCode != HttpStatusCode.NoContent) throw new Exception("Delete Failed");
                await UtilityToolkit.CreateToast("Delete success");
                IsBusy = false;
                return (true, "Delete success");
            }
            catch (Exception e)
            {
                await UtilityToolkit.CreateToast(e.Message);
                IsBusy = false;
                return (true, e.Message);
            }
        }

        /// <summary>
        /// Add item with image
        /// </summary>
        /// <param name="artwork"></param>
        /// <returns></returns>
        public override async Task<(bool status, string message)> AddItemAsync(BaseArtwork artwork)
        {
            IsBusy = true;
            try
            {
                var newItem = await _artworkService.AddItemAsMultipartAsync<BaseArtwork, BaseArtwork>(artwork, artwork.File);
                await UtilityToolkit.CreateToast($"Created new element: {newItem.Id} {newItem.Title} ");
                IsBusy = false;
                return (true, "Add success");
            }
            catch (Exception e)
            {
                await UtilityToolkit.CreateToast(e.Message);
                IsBusy = false;
                return (true, e.Message);
            }
        }

        /// <summary>
        /// Update item from item input
        /// </summary>
        /// <param name="artwork"></param>
        /// <returns></returns>
        public override async Task<(bool status, string message)> UpdateItemAsync(BaseArtwork artwork)
        {
            IsBusy = true;
            try
            {
                var newItem = await _artworkService.UpdateAsMultipartAsync<BaseArtwork, BaseArtwork>(artwork.Id,artwork, artwork.File);
                await UtilityToolkit.CreateToast($"Updated element: {newItem.Id} {newItem.Title} ");
                IsBusy = false;
                return (true, "Updated success");
            }
            catch (Exception e)
            {
                await UtilityToolkit.CreateToast(e.Message);
                IsBusy = false;
                return (true, e.Message);
            }
        }
        //public async Task<(bool status, string message)> GetGenericDataFromParam(Parameters parameters)
        //{
        //    IsBusy = true;
        //    try
        //    {
        //        GenericData = await _artworkService.GetDataWithParamAsync<GenericData<BaseArtwork>>(parameters.Dictionary);
        //        Paginator.SetActualState(Parameters, this.GetGenericDataFromParam(parameters), GenericData.Count);
        //        IsBusy = false;
        //        return (true, "Success fetch");
        //    }
        //    catch (Exception e)
        //    {
        //        await UtilityToolkit.CreateToast(e.Message);
        //        IsBusy = false;
        //        return (false, e.Message);
        //    }
        //}
    }
}
