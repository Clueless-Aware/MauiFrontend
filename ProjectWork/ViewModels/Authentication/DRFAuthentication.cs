using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;
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
        Service.UriBuilder.Path = Endpoints.GetLoginPath();
        try
        {
            var result = await Service.PostItemAsJsonAsync<LoginModel, LoginResponse>(loginModel);
            UserSession = result ?? throw new Exception("None result");
            if (!SaveSession) return (true, "Login successful");
            SaveSession = false;

            var tokens = new AuthTokens
            {
                AccessToken = result.AccessToken,
                RefreshToken = result.RefreshToken
            };
            await SecureStorage.SetAsync(nameof(AuthTokens), JsonSerializer.Serialize(tokens));
            return (true, "Login successful");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return (false, "Error during login: " + e.Message + " We apologize for the inconvenience");
        }
    }

    public override async Task<(bool status, string message)> UserRegistration(RegistrationModel registrationModel)
    {
        Service.UriBuilder.Path = Endpoints.GetRegisterPath();
        try
        {
            var result =
                await Service.AddItemAsMultipartAsync<RegistrationModel, LoginResponse>(registrationModel,
                    registrationModel.ProfilePicture);

            UserSession = result ?? throw new Exception("None Result");
            if (!SaveSession) return (true, "Registration Successfully");
            SaveSession = false;

            var tokens = new AuthTokens
            {
                AccessToken = result.AccessToken,
                RefreshToken = result.RefreshToken
            };
            await SecureStorage.SetAsync(nameof(AuthTokens), JsonSerializer.Serialize(tokens));
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
        Service.UriBuilder.Path = Endpoints.GetUserPath();
        try
        {
            var result = await Service.UpdateAsMultipartAsync<UserEditModel, UserModel>(userEdit, file);
            UserSession.User = result ?? throw new Exception("None Result");
            if (result is null) throw new Exception("Update error got no answer from server");
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

    public override async Task<(bool status, string message)> SendRequest<T>(T element, string toPath)
    {
        Service.UriBuilder.Path = toPath;
        try
        {
            var result = await Service.PostItemAsJsonAsync<T, T>(element);
            if (result is null) throw new Exception("Request message error");
            return (true, "Request Successful");
        }
        catch (Exception e)
        {
            return (false, e.Message);
        }
    }

    public async Task<(bool status, string messge)> AddBookMark(int artworkId)
    {
        Service.UriBuilder.Path = Endpoints.GetBookmarksPath();
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
            await RefreshUserState();
            return (true, "Request successful");
        }
        catch (Exception exception)
        {
            return (false, exception.Message);
        }
    }

    public async Task<(bool status, string message)> RemoveBookmark(int bookmarkId)
    {
        Service.UriBuilder.Path = Endpoints.GetBookmarksPath() + bookmarkId + '/';
        try
        {
            await Service.DeleteItemAsync(bookmarkId);
            await RefreshUserState();
            return (true, "Deletion successful");
        }
        catch (Exception exception)
        {
            return (false, exception.Message);
        }
    }

    public async Task<(bool state, string message)> RefreshUserState()
    {
        Service.UriBuilder.Path = Endpoints.GetUserPath();
        try
        {
            var refreshedUser = await Service.GetDetailObject<UserModel>();
            if (refreshedUser is null) throw new Exception("Error during user refresh");
            UserSession.User = refreshedUser;

            //var stringStorage = await SecureStorage.GetAsync(nameof(LoginResponse));
            //if (stringStorage.IsNullOrEmpty()) return (true, string.Empty);

            //var loginResponse = JsonSerializer.Deserialize<LoginResponse>(stringStorage);
            //loginResponse.User = refreshedUser;
            //var userInfo = JsonSerializer.Serialize(loginResponse);

            //await SecureStorage.SetAsync(nameof(loginResponse), userInfo);

            return (true, string.Empty);
        }
        catch (Exception e)
        {
            return (false, e.Message);
        }
    }
}