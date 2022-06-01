namespace CEBS.Contracts.Requests.MDM.v1.Filtering;

public class FilteringByTitleRequest : PaginationRequest
{
    public string Title { get; set; } = string.Empty;
}