namespace ProjectWork.Services.Core
{
    public interface IHeadersBuilder
    {
        Task AddAuthenticationToken();
        void AddMediaType();
        void ClearRequestHeaders();
    }
}