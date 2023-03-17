using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using ProjectWork.Models.Core.Authentication;
using ProjectWork.Models.Core.User;
using ProjectWork.Utilities;

namespace ProjectWork.Services.Core;

public class HeadersBuilder : IHeadersBuilder
{
    private readonly HttpClient _httpClient;

    public HeadersBuilder(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddAuthenticationToken()
    {
        AuthTokens tokenResponse;
        var inMemory = false;
        if (App.Authentication.UserSession is not null)
        {
            tokenResponse = new AuthTokens
            {
                AccessToken = App.Authentication.UserSession.AccessToken,
                RefreshToken = App.Authentication.UserSession.RefreshToken
            };
        }
        else
        {
            var stringStorage = await SecureStorage.GetAsync(nameof(AuthTokens));
            if (stringStorage.IsNullOrEmpty()) return;

            tokenResponse = JsonSerializer.Deserialize<AuthTokens>(stringStorage);
            inMemory = true;
        }

        if (await CheckRefreshToken(tokenResponse))
            await UpdateNewToken(tokenResponse, inMemory);
        else
            throw new Exception("Session timeout - return(out) it");
    }

    public void AddMediaTypeJson()
    {
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public void ClearRequestHeaders()
    {
        _httpClient.DefaultRequestHeaders.Clear();
    }

    private async Task UpdateNewToken(AuthTokens tokens, bool inMemory)
    {
        if (inMemory) await SecureStorage.SetAsync(nameof(AuthTokens), JsonSerializer.Serialize(tokens));
        var user = await _httpClient.GetFromJsonAsync<UserModel>(Endpoints.GetUserEndpoint());
        App.Authentication.UserSession = new LoginResponse
        {
            AccessToken = tokens.AccessToken,
            RefreshToken = tokens.RefreshToken,
            User = user
        };
    }

    private async Task<bool> CheckRefreshToken(AuthTokens tokens)
    {
        if (IsValid(tokens.AccessToken))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", tokens.AccessToken);
            return true;
        }

        var response = await _httpClient.PostAsJsonAsync(Endpoints.GetRefreshTokenEndpoint(),
            new { refresh = tokens.RefreshToken });
        var refreshResult = await response.Content.ReadFromJsonAsync<RefreshResponse>();
        if (refreshResult.AccessToken is null) return false;
        ClearRequestHeaders();
        AddMediaTypeJson();
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", refreshResult.AccessToken);
        tokens.AccessToken = refreshResult.AccessToken;
        return true;
    }

    private static bool IsValid(string token)
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

    public HttpClient GetHttpClient()
    {
        return _httpClient;
    }
}

public class RefreshResponse
{
    [JsonPropertyName("access")] public string AccessToken { get; set; }

    [JsonPropertyName("access_token_expiration")]
    public DateTime AccessTokenExpiration { get; set; }
}