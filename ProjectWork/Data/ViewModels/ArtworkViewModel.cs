using CommunityToolkit.Mvvm.ComponentModel;
using ProjectWork.Data.Services;
using ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Data.ViewModels
{
    public class ArtworkViewModel : ObservableRecipient, IViewModel<Artwork>
    {
        private readonly ArtworkService _artworkService = new(url: "http://127.0.0.1:443/api/artworks/");
        private List<Artwork> _artworks = new();
        private Artwork _movie;

        public Artwork Artwork
        {
            get => _movie;
            set => SetProperty(ref _movie, value);
        }
        public List<Artwork> Items
        {
            get => _artworks;
            set => SetProperty(ref _artworks, value);
        }

        public async Task ReadItems()
        {
            Debug.WriteLine("READ");
            Items = await _artworkService.GetItems();
        }

        public async Task DeleteItem(Artwork artwork)
        {
            Debug.WriteLine("DELETE");
            var response = await _artworkService.DeleteItem(artwork.Id);
            Debug.WriteLine(response.message);
            if (response.status)
            {
                await ReadItems();
            }

        }
        public async Task CreateItem(Artwork artwork)
        {
            Debug.WriteLine("CREATE");
            var response = await _artworkService.AddItem(artwork);
            Debug.WriteLine(response.message);
            if (response.status)
            {
                await ReadItems();
            }
        }



        public Task UpdateItem(Artwork item)
        {
            Debug.WriteLine("UPDATE");
            throw new NotImplementedException();
        }

    }
}
