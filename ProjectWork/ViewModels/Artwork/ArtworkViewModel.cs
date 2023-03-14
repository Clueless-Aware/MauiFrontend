using System.Net;
using ProjectWork.Models.Artwork;
using ProjectWork.Models.Core;
using ProjectWork.Services.Core;
using ProjectWork.Utilities;

namespace ProjectWork.ViewModels.Artwork;

//Did not use
public class ArtworkViewModel : BaseViewModel<BaseArtwork>
{
    private readonly ServiceAPI _artworkService = new(Endpoints.GetArtworkEndpoint());

    public override async Task<(bool status, string message)> GetGenericDataFromPageAsync()
    {
        IsBusy = true;
        try
        {
            GenericData =
                await _artworkService.GetDataWithParamAsync<GenericData<BaseArtwork>>(Parameters.Dictionary);
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
            var newItem =
                await _artworkService.AddItemAsMultipartAsync<BaseArtwork, BaseArtwork>(artist, artist.File);
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
    public override async Task<(bool status, string message)> UpdateItemAsync(BaseArtwork artist)
    {
        IsBusy = true;
        try
        {
            _artworkService.UriBuilder.Path = Endpoints.GetArtworkPath() + artist.Id;
            var newItem =
                await _artworkService.UpdateAsMultipartAsync<BaseArtwork, BaseArtwork>(artist,
                    artist.File);
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

    public override async Task<BaseArtwork> GetItemAsync(int id)
    {
        try
        {
            _artworkService.UriBuilder.Path = Endpoints.GetArtworkPath() + id + '/';
            var artwork = await _artworkService.GetDetailObject<BaseArtwork>();
            return artwork;
        }
        catch (Exception exception)
        {
            await UtilityToolkit.CreateToast("There was an error in navigating to artwork: " + exception.Message);
            return null;
        }
    }
}