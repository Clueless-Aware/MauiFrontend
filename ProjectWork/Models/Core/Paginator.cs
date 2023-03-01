using ProjectWork.Utilities;

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
        private readonly int pageSize = 50;

        public int TotalPages { get => totalPages; }
        public int PageIndex { get => pageIndex; set => pageIndex = value; }
        internal void SetActualState(Parameters parameters, Func<Task> getGenericDataFromPageAsync, int totalObjects)
        {
            _parametersP = parameters;
            pageIndex = Convert.ToInt32(parameters.dictionary["page"]);
            GetData = getGenericDataFromPageAsync;
            var temp = (double)totalObjects / pageSize;
            totalPages = (int)Math.Ceiling(temp);
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
            if (page <= totalPages && page > 0)
            {

                _parametersP.dictionary["page"] = page.ToString();
                await GetData();
            }
            await UtilyToolkit.CreateToast("Warning page number out of bounds");
        }
    }
}