namespace ProjectWork.Resources.Static;

public static class Endpoints
{
    //Set the ip of your local host
    private static readonly string _url = "http://localhost:80";
    //private static readonly string _url = "http://192.168.30.184:80";
    //private static readonly string _url = "http://192.168.1.182:80";

    public static string GetArtworkEndpoint()
    {
        return _url + "/api/artworks/";
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
        return _url + "/api/auth/token/refresh/";
    }

    public static string GetResetPasswordConfirm()
    {
        return "api/auth/password/reset/confirm/";
    }

    public static string GetArtistEndpoint()
    {
        return _url + "/api/artists/";
    }
}