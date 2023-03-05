using System.Text;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectWork.Models.Core.Authentication;
using ProjectWork.Services.Core;

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
            string userBasicInfo = JsonSerializer.Serialize(result);
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
