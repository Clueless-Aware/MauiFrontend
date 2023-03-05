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
            _builder.AddMediaType();
        }

        internal async Task AuthenticatedHeader()
        {
            BuildGenericGetHeader();
            await _builder.AddAuthenticationToken();
        }
    }
}