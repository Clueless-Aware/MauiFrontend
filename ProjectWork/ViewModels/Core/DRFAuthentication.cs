using System.Text.Json;
using ProjectWork.Models.Core;
using ProjectWork.Models.Core.Authentication;
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
        Service.Uri.Path = "api/auth/login/";
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
        Service.Uri.Path = "api/auth/registration/";
        try
        {
            var result = await Service.AddItemAsMultipartAsync<RegistrationModel, LoginResponse>(registrationModel, registrationModel.ProfilePicture);
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
            if (result is null)
            {
                throw new Exception("Request message error");
            }
            return (true, "Request Success");

        }
        catch (Exception e)
        {
            return (false,e.Message);
        }

    }
}