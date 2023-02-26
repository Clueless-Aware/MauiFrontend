using ProjectWork.Resources.Static;
using ProjectWork.Models.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectWork.Models.Artwork;
using ProjectWork.Services.Core;

namespace ProjectWork.ViewModels
{
    public class ArtworkViewModel : ObservableRecipient , IViewModel<BaseArtwork>
    {
        private GenericData<BaseArtwork> _genericData = new();
        private int currentPage = 1;

        
        public int CurrentPage { get => currentPage; set => currentPage = value; }
        private readonly ServiceAPI _artworkService = new ServiceAPI(Endpoints.getArtworkEndpoint());
        public  GenericData<BaseArtwork> GenericData
        {
            get => _genericData;
            set => SetProperty(ref _genericData, value);
        }

        public async Task GetDataAsync()
        {
            GenericData = await _artworkService.GetDataPageAsync<GenericData<BaseArtwork>>(CurrentPage);
        }
        public async Task DeleteItemAsync(int id)
        {
            await _artworkService.DeleteItemAsync(id);
        }
        public async Task AddItemAsync(BaseArtwork artwork)
        {
            var newItem = await _artworkService.AddItemAsMultipartAsync(artwork,artwork.File);
        }
        public async Task UpdateItemAsync(BaseArtwork artwork)
        {
            var updatedItem = await _artworkService.AddUpdateAsMultipartAsync(artwork.Id,artwork,artwork.File);
        }
    }
}
