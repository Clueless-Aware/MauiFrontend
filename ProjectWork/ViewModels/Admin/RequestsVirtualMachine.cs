using ProjectWork.Models.Requests;
using ProjectWork.Services.Core;
using ProjectWork.Utilities;

namespace ProjectWork.ViewModels.Admin;

public class RequestsVirtualMachine : BaseViewModel<RequestModel>
{
    private readonly ServiceAPI _requestsService =
        new(Endpoints.GetRequestsEndpoint());

    public override Task<(bool status, string message)> GetGenericDataFromPageAsync()
    {
        throw new NotImplementedException();
    }

    public override Task<(bool status, string message)> AddItemAsync(RequestModel artist)
    {
        throw new NotImplementedException();
    }

    public override Task<(bool status, string message)> UpdateItemAsync(RequestModel artist)
    {
        throw new NotImplementedException();
    }

    public override Task<RequestModel> GetItemAsync(int id)
    {
        throw new NotImplementedException();
    }

    public override Task<(bool status, string message)> DeleteItemAsync(int idItem)
    {
        throw new NotImplementedException();
    }
}