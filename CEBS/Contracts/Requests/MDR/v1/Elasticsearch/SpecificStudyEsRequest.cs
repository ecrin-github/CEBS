namespace CEBS.Contracts.Requests.MDR.v1.Elasticsearch;

public class SpecificStudyEsRequest : BaseQueryEsRequest
{
    public int SearchType { get; set; } = 13;
    public string SearchValue { get; set; } = string.Empty;
}