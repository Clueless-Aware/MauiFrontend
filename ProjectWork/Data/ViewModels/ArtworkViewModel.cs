using CommunityToolkit.Mvvm.ComponentModel;
using ProjectWork.Data.Services;
using ProjectWork.Models;
using System.Diagnostics;

namespace ProjectWork.Data.ViewModels
{
    public class ArtworkViewModel : ObservableRecipient
    {
        private readonly ArtworkService _artworkService = new(url: "http://127.0.0.1:443/api/artworks/");
        private List<ArtwokDownload> _artworks = new();
        private Artwork _movie;

        public Artwork Artwork
        {
            get => _movie;
            set => SetProperty(ref _movie, value);
        }
        public List<ArtwokDownload> Items
        {
            get => _artworks;
            set => SetProperty(ref _artworks, value);
        }

        public async Task ReadItems()
        {
            Debug.WriteLine("READ");
            Items = await _artworkService.GetItems();
        }

        public async Task DeleteItem(int id)
        {
            Debug.WriteLine("DELETE");
            var response = await _artworkService.DeleteItem(id);
            Debug.WriteLine(response.message);
            if (response.status)
            {
                await ReadItems();
            }

        }
        public async Task CreateItem(ArtworkUpload artwork)
        {
            Debug.WriteLine("CREATE");
            var response = await _artworkService.AddItem(artwork);
            Debug.WriteLine(response.message);
            if (response.status)
            {
                await ReadItems();
            }
        }



        public async Task UpdateItem(int id, ArtwokDownload item)
        {
            Debug.WriteLine("UPDATE");
            var response = await _artworkService.PutItem(id, item);
            Debug.WriteLine(response.message);
            if (response.status)
            {
                await ReadItems();
            }
        }

    }
}
