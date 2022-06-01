using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.Context.DTO.v1;
using CEBS.Interfaces.Context.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.Context.v1;

public class RmsContextApiController : BaseContextApiController
{

    private readonly IRmsContextService _rmsContextService;

    public RmsContextApiController(IRmsContextService rmsContextService)
    {
        _rmsContextService = rmsContextService ?? throw new ArgumentNullException(nameof(rmsContextService));
    }
    
    [HttpGet("rms/access-prereq-types")]
    [SwaggerOperation(Tags = new[] { "RMS Context - Access prereq types" })]
    public async Task<IActionResult> GetAccessPrereqTypes()
    {
        var data = await _rmsContextService.GetAccessPrereqTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("rms/access-prereq-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "RMS Context - Access prereq types" })]
    public async Task<IActionResult> GetAccessPrereqType(int id)
    {
        var data = await _rmsContextService.GetAccessPrereqType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("rms/check-status-types")]
    [SwaggerOperation(Tags = new[] { "RMS Context - Check status types" })]
    public async Task<IActionResult> GetCheckStatusTypes()
    {
        var data = await _rmsContextService.GetCheckStatusTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("rms/check-status-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "RMS Context - Check status types" })]
    public async Task<IActionResult> GetCheckStatusType(int id)
    {
        var data = await _rmsContextService.GetCheckStatusType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("rms/dtp-status-types")]
    [SwaggerOperation(Tags = new[] { "RMS Context - DTP status types" })]
    public async Task<IActionResult> GetDtpStatusTypes()
    {
        var data = await _rmsContextService.GetDtpStatusTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("rms/dtp-status-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "RMS Context - DTP status types" })]
    public async Task<IActionResult> GetDtpStatusType(int id)
    {
        var data = await _rmsContextService.GetDtpStatusType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("rms/dup-status-types")]
    [SwaggerOperation(Tags = new[] { "RMS Context - DUP status types" })]
    public async Task<IActionResult> GetDupStatusTypes()
    {
        var data = await _rmsContextService.GetDupStatusTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("rms/dup-status-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "RMS Context - DUP status types" })]
    public async Task<IActionResult> GetDupStatusType(int id)
    {
        var data = await _rmsContextService.GetDupStatusType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("rms/legal-status-types")]
    [SwaggerOperation(Tags = new[] { "RMS Context - Legal status types" })]
    public async Task<IActionResult> GetLegalStatusTypes()
    {
        var data = await _rmsContextService.GetLegalStatusTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("rms/legal-status-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "RMS Context - Legal status types" })]
    public async Task<IActionResult> GetLegalStatusType(int id)
    {
        var data = await _rmsContextService.GetLegalStatusType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    
    [HttpGet("rms/repo-access-types")]
    [SwaggerOperation(Tags = new[] { "RMS Context - Repo access types" })]
    public async Task<IActionResult> GetRepoStatusTypes()
    {
        var data = await _rmsContextService.GetRepoAccessTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("rms/repo-access-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "RMS Context - Repo access types" })]
    public async Task<IActionResult> GetRepoStatusType(int id)
    {
        var data = await _rmsContextService.GetRepoAccessType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
}