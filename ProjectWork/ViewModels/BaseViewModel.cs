using CommunityToolkit.Mvvm.ComponentModel;
using ProjectWork.Models.Core;
namespace ProjectWork.ViewModels
{
    public abstract class BaseViewModel<T> : ObservableRecipient, IViewModel<T>
    {

        private bool isBusy ;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                SetProperty(ref isBusy, value);
            }
        }
        private Parameters _parameters = new();
        private GenericData<T> _genericData = new();
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

        public GenericData<T> GenericData
        {
            get => _genericData;
            set => SetProperty(ref _genericData, value);
        }
        public abstract Task GetGenericDataFromPageAsync();
        public abstract Task DeleteItemAsync(int idItem);

        public abstract Task AddItemAsync(T item);
        public abstract Task UpdateItemAsync(T item);
    }
}
