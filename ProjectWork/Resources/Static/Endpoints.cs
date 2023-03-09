namespace ProjectWork.Resources.Static;

public static class Endpoints
{
    //Set the ip of your local host
    //private static readonly string _url = "http://localhost:80";
    private static readonly string _url = "http://192.168.192.149:80";

    public static string getArtworkEndpoint()
    {
        return _url + "/api/artworks/";
    }

    public static string getAccountEndpoint()
    {
        return _url + "/api/accounts/";
    }
}