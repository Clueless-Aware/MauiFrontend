namespace ProjectWork.Utilities;

public static class Endpoints
{
    //Set the ip of your local host
    public const string SiteUrl = "http://localhost:80";

    //public const string SiteUrl = "http://192.168.30.184:80";
    //public const string SiteUrl = "http://192.168.1.182:80";

    public static string GetArtworkEndpoint()
    {
        return SiteUrl + "/api/artworks/";
    }

    public static string GetRequestsEndpoint()
    {
        return "/api/requests/";
    }

    public static string GetPasswordResetEndpoint()
    {
        return "api/auth/password/reset/";
    }

    public static string GetRefreshTokenEndpoint()
    {
        return SiteUrl + "/api/auth/token/refresh/";
    }

    public static string GetResetPasswordConfirm()
    {
        return "api/auth/password/reset/confirm/";
    }

    public static string GetFavoritesEndpoint()
    {
        return "/api/favorites/";
    }
}