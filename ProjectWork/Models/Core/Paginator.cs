using ProjectWork.Utilities;

namespace ProjectWork.Models.Core;

/// <summary>
///     Manage the pagination of generic data and make the new request
/// </summary>
public class Paginator
{
    private readonly int pageSize = 50;
    private Parameters _parametersP;

    private Func<Task> GetData;

    public int TotalPages { get; private set; }

    public int PageIndex { get; set; } = 1;

    internal void SetActualState(Parameters parameters, Func<Task> getGenericDataFromPageAsync, int totalObjects)
    {
        _parametersP = parameters;
        PageIndex = Convert.ToInt32(parameters.dictionary["page"]);
        GetData = getGenericDataFromPageAsync;
        var temp = (double)totalObjects / pageSize;
        TotalPages = (int)Math.Ceiling(temp);
    }

    public async Task NextData()
    {
        if (PageIndex < TotalPages)
        {
            PageIndex++;
            _parametersP.dictionary["page"] = PageIndex.ToString();
            await GetData();
        }
    }

    public async Task PreviousData()
    {
        if (PageIndex > 1)
        {
            PageIndex--;
            _parametersP.dictionary["page"] = PageIndex.ToString();
            await GetData();
        }
    }

    public async Task JumpTo(int page = 1)
    {
        if (page <= TotalPages && page > 0)
        {
            _parametersP.dictionary["page"] = page.ToString();
            await GetData();
        }
        else
        {
            await UtilyToolkit.CreateToast("Warning page number out of bounds");
        }
    }
}