namespace ProjectWork.Data.ViewModels
{
    public interface IViewModel<T>
    {
        List<T> Items { get; set; }

        Task CreateItem(T item);
        Task ReadItems();
        Task UpdateItem(T item);
        Task DeleteItem(T item);

    }
}