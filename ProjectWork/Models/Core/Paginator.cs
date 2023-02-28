namespace ProjectWork.Models.Core
{
    /// <summary>
    /// Manage the pagination of generic data and make the new request
    /// </summary>
    public class Paginator
    {
        Parameters _parametersP;

        private Func<Task> GetData;

        private int pageIndex = 1;

        private int totalPages;

        public int TotalPages { get => totalPages;}
        public int PageIndex { get => pageIndex; set => pageIndex = value; }
        internal void SetActualState( Parameters parameters, Func<Task> getGenericDataFromPageAsync,int totalInPage=1, int totalObjects=1)
        {
            _parametersP = parameters;
            pageIndex = Convert.ToInt32(parameters.dictionary["page"]);
            GetData = getGenericDataFromPageAsync;
            if (totalObjects>0 && totalObjects % totalInPage == 0)
            {
                totalPages = totalObjects / totalInPage;
            }
            else
            {
                if(totalInPage == 0)
                    totalPages= 1;
                else
                totalPages = totalObjects / totalInPage + 1;
            }
        }
        public async Task NextData()
        {
            if (pageIndex < totalPages)
            {
                pageIndex++;
                _parametersP.dictionary["page"] = pageIndex.ToString();
                await GetData();
            }
        }
        public async Task PreviousData()
        {
            if (pageIndex > 1)
            {
                pageIndex--;
                _parametersP.dictionary["page"] = pageIndex.ToString();
                await GetData();
            }
        }
        public async Task JumpTo(int page = 1)
        {
            if (page <= totalPages && page > 1)
            {

                _parametersP.dictionary["page"] = page.ToString();
                await GetData();
            }
        }
    }
}