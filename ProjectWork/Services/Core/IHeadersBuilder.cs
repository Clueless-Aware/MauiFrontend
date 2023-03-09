namespace ProjectWork.Services.Core
{
    public interface IHeadersBuilder
    {
        Task AddAuthenticationToken();
        void AddMediaTypeJson();
        void ClearRequestHeaders();
    }
}