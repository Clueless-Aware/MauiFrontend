using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using ProjectWork.Models.Core.Authentication;
using ProjectWork.Utilities;

namespace ProjectWork.Services.Core
{
    public class HeadersBuilder : IHeadersBuilder
    {
        private HttpClient _httpClient;
        public HeadersBuilder(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddAuthenticationToken()
        {
            //SecureStorage.Default.RemoveAll();
            var loginResponse = new LoginResponse();
            bool inMemory = false;
            if (App.Authentication.UserSession is not null)
            {
                loginResponse = App.Authentication.UserSession;
            }
            else
            {
                var stringStorage = await SecureStorage.GetAsync(nameof(LoginResponse));
                if (stringStorage is null) return;
                loginResponse = JsonSerializer.Deserialize<LoginResponse>(stringStorage);
                inMemory = true;
            }

            if (await CheckRefreshToken(loginResponse))
            {
                await UpdateNewToken(loginResponse, inMemory);
            }
            else//se risposta negativa non aggiorna
            {
                await UtilityToolkit.CreateToast("Session timeout - reburn(out) it");
            }
        }

        private async Task UpdateNewToken(LoginResponse loginResponse, bool inMemory)
        {
            if (inMemory)
            {
                await SecureStorage.SetAsync(nameof(LoginResponse), JsonSerializer.Serialize(loginResponse));
            }
            App.Authentication.UserSession = loginResponse;
        }

        private async Task<bool> CheckRefreshToken(LoginResponse loginResponse)
        {
            if (IsValid(loginResponse.AccessToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", loginResponse.AccessToken);
                return true;
            }
            else
            {
                var response = await _httpClient.PostAsJsonAsync("http://localhost/api/auth/token/refresh/",
                    new { refresh = loginResponse.RefreshToken });
                var refreshResult = await response.Content.ReadFromJsonAsync<RefreshResponse>();
                if (refreshResult.AccessToken is null) return false;
                ClearRequestHeaders();
                AddMediaType();
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", refreshResult.AccessToken);
                loginResponse.AccessToken = refreshResult.AccessToken;
                return true;
            }
        }

        private bool IsValid(string token)
        {
            JwtSecurityToken jwtSecurityToken;
            try
            {
                jwtSecurityToken = new JwtSecurityToken(token);
            }
            catch (Exception)
            {
                return false;
            }

            return jwtSecurityToken.ValidTo > DateTime.UtcNow;
        }

        public void AddMediaType()
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void ClearRequestHeaders()
        {
            _httpClient.DefaultRequestHeaders.Clear();
        }
        public HttpClient GetHttpClient()
        {
            return _httpClient;
        }
    }

    public class RefreshResponse
    {
        [JsonPropertyName("access")]
        public string AccessToken { get; set; }
        [JsonPropertyName("access_token_expiration")]
        public DateTime AccessTokenExpiration { get; set; }
    }
}