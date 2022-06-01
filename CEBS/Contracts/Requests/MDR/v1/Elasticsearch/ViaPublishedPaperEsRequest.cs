namespace CEBS.Contracts.Requests.MDR.v1.Elasticsearch;

public class ViaPublishedPaperEsRequest : BaseQueryEsRequest
{
    public string SearchType { get; set; } = "title";
    public string SearchValue { get; set; } = string.Empty;
}