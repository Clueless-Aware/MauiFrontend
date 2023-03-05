using ProjectWork.Models.Core.Authentication;

namespace ProjectWork.ViewModels.Core
{
    public interface IAuthenticationAPI
    {

        public LoginResponse UserSession { get; set; }
        public bool SaveSession { get; set; }
        public Task<bool> AuthenticateUser(LoginModel loginModel);
        void LogOut();
        public Task ChecKIsLogged();
    }
}