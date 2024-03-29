﻿using ProjectWork.Models.Core;

namespace ProjectWork.ViewModels;

public interface IViewModel<T>
{
    //For ListView
    GenericData<T> GenericData { get; set; }
    Parameters Parameters { get; set; }

    Paginator Paginator { get; set; }

    //For Anti-Spam
    bool IsBusy { get; set; }
    Task<(bool status, string message)> GetGenericDataFromPageAsync();

    //For AddItem
    Task<(bool status, string message)> AddItemAsync(T artist);

    //For deleteItem
    Task<(bool status, string message)> DeleteItemAsync(int id);

    //For UpdateItem
    Task<(bool status, string message)> UpdateItemAsync(T artist);
}