using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;
using ProjectWork.Models.Core;
using ProjectWork.Models.Core.Authentication;
using ProjectWork.Models.Core.User;
using ProjectWork.Services.Core;
using ProjectWork.Utilities;

namespace ProjectWork.ViewModels.Core;

public class DRFAuthentication : AuthenticationBase
{
    public DRFAuthentication(IServiceAPI service) : base(service)
    {
    }

    public override async Task<(bool status, string message)> AuthenticateUser(LoginModel loginModel)
    {
        Service.Uri.Path = Endpoints.GetLoginPath();
        try
        {
            var result = await Service.PostItemAsJsonAsync<LoginModel, LoginResponse>(loginModel);
            UserSession = result ?? throw new Exception("None result");
            if (!SaveSession) return (true, "Login success");
            var userBasicInfo = JsonSerializer.Serialize(result);
            await SecureStorage.SetAsync(nameof(LoginResponse), userBasicInfo);
            return (true, "Login success");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return (false, e.Message + "We apologize for the inconvenience");
        }
    }

    public override async Task<(bool status, string message)> RegistrationUser(RegistrationModel registrationModel)
    {
        Service.Uri.Path = Endpoints.GetRegisterPath();
        try
        {
            var result =
                await Service.AddItemAsMultipartAsync<RegistrationModel, LoginResponse>(registrationModel,
                    registrationModel.ProfilePicture);
            UserSession = result ?? throw new Exception("None Result");
            if (!SaveSession) return (true, "Registration Successfully");
            var userBasicInfo = JsonSerializer.Serialize(result);
            await SecureStorage.SetAsync(nameof(LoginResponse), userBasicInfo);
            return (true, "Registration Successfully");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return (false, e.Message);
        }
    }

    public async Task<(bool status, string message)> UpdateUserAccount(UserEditModel userEdit, IBrowserFile file)
    {
        Service.Uri.Path = Endpoints.GetUserPath();
        try
        {
            var result = await Service.UpdateAsMultipartAsync<UserEditModel, UserModel>(userEdit, file);
            UserSession.User = result ?? throw new Exception("None Result");
            if (result is null) throw new Exception("Update error");
            return (true, "Updated Account Successfully");
        }
        catch (Exception e)
        {
            return (false, e.Message);
        }
    }

    public override void LogOut()
    {
        SecureStorage.Default.RemoveAll();
        UserSession = null;
    }

    public override async Task CheckIsLogged()
    {
        //Todo
        var userStored = await SecureStorage.GetAsync(nameof(LoginResponse));
        if (userStored is null) return;
        var loginResponse = JsonSerializer.Deserialize<LoginResponse>(userStored);
    }

    public override async Task<(bool status, string message)> SendRequest<T>(T element, string toPath)
    {
        Service.Uri.Path = toPath;
        try
        {
            var result = await Service.PostItemAsJsonAsync<T, T>(element);
            if (result is null) throw new Exception("Request message error");
            return (true, "Request Success");
        }
        catch (Exception e)
        {
            return (false, e.Message);
        }
    }

    public async Task<(bool status, string messge)> AddFavorite(int artworkId)
    {
        Service.Uri.Path = Endpoints.GetFavoritesEndpoint();
        try
        {
            if (App.Authentication.UserSession.User == null)
                throw new Exception("Couldn't find user details please make sure to be logged in");
            var result = await Service.PostItemAsJsonAsync<FavoriteModel, FavoriteResultModel>(new FavoriteModel
            {
                UserId = App.Authentication.UserSession.User.Id,
                ArtworkId = artworkId
            });
            if (result is null) throw new Exception("Error during the post request");

            return (true, "Request successful");
        }
        catch (Exception exception)
        {
            return (false, exception.Message);
        }
    }

    public async Task<(bool status, string message)> RemoveFavorite(int favoriteId)
    {
        Service.Uri.Path = Endpoints.GetFavoritesEndpoint();
        try
        {
            if (UserSession.User == null)
                throw new Exception("Couldn't find user details please make sure to be logged in");
            await Service.DeleteItemAsync(favoriteId);

            return (true, "Deletion successful");
        }
        catch (Exception exception)
        {
            return (false, exception.Message);
        }
    }

    public async Task<bool> IsAFavorite(int artworkId)
    {
        Service.Uri.Path = Endpoints.GetFavoritesEndpoint();

        if (UserSession.User == null)
            throw new Exception("Couldn't find user details please make sure to be logged in");

        var parameters = new Dictionary<string, string>
        {
            { "artwork", artworkId.ToString() },
            { "user", UserSession.User.Id.ToString() }
        };
        try
        {
            //?artwork=2&user=23
            var genericData = await Service.GetDataWithParamAsync<GenericData<FavoriteResultModel>>(parameters);
            return genericData.Count == 0;
        }
        catch (Exception exception)
        {
            Debug.WriteLine($"Exception thrown in Is a favorite method: {exception.Message}");
            throw;
        }
    }
}