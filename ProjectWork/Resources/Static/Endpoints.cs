namespace ProjectWork.Resources.Static;

public static class Endpoints
{
    private static readonly string _url = "http://127.0.0.1:8000";

    public static string getArtworkEndpoint()
    {
        return _url + "/api/artworks/";
    }

    public static string getAccountEndpoint()
    {
        return _url + "/api/accounts/";
    }
}