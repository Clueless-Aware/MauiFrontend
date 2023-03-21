namespace ProjectWork.Services.Core
{
    public class HeadersDirector
    {
        private IHeadersBuilder _builder;
        public IHeadersBuilder Builder
        {
            set => _builder = value;
        }
        public void BuildGenericGetHeader()
        {
            _builder.ClearRequestHeaders();
            _builder.AddMediaTypeJson();
        }

        internal async Task AuthenticatedHeader()
        {
            _builder.ClearRequestHeaders();
            await _builder.AddAuthenticationToken();
        }
    }
}