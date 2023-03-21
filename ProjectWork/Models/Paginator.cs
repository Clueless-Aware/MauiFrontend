using ProjectWork.Utilities;

namespace ProjectWork.Models.Core;

/// <summary>
///     Manage the pagination of generic data and make the new request
/// </summary>
public class Paginator
{
    private Func<Task> _getData;
    private int _pageSize = 25;
    private Parameters _parametersP;

    public int TotalPages { get; private set; }

    public int PageIndex { get; set; } = 1;

    internal void SetActualState(Parameters parameters,
        Func<Task> getGenericDataFromPageAsync, int totalObjects, int pageSize = 15)
    {
        _pageSize = pageSize;
        _parametersP = parameters;
        PageIndex = Convert.ToInt32(parameters.Dictionary["page"]);
        _getData = getGenericDataFromPageAsync;
        var temp = (double)totalObjects / _pageSize;
        TotalPages = (int)Math.Ceiling(temp);
    }

    public async Task NextData()
    {
        if (PageIndex < TotalPages)
        {
            PageIndex++;
            _parametersP.Dictionary["page"] = PageIndex.ToString();
            await _getData();
        }
    }

    public async Task PreviousData()
    {
        if (PageIndex > 1)
        {
            PageIndex--;
            _parametersP.Dictionary["page"] = PageIndex.ToString();
            await _getData();
        }
    }

    public async Task JumpTo(int page = 1)
    {
        if (page <= TotalPages && page > 0)
        {
            _parametersP.Dictionary["page"] = page.ToString();
            await _getData();
        }
        else
        {
            await UtilityToolkit.CreateToast("Warning page number out of bounds");
        }
    }
}