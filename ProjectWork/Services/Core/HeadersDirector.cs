namespace ProjectWork.Services.Core
{
    public class HeadersDirector
    {
        private IHeadersBuilder _builder;
        public IHeadersBuilder Builder
        {
            set { _builder = value; }
        }
        public void BuildGenericGetHeader()
        {
            _builder.ClearRequestHeaders();
            _builder.AddMediaType();
        }

        internal void AuthenticatedHeader()
        {
            BuildGenericGetHeader();
            _builder.AddAuthenticationToken();
        }
    }
}