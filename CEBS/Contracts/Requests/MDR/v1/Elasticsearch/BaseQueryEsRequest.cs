namespace CEBS.Contracts.Requests.MDR.v1.Elasticsearch;

public class BaseQueryEsRequest
{
    public int? Page { get; set; } = 1;
    public int? Size { get; set; } = 10;
    public object[]? Filters { get; set; } = Array.Empty<object>();
}