namespace CEBS.Contracts.Requests.MDR.v1.Elasticsearch;

public class StudyCharacteristicsEsRequest : BaseQueryEsRequest
{
    public string TitleContains { get; set; } = string.Empty;
    public string LogicalOperator { get; set; } = "and";
    public string TopicsInclude { get; set; } = string.Empty;
}