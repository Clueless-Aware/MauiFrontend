using ProjectWork.Models.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectWork.Models.Artwork;
using ProjectWork.Services.Core;
using ProjectWork.Resources.Static;
using ProjectWork.Utilities;

namespace ProjectWork.ViewModels
{
    public class SearchArtworkVM: ObservableRecipient, IViewModel<BaseArtwork>
    {
        private bool isBusy = false;
        //if Busy=true dont make request or disable button in razor
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                SetProperty(ref isBusy, value);
            }
        }
        private Parameters _parameters = new();
        private GenericData<BaseArtwork> _genericData = new();
        private Paginator _paginator = new();
        public Parameters Parameters
        {
            get
            {
                return _parameters;
            }
            set => SetProperty(ref _parameters, value);
        }
        public Paginator Paginator
        {
            get
            {
                return _paginator;
            }
            set => SetProperty(ref _paginator, value);
        }


        private readonly ServiceAPI _artworkService = new ServiceAPI(Endpoints.getArtworkEndpoint());
        public GenericData<BaseArtwork> GenericData
        {
            get => _genericData;
            set => SetProperty(ref _genericData, value);
        }
        public async Task GetGenericDataFromPageAsync()
        {
            GenericData = await _artworkService.GetDataPageAsync<GenericData<BaseArtwork>>(_parameters.dictionary);

            if (GenericData != null && GenericData.Data.Count> 0)
            {
            _paginator.SetActualState( Parameters, this.GetGenericDataFromPageAsync,GenericData.Data.Count, GenericData.Count);
            }
            else
            {
                await UtilyToolkit.CreateToast("Not items found");
            }
        }
        public async Task DeleteItemAsync(int id)
        {
            await _artworkService.DeleteItemAsync(id);
        }
        public async Task AddItemAsync(BaseArtwork artwork)
        {
            var newItem = await _artworkService.AddItemAsMultipartAsync(artwork, artwork.File);
        }
        public async Task UpdateItemAsync(BaseArtwork artwork)
        {
            var updatedItem = await _artworkService.AddUpdateAsMultipartAsync(artwork.Id, artwork, artwork.File);
        }
    }
}
