using CEBS.Contracts.Requests.RMS.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.RMS.DTO.v1;
using CEBS.Interfaces.RMS.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.RMS.v1.Filtering;

public class FilteringApiController : BaseRmsApiController
{
    private readonly IDtpService _dtpService;
    private readonly IDupService _dupService;

    public FilteringApiController(
        IDtpService dtpService,
        IDupService dupService)
    {
        _dtpService = dtpService ?? throw new ArgumentNullException(nameof(dtpService));
        _dupService = dupService ?? throw new ArgumentNullException(nameof(dupService));
    }


    [HttpPost("pagination/dtp")]
    [SwaggerOperation(Tags = new[] { "Pagination" })]
    public async Task<IActionResult> PaginateStudies(PaginationRequest paginationRequest)
    {
        var data = await _dtpService.PaginateDtp(paginationRequest);
        if (data.Total == 0 && data.Data.Length == 0)
            return Ok(new ApiResponse<DtpDto>
            {
                Total = data.Total,
                Data = data.Data,
                Page = paginationRequest.Page,
                Size = paginationRequest.Size,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTPs have been found." }
            });
        return Ok(new ApiResponse<DtpDto>
        {
            Total = data.Total,
            Data = data.Data,
            Page = paginationRequest.Page,
            Size = paginationRequest.Size,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }

    [HttpPost("pagination/dup")]
    [SwaggerOperation(Tags = new[] { "Pagination" })]
    public async Task<IActionResult> PaginateObjects(PaginationRequest paginationRequest)
    {
        var data = await _dupService.PaginateDup(paginationRequest);
        if (data.Total == 0 && data.Data.Length == 0)
            return Ok(new ApiResponse<DupDto>
            {
                Total = data.Total,
                Data = data.Data,
                Page = paginationRequest.Page,
                Size = paginationRequest.Size,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUPs have been found." }
            });
        return Ok(new ApiResponse<DupDto>
        {
            Total = data.Total,
            Data = data.Data,
            Page = paginationRequest.Page,
            Size = paginationRequest.Size,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }

    [HttpPost("filter/dtp/by-title")]
    [SwaggerOperation(Tags = new[] { "Filtering - by title" })]
    public async Task<IActionResult> FilterDtpByTitle(FilteringByTitleRequest filteringByTitleRequest)
    {
        var data = await _dtpService.FilterDtpByTitle(filteringByTitleRequest);
        if (data.Total == 0 && data.Data.Length == 0)
            return Ok(new ApiResponse<DtpDto>
            {
                Total = data.Total,
                Data = data.Data,
                Page = filteringByTitleRequest.Page,
                Size = filteringByTitleRequest.Size,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTPs have been found." }
            });
        return Ok(new ApiResponse<DtpDto>
        {
            Total = data.Total,
            Data = data.Data,
            Page = filteringByTitleRequest.Page,
            Size = filteringByTitleRequest.Size,
            StatusCode = Ok().StatusCode,
            Messages = null
        });
    }

    [HttpPost("filter/dup/by-title")]
    [SwaggerOperation(Tags = new[] { "Filtering - by title" })]
    public async Task<IActionResult> FilterDupByTitle(FilteringByTitleRequest filteringByTitleRequest)
    {
        var data = await _dupService.FilterDupByTitle(filteringByTitleRequest);
        if (data.Total == 0 && data.Data.Length == 0)
            return Ok(new ApiResponse<DupDto>
            {
                Total = data.Total,
                Data = data.Data,
                Page = filteringByTitleRequest.Page,
                Size = filteringByTitleRequest.Size,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUPs have been found." }
            });
        return Ok(new ApiResponse<DupDto>
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