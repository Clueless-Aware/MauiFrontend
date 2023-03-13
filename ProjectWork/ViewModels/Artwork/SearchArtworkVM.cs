using System.Net;
using ProjectWork.Models.Artwork;
using ProjectWork.Models.Core;
using ProjectWork.Services.Core;
using ProjectWork.Utilities;

namespace ProjectWork.ViewModels.Artwork;

public class SearchArtworkVM : BaseViewModel<BaseArtwork>
{
    //Declare a Service pass the url end point
    private readonly ServiceAPI _artworkService = new(Endpoints.GetArtworkEndpoint());

    /// <summary>
    ///     Get Generic data of T from api service and set the state of paginator if get some data
    /// </summary>
    /// <returns></returns>
    public override async Task<(bool status, string message)> GetGenericDataFromPageAsync()
    {
        IsBusy = true;
        try
        {
            GenericData = await _artworkService.GetDataWithParamAsync<GenericData<BaseArtwork>>(Parameters.Dictionary);
            Paginator.SetActualState(Parameters, GetGenericDataFromPageAsync, GenericData.Count);
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
    ///     Delete Item T with id calling the service delete
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
    ///     Add artist with image
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
    public override async Task<(bool status, string message)> AddItemAsync(BaseArtwork artist)
    {
        IsBusy = true;
        try
        {
            var newItem = await _artworkService.AddItemAsMultipartAsync<BaseArtwork, BaseArtwork>(artist, artist.File);
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
    ///     Update artist from artist input
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
    public override async Task<(bool status, string message)> UpdateItemAsync(BaseArtwork artwork)
    {
        IsBusy = true;
        try
        {
            //save the original path
            var tempPath = _artworkService.UriBuilder.Path;
            _artworkService.UriBuilder.Path = Endpoints.GetArtworkPath() + artwork.Id + '/';
            var newItem =
                await _artworkService.UpdateAsMultipartAsync<BaseArtwork, BaseArtwork>(artwork,
                    artwork.File);
            await UtilityToolkit.CreateToast($"Updated element: {newItem.Id} {newItem.Title} ");
            IsBusy = false;
            //reset to the original path
            _artworkService.UriBuilder.Path = tempPath;
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