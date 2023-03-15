using ProjectWork.Models.Core;
using ProjectWork.Models.Requests;
using ProjectWork.Services.Core;
using ProjectWork.Utilities;

namespace ProjectWork.ViewModels.Admin;

public class RequestsVirtualMachine : BaseViewModel<RequestModel>
{
    private readonly ServiceAPI _requestsService =
        new(Endpoints.GetRequestsEndpoint());

    public override async Task<(bool status, string message)> GetGenericDataFromPageAsync()
    {
        try
        {
            GenericData =
                await _requestsService.GetDataWithParamAsync<GenericData<RequestModel>>(Parameters.Dictionary);
            return (true, "Successful get");
        }
        catch (Exception e)
        {
            await UtilityToolkit.CreateToast("Load of requests failed: " + e.Message);
            return (false, e.Message);
        }
    }

    public override Task<(bool status, string message)> AddItemAsync(RequestModel request)
    {
        throw new NotImplementedException();
    }

    public override Task<(bool status, string message)> UpdateItemAsync(RequestModel request)
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