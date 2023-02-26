namespace ProjectWork.Services.Core
{
    public interface IHeadersBuilder
    {
        void AddAuthenticationToken();
        void AddMediaType();
        void ClearRequestHeaders();
    }
}