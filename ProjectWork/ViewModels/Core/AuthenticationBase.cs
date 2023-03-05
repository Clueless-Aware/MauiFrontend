using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectWork.Models.Core.Authentication;
using ProjectWork.Services.Core;

namespace ProjectWork.ViewModels.Core
{
    public abstract class AuthenticationBase : ObservableRecipient,IAuthenticationAPI
    {
        public IServiceAPI Service { get; }
        private bool _isAuthenticated;
        private LoginResponse _userSession;
        private bool _saveSession;

        protected AuthenticationBase(IServiceAPI service)
        {
            this.Service = service;
        }

        public LoginResponse UserSession
        {
            get => _userSession;
            set => SetProperty(ref _userSession, value);
        }

        LoginResponse IAuthenticationAPI.UserSession
        {
            get => UserSession;
            set => UserSession = value;
        }

        public bool SaveSession
        {
            get => _saveSession;
            set => SetProperty(ref _saveSession, value);
        }

        public abstract Task<bool> AuthenticateUser(LoginModel loginModel);

        public abstract void LogOut();

        public abstract Task ChecKIsLogged();

    }
}
