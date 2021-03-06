using System.Text.Json;
using CEBS.Configs;
using CEBS.Contracts.Requests.MDR.v1.Elasticsearch;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDR.DTO.v1.StudyListResponse;
using CEBS.Interfaces.MDR.Services;
using CEBS.Models.MDR.Study;
using Nest;

namespace CEBS.Services.MDR;

public class ElasticsearchService : IElasticsearchService
{
    private static int? CalculateStartFrom(int? page, int? pageSize)
    {
        if (page == null && pageSize == null) return null;
        var startFrom = ((page + 1) * pageSize) - pageSize;
        if (startFrom == 1 && pageSize == 1)
        {
            startFrom = 0;
        }

        return startFrom;
    }

    private static ElasticClient GetConnection()
    {
        var settings = new ConnectionSettings(new Uri(ElasticsearchConfigs.Url));
        return new ElasticClient(settings);
    }

    private static bool HasProperty(object obj, string propertyName)
    {
        if (obj == null) return false;
        return obj.GetType().GetProperty(propertyName) != null;
    }


    public async Task<BaseResponse<StudyListResponse>> GetSpecificStudy(SpecificStudyEsRequest specificStudyRequest)
    {
        var startFrom = CalculateStartFrom(specificStudyRequest.Page, specificStudyRequest.Size);

        var identifierValue = specificStudyRequest.SearchValue.ToUpper().Trim();

        List<QueryContainer> filters = null;
        if (HasProperty(specificStudyRequest, "Filters") && specificStudyRequest.Filters != null)
        {
            filters = specificStudyRequest.Filters.Select(param => new RawQuery(JsonSerializer.Serialize(param)))
                .Select(dummy => (QueryContainer)dummy).ToList();
        }

        var queryClause = new List<QueryContainer>
        {
            new NestedQuery()
            {
                Path = new Field("study_identifiers"),
                Query = new TermQuery()
                        {
                            Field = Infer.Field<Study>(p => p.StudyIdentifiers.First()
                                .IdentifierType.Id),
                            Value = specificStudyRequest.SearchType
                        } &&
                        new TermQuery()
                        {
                            Field = Infer.Field<Study>(p => p.StudyIdentifiers.First()
                                .IdentifierValue),
                            Value = identifierValue
                        }
            }
        };

        if (filters is { Count: > 0 })
        {
            queryClause.AddRange(filters);
        }

        var boolQuery = new BoolQuery()
        {
            Must = queryClause
        };

        SearchRequest<Study> searchRequest;
        if (startFrom != null)
        {
            searchRequest = new SearchRequest<Study>(Indices.Index(ElasticsearchConfigs.IndexName))
            {
                From = startFrom,
                Size = specificStudyRequest.Size,
                Query = boolQuery
            };
        }
        else
        {
            searchRequest = new SearchRequest<Study>(Indices.Index(ElasticsearchConfigs.IndexName))
            {
                Query = boolQuery
            };
        }

        var results = await GetConnection().SearchAsync<Study>(searchRequest);

        var studyListResponse = new List<StudyListResponse>();

        return new BaseResponse<StudyListResponse>();
    }

    public async Task<BaseResponse<StudyListResponse>> GetByStudyCharacteristics(
        StudyCharacteristicsEsRequest studyCharacteristicsRequest)
    {
        var startFrom = CalculateStartFrom(studyCharacteristicsRequest.Page, studyCharacteristicsRequest.Size);

        List<QueryContainer> filters = null;
        if (HasProperty(studyCharacteristicsRequest, "Filters") && studyCharacteristicsRequest.Filters != null)
        {
            filters = studyCharacteristicsRequest.Filters.Select(param => new RawQuery(JsonSerializer.Serialize(param)))
                .Select(dummy => (QueryContainer)dummy).ToList();
        }

        var queryClauses = new List<QueryContainer>();

        if (!string.IsNullOrEmpty(studyCharacteristicsRequest.TitleContains))
        {
            queryClauses.Add(new NestedQuery()
            {
                Path = Infer.Field<Study>(p => p.StudyTitles),
                Query = new SimpleQueryStringQuery()
                {
                    Fields = Infer.Field<Study>(f => f.StudyTitles.First().TitleText),
                    Query = studyCharacteristicsRequest.TitleContains,
                    DefaultOperator = Operator.And
                }
            });
        }

        if (!string.IsNullOrEmpty(studyCharacteristicsRequest.TopicsInclude))
        {
            queryClauses.Add(new NestedQuery()
            {
                Path = Infer.Field<Study>(p => p.StudyTopics),
                Query = new SimpleQueryStringQuery()
                {
                    Fields = Infer.Field<Study>(f => f.StudyTopics.First().MeshValue).And("original_value"),
                    Query = studyCharacteristicsRequest.TopicsInclude,
                    DefaultOperator = Operator.And
                }
            });
        }

        if (filters is { Count: > 0 })
        {
            queryClauses.AddRange(filters);
        }

        var logicalOperator = studyCharacteristicsRequest.LogicalOperator;
        if (string.IsNullOrEmpty(logicalOperator))
        {
            logicalOperator = "and";
        }

        BoolQuery boolQuery;
        if (logicalOperator == "and")
        {
            boolQuery = new BoolQuery()
            {
                Must = queryClauses
            };
        }
        else
        {
            boolQuery = new BoolQuery()
            {
                Should = queryClauses
            };
        }

        SearchRequest<Study> searchRequest;
        if (startFrom != null)
        {
            searchRequest = new SearchRequest<Study>(Indices.Index(ElasticsearchConfigs.IndexName))
            {
                From = startFrom,
                Size = studyCharacteristicsRequest.Size,
                Query = boolQuery
            };
        }
        else
        {
            searchRequest = new SearchRequest<Study>(Indices.Index(ElasticsearchConfigs.IndexName))
            {
                Query = boolQuery
            };
        }

        var results = await GetConnection().SearchAsync<Study>(searchRequest);

        var studyListResponse = new List<StudyListResponse>();

        return new BaseResponse<StudyListResponse>();
    }

    public async Task<BaseResponse<StudyListResponse>> GetViaPublishedPaper(
        ViaPublishedPaperEsRequest viaPublishedPaperRequest)
    {
        var startFrom = CalculateStartFrom(viaPublishedPaperRequest.Page, viaPublishedPaperRequest.Size);

        List<QueryContainer> filters = null;
        if (HasProperty(viaPublishedPaperRequest, "Filters") && viaPublishedPaperRequest.Filters != null)
        {
            filters = viaPublishedPaperRequest.Filters.Select(param => new RawQuery(JsonSerializer.Serialize(param)))
                .Select(dummy => (QueryContainer)dummy).ToList();
        }

        var mustQuery = new List<QueryContainer>();

        if (viaPublishedPaperRequest.SearchType == "doi")
        {
            mustQuery.Add(new TermQuery()
            {
                Field = Infer.Field<Study>(p => p.LinkedDataObjects.First().Doi),
                Value = viaPublishedPaperRequest.SearchValue
            });
        }
        else
        {
            var shouldClauses = new List<QueryContainer>
            {
                new NestedQuery()
                {
                    Path = Infer.Field<Study>(p => p.LinkedDataObjects.First().ObjectTitles.First().TitleText),
                    Query = new SimpleQueryStringQuery()
                    {
                        Query = viaPublishedPaperRequest.SearchValue,
                        Fields = Infer.Field<Study>(p => p.LinkedDataObjects.First().ObjectTitles.First().TitleText),
                        DefaultOperator = Operator.And
                    }
                }
            };
            mustQuery.Add(new BoolQuery()
            {
                Should = shouldClauses
            });
        }

        if (filters is { Count: > 0 })
        {
            mustQuery.AddRange(filters);
        }

        var boolQuery = new BoolQuery()
        {
            Must = mustQuery
        };

        SearchRequest<Study> searchRequest;
        if (startFrom != null)
        {
            searchRequest = new SearchRequest<Study>(Indices.Index(ElasticsearchConfigs.IndexName))
            {
                From = startFrom,
                Size = viaPublishedPaperRequest.Size,
                Query = boolQuery
            };
        }
        else
        {
            searchRequest = new SearchRequest<Study>(Indices.Index(ElasticsearchConfigs.IndexName))
            {
                Query = boolQuery
            };
        }

        var results = await GetConnection().SearchAsync<Study>(searchRequest);

        var studyListResponse = new List<StudyListResponse>();

        return new BaseResponse<StudyListResponse>();
    }

    public async Task<BaseResponse<StudyListResponse>> GetByStudyId(StudyIdEsRequest studyIdRequest)
    {
        var results = await GetConnection().SearchAsync<Study>(s => s
            .Index(ElasticsearchConfigs.IndexName)
            .From(0)
            .Size(1)
            .Query(q => q
                .Term(t => t
                    .Field(p => p.Id)
                    .Value(studyIdRequest.StudyId.ToString())
                )
            )
        );
        return new BaseResponse<StudyListResponse>();
    }
}