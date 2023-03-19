using System.Net;
using ProjectWork.Models.Artist;
using ProjectWork.Models.Core;
using ProjectWork.Services.Core;
using ProjectWork.Utilities;

namespace ProjectWork.ViewModels.Artist;

public class SearchArtistViewModel : BaseViewModel<BaseArtist>
{
    //Declare a Service pass the url end point
    private readonly ServiceAPI _artistService =
        new(Endpoints.GetArtistEndpoint(), new ImageOptions { FileName = "portrait" });

    /// <summary>
    ///     Get Generic data of T from api service and set the state of paginator if get some data
    /// </summary>
    /// <returns></returns>
    public override async Task<(bool status, string message)> GetGenericDataFromPageAsync()
    {
        IsBusy = true;
        try
        {
            _artistService.UriBuilder.Path = Endpoints.GetArtistPath();
            GenericData = await _artistService.GetDataWithParamAsync<GenericData<BaseArtist>>(Parameters.Dictionary);
            Paginator.SetActualState(Parameters, GetGenericDataFromPageAsync, GenericData.Count);
            IsBusy = false;
            return (true, "Successful fetch");
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
            var statusCode = await _artistService.DeleteItemAsync(id);
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
    ///     Add item with image
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
    public override async Task<(bool status, string message)> AddItemAsync(BaseArtist artist)
    {
        IsBusy = true;
        try
        {
            var newItem = await _artistService.AddItemAsMultipartAsync<BaseArtist, BaseArtist>(artist, artist.File);
            await UtilityToolkit.CreateToast($"Created new element: {newItem.Id} {newItem.Name} ");
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
    ///     Update item from item input
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
    public override async Task<(bool status, string message)> UpdateItemAsync(BaseArtist artist)
    {
        IsBusy = true;
        try
        {
            var tempPath = _artistService.UriBuilder.Path;
            _artistService.UriBuilder.Path = Endpoints.GetArtistPath() + artist.Id + '/';
            var newItem = await _artistService.UpdateAsMultipartAsync<BaseArtist, BaseArtist>(artist, artist.File);
            await UtilityToolkit.CreateToast($"Updated element: {newItem.Id} {newItem.Name} ");
            IsBusy = false;
            _artistService.UriBuilder.Path = tempPath;
            return (true, "Updated success");
        }
        catch (Exception e)
        {
            await UtilityToolkit.CreateToast(e.Message);
            IsBusy = false;
            return (true, e.Message);
        }
    }

    public override async Task<BaseArtist> GetItemAsync(int id)
    {
        try
        {
            _artistService.UriBuilder.Path = Endpoints.GetArtistPath() + id + '/';
            var artist = await _artistService.GetDetailObject<BaseArtist>();
            return artist;
        }
        catch (Exception exception)
        {
            await UtilityToolkit.CreateToast("There was an error in navigating to artist: " + exception.Message);
            return null;
        }
    }
}