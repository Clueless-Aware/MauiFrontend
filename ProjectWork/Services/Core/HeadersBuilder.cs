using System.Net.Http.Headers;

namespace ProjectWork.Services.Core
{
    public class HeadersBuilder : IHeadersBuilder
    {
        private HttpClient _httpClient;
        public HeadersBuilder(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void AddAuthenticationToken()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0b2tlbl90eXBlIjoiYWNjZXNzIiwiZXhwIjoxNjc3NDExMDQyLCJpYXQiOjE2Nzc0MTA3NDIsImp0aSI6Ijc2Y2YwNTk0NDMyNjRlNGJhMDI4ZmUxOTg5YTExNDI5IiwidXNlcl9pZCI6MX0.y5iOZW36LIOGQiz1N58SriY8dPh3ABUh5ikE3QlUP5w");
        }

        public void AddMediaType()
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void ClearRequestHeaders()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
        }
        public HttpClient GetHttpClient()
        {
            return _httpClient;
        }
    }
}