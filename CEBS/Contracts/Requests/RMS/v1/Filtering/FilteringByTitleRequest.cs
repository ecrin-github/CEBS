namespace CEBS.Contracts.Requests.RMS.v1.Filtering;

public class FilteringByTitleRequest : PaginationRequest
{
    public string? Title { get; set; }
}