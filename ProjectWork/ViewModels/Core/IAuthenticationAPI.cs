using ProjectWork.Models.Core.Authentication;

namespace ProjectWork.ViewModels.Core;

public interface IAuthenticationAPI
{
    public LoginResponse UserSession { get; set; }
    public bool SaveSession { get; set; }
    public Task<(bool status, string message)> AuthenticateUser(LoginModel loginModel);
    public Task<(bool status, string message)> RegistrationUser(RegistrationModel registrationModel);
    public Task<(bool status, string message)> SendRequest<T>(T element, string toPath);
    void LogOut();
    public Task CheckIsLogged();
}