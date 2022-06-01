using CEBS.Configs;
using CEBS.Contracts.Requests.MDR.v1.Elasticsearch;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDR.DTO.v1.StudyListResponse;
using CEBS.Interfaces.MDR.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDR.v1;

public class ElasticsearchApiController : BaseMdrApiController
{
    private readonly IElasticsearchService _elasticsearchService;
    
    public ElasticsearchApiController(IElasticsearchService elasticsearchService)
    {
        _elasticsearchService = elasticsearchService ?? throw new ArgumentNullException(nameof(elasticsearchService));
    }

    [HttpPost("specific-study")]
    [SwaggerOperation(Tags = new[] { "ES - Search specific study" })]
    public async Task<IActionResult> GetSpecificStudy(SpecificStudyEsRequest specificStudyRequest)
    {
        var data = await _elasticsearchService.GetSpecificStudy(specificStudyRequest);
        return Ok(new ApiResponse<StudyListResponse>()
        {
            Total = data.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Page = specificStudyRequest.Page,
            Size = specificStudyRequest.Size,
            Data = data.Data
        });
    }

    
    [HttpPost("study-characteristics")]
    [SwaggerOperation(Tags = new[] { "ES - Search by study characteristics" })]
    public async Task<IActionResult> GetByStudyCharacteristics(StudyCharacteristicsEsRequest studyCharacteristicsRequest)
    {
        var data = await _elasticsearchService.GetByStudyCharacteristics(studyCharacteristicsRequest);
        return Ok(new ApiResponse<StudyListResponse>()
        {
            Total = data.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Page = studyCharacteristicsRequest.Page,
            Size = studyCharacteristicsRequest.Size,
            Data = data.Data
        });
    }
    
    
    [HttpPost("via-published-paper")]
    [SwaggerOperation(Tags = new[] { "ES - Search via published paper" })]
    public async Task<IActionResult> GetViaPublishedPaper(ViaPublishedPaperEsRequest viaPublishedPaperRequest)
    {
        var data = await _elasticsearchService.GetViaPublishedPaper(viaPublishedPaperRequest);
        return Ok(new ApiResponse<StudyListResponse>()
        {
            Total = data.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Page = viaPublishedPaperRequest.Page,
            Size = viaPublishedPaperRequest.Size,
            Data = data.Data
        });
    }
    
    
    [HttpPost("study")]
    [SwaggerOperation(Tags = new[] { "ES - Search by study ID" })]
    public async Task<IActionResult> GetByStudyId(StudyIdEsRequest studyIdRequest)
    {
        var data = await _elasticsearchService.GetByStudyId(studyIdRequest);
        return Ok(new ApiResponse<StudyListResponse>()
        {
            Total = data.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = data.Data
        });
    }
}