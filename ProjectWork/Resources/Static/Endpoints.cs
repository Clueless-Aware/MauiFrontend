namespace ProjectWork.Resources.Static;

public static class Endpoints
{
    //Set the ip of your local host
    //private static readonly string _url = "http://localhost:80";
    //private static readonly string _url = "http://192.168.30.138:80";
    private static readonly string _url = "http://192.168.30.184:80";

    public static string GetArtworkEndpoint()
    {
        return _url + "/api/artworks/";
    }

    public static string GetArtworkPath()
    {
        return "/api/artworks/";
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

    public static string GetUserPath()
    {
        return "api/auth/user/";
    }
}
