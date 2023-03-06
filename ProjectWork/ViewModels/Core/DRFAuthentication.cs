using System.Text;
using System.Text.Json;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectWork.Models.Core.Authentication;
using ProjectWork.Services.Core;
using ProjectWork.Utilities;

namespace ProjectWork.ViewModels.Core
{
    public class DRFAuthentication : AuthenticationBase
    {
        public DRFAuthentication(IServiceAPI service) : base(service)
        {
        }

        public override async Task<bool> AuthenticateUser(LoginModel loginModel)
        {
            Service.Uri.Path = "api/auth/login/";
            var result = await Service.PostItemAsJsonAsync<LoginModel, LoginResponse>(loginModel);
            if (result is null) return false;
            UserSession = result;
            if (!SaveSession) return true;
            var userBasicInfo = JsonSerializer.Serialize(result);
            await SecureStorage.SetAsync(nameof(LoginResponse), userBasicInfo);
            return true;

        }

        public override async Task<bool> RegistrationUser(RegistrationModel registrationModel)
        {
            Service.Uri.Path = "api/auth/registration/";

            

            var result = await Service.PostItemAsJsonAsync<RegistrationModel, LoginResponse>(registrationModel);
            if (result is null) return false;
            UserSession = result;
            if (!SaveSession) return true;
            var userBasicInfo = JsonSerializer.Serialize(result);
            await SecureStorage.SetAsync(nameof(LoginResponse), userBasicInfo);
            return true;
        }

        public override void LogOut()
        {
            SecureStorage.Default.RemoveAll();
            UserSession = null;
        }
        
        public override async Task ChecKIsLogged()
        {
            var userStored = await SecureStorage.GetAsync(nameof(LoginResponse));
            if (userStored is null) return;
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(userStored);

        }
    }
}
