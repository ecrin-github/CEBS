using CEBS.Contracts.Requests.MDM.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Services.Object;
using CEBS.Interfaces.MDM.Services.Study;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Filtering;

public class FilteringApiController : BaseMdmApiController
{
    private readonly IDataObjectService _dataObjectService;
    private readonly IStudyService _studyService;

    public FilteringApiController(
        IDataObjectService dataObjectService,
        IStudyService studyService)
    {
        _dataObjectService = dataObjectService ?? throw new ArgumentNullException(nameof(dataObjectService));
        _studyService = studyService ?? throw new ArgumentNullException(nameof(studyService));
    }

    
    [HttpPost("pagination/studies")]
    [SwaggerOperation(Tags = new []{"Pagination"})]
    public async Task<IActionResult> PaginateStudies(PaginationRequest paginationRequest)
    {
        var data = await _studyService.PaginateStudies(paginationRequest);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<StudyDto>
        {
            Total = data.Total,
            Data = data.Data,
            Page = paginationRequest.Page,
            Size = paginationRequest.Size,
            StatusCode = NotFound().StatusCode,
            Messages = new [] {"No studies have been found."}
        });
        return Ok(new ApiResponse<StudyDto>
        {
            Total = data.Total,
            Data = data.Data,
            Page = paginationRequest.Page,
            Size = paginationRequest.Size,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }

    [HttpPost("pagination/data-objects")]
    [SwaggerOperation(Tags = new []{"Pagination"})]
    public async Task<IActionResult> PaginateObjects(PaginationRequest paginationRequest)
    {
        var data = await _dataObjectService.PaginateDataObjects(paginationRequest);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>
        {
            Total = data.Total,
            Data = data.Data,
            Page = paginationRequest.Page,
            Size = paginationRequest.Size,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"No data objects have been found."}
        });
        return Ok(new ApiResponse<DataObjectDto>
        {
            Total = data.Total,
            Data = data.Data,
            Page = paginationRequest.Page,
            Size = paginationRequest.Size,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }

    [HttpPost("filter/studies/by-title")]
    [SwaggerOperation(Tags = new []{"Filtering - by title"})]
    public async Task<IActionResult> FilterStudiesByTitle(FilteringByTitleRequest filteringByTitleRequest)
    {
        var data = await _studyService.FilterStudiesByTitle(filteringByTitleRequest);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<StudyDto>
        {
            Total = data.Total,
            Data = data.Data,
            Page = filteringByTitleRequest.Page,
            Size = filteringByTitleRequest.Size,
            StatusCode = NotFound().StatusCode,
            Messages = new [] {"No studies have been found."}
        });
        return Ok(new ApiResponse<StudyDto>
        {
            Total = data.Total,
            Data = data.Data,
            Page = filteringByTitleRequest.Page,
            Size = filteringByTitleRequest.Size,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpPost("filter/data-objects/by-title")]
    [SwaggerOperation(Tags = new []{"Filtering - by title"})]
    public async Task<IActionResult> FilterObjectsByTitle(FilteringByTitleRequest filteringByTitleRequest)
    {
        var data = await _dataObjectService.FilterDataObjectsByTitle(filteringByTitleRequest);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>
        {
            Total = data.Total,
            Data = data.Data,
            Page = filteringByTitleRequest.Page,
            Size = filteringByTitleRequest.Size,
            StatusCode = NotFound().StatusCode,
            Messages = new [] {"No data objects have been found."}
        });
        return Ok(new ApiResponse<DataObjectDto>
        {
            Total = data.Total,
            Data = data.Data,
            Page = filteringByTitleRequest.Page,
            Size = filteringByTitleRequest.Size,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
}