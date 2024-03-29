﻿using CommunityToolkit.Mvvm.ComponentModel;
using ProjectWork.Models.Core;

namespace ProjectWork.ViewModels;

public abstract class BaseViewModel<T> : ObservableRecipient, IViewModel<T>
{
    private GenericData<T> _genericData = new();

    private bool _isBusy;
    private Paginator _paginator = new();
    private Parameters _parameters = new();

    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    public Parameters Parameters
    {
        get => _parameters;
        set => SetProperty(ref _parameters, value);
    }

    public Paginator Paginator
    {
        get => _paginator;
        set => SetProperty(ref _paginator, value);
    }

    public GenericData<T> GenericData
    {
        get => _genericData;
        set => SetProperty(ref _genericData, value);
    }

    public abstract Task<(bool status, string message)> GetGenericDataFromPageAsync();
    public abstract Task<(bool status, string message)> DeleteItemAsync(int idItem);

    public abstract Task<(bool status, string message)> AddItemAsync(T artist);
    public abstract Task<(bool status, string message)> UpdateItemAsync(T artist);
    public abstract Task<T> GetItemAsync(int id);
}