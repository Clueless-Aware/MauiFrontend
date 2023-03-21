using CommunityToolkit.Mvvm.ComponentModel;
using ProjectWork.Models.Core.Authentication;
using ProjectWork.Services.Core;

namespace ProjectWork.ViewModels.Core;

public abstract class AuthenticationBase : ObservableRecipient, IAuthenticationAPI
{
    private bool _saveSession;
    private LoginResponse _userSession;

    protected AuthenticationBase(IServiceAPI service)
    {
        Service = service;
    }

    protected IServiceAPI Service { get; }

    public LoginResponse UserSession
    {
        get => _userSession;
        set => SetProperty(ref _userSession, value);
    }

    public bool SaveSession
    {
        get => _saveSession;
        set => SetProperty(ref _saveSession, value);
    }

    public abstract Task<(bool status, string message)> AuthenticateUser(LoginModel loginModel);

    public abstract void LogOut();

    public abstract Task<(bool status, string message)> UserRegistration(RegistrationModel registrationModel);
    public abstract Task<(bool status, string message)> SendRequest<T>(T element, string toPath);
}