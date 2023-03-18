namespace ProjectWork.Utilities;

public static class Endpoints
{
    //Set the ip of your local host
    //public const string SiteUrl = "http://localhost:80";
    //public const string SiteUrl = "http://51.103.212.24:80";
    public const string SiteUrl = "https://bacchus.switzerlandnorth.cloudapp.azure.com";

    /// <summary>
    ///     Endpoints return the full absolute URL
    /// </summary>
    /// <returns></returns>

    #region Endpoints

    public static string GetArtworkEndpoint()
    {
        return SiteUrl + "/api/artworks/";
    }

    public static string GetArtistEndpoint()
    {
        return SiteUrl + "/api/artists/";
    }

    public static string GetPasswordResetEndpoint()
    {
        return "api/auth/password/reset/";
    }

    public static string GetRequestsEndpoint()
    {
        return SiteUrl + "/api/requests/";
    }

    public static string GetRefreshTokenEndpoint()
    {
        return SiteUrl + "/api/auth/token/refresh/";
    }

    public static string GetUserEndpoint()
    {
        return SiteUrl + "/api/auth/user/";
    }

    #endregion

    /// <summary>
    ///     Path always return just the last path of the url
    /// </summary>
    /// <returns></returns>

    #region Paths

    public static string GetBookmarksPath()
    {
        return "/api/bookmarks/";
    }

    public static string GetResetPasswordConfirmPath()
    {
        return "api/auth/password/reset/confirm/";
    }

    public static string GetArtistPath()
    {
        return "api/artists/";
    }


    public static string GetLoginPath()
    {
        return "api/auth/login/";
    }

    public static string GetRegisterPath()
    {
        return "api/auth/registration/";
    }

    public static string GetArtworkPath()
    {
        return "/api/artworks/";
    }

    public static string GetRequestsPath()
    {
        return "/api/requests/";
    }

    public static string GetUserPath()
    {
        return "api/auth/user/";
    }

    #endregion
}