using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.RMS.DTO.v1;
using CEBS.Interfaces.RMS.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.RMS.v1.Dtp;

public class DtaApiController : BaseRmsApiController
{
    
    private readonly IDtpService _dtpService;

    public DtaApiController(IDtpService dtpService)
    {
        _dtpService = dtpService ?? throw new ArgumentNullException(nameof(dtpService));
    }
    
    
    [HttpGet("data-transfers/{dtpId:int}/accesses")]
    [SwaggerOperation(Tags = new []{"Data transfer access endpoint"})]
    public async Task<IActionResult> GetDtaList(int dtpId)
    {
        var dt = await _dtpService.GetDtp(dtpId);
        if (dt.Total == 0 && dt.Data.Length == 0) return Ok(new ApiResponse<DtpDto>()
        {
            Total = dt.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] {"No related DTPs have been found."},
            Data = dt.Data
        });

        var data = await _dtpService.GetAllDta(dtpId);
        return Ok(new ApiResponse<DtaDto>()
        {
            Total = data.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = data.Data
        });
    }

    [HttpGet("data-transfers/{dtpId:int}/accesses/{id:int}")]
    [SwaggerOperation(Tags = new []{"Data transfer access endpoint"})]
    public async Task<IActionResult> GetDta(int dtpId, int id)
    {
        var dt = await _dtpService.GetDtp(dtpId);
        if (dt.Total == 0 && dt.Data.Length == 0) return Ok(new ApiResponse<DtpDto>()
        {
            Total = dt.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] {"No related DTPs have been found."},
            Data = dt.Data
        });

        var dta = await _dtpService.GetDta(id);
        if (dta.Total == 0 && dta.Data.Length == 0) return Ok(new ApiResponse<DtaDto>()
        {
            Total = dta.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] {"No related DTAs have been found."},
            Data = dta.Data
        });
        
        return Ok(new ApiResponse<DtaDto>()
        {
            Total = dta.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dta.Data
        });
    }

    [HttpPost("data-transfers/{dtpId:int}/accesses")]
    [SwaggerOperation(Tags = new []{"Data transfer access endpoint"})]
    public async Task<IActionResult> CreateDta(int dtpId, [FromBody] DtaDto dtaDto)
    {
        var dt = await _dtpService.GetDtp(dtpId);
        if (dt.Total == 0 && dt.Data.Length == 0) return Ok(new ApiResponse<DtpDto>()
        {
            Total = dt.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] {"No related DTPs have been found."},
            Data = dt.Data
        });

        var dta = await _dtpService.CreateDta(dtpId, dtaDto);
        if (dta.Total == 0 && dta.Data.Length == 0)
            return Ok(new ApiResponse<DtaDto>()
            {
                Total =dta.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new []  { "Error during DTA creation." },
                Data = dta.Data
            });
        
        return Ok(new ApiResponse<DtaDto>()
        {
            Total = dta.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dta.Data
        });
    }

    [HttpPut("data-transfers/{dtpId:int}/accesses/{id:int}")]
    [SwaggerOperation(Tags = new []{"Data transfer access endpoint"})]
    public async Task<IActionResult> UpdateDta(int dtpId, int id, [FromBody] DtaDto dtaDto)
    {
        var dt = await _dtpService.GetDtp(dtpId);
        if (dt.Total == 0 && dt.Data.Length == 0) return Ok(
            new ApiResponse<DtpDto>()
            {
                Total = dt.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] {"No related DTPs have been found."},
                Data = dt.Data
            });

        var dta = await _dtpService.GetDta(id);
        if (dta.Total == 0 && dta.Data.Length == 0) return Ok(new ApiResponse<DtaDto>()
        {
            Total = dta.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] {"No related DTAs have been found."},
            Data = dta.Data
        });

        var updatedDta = await _dtpService.UpdateDta(dtaDto);
        if (updatedDta.Total == 0 && updatedDta.Data.Length == 0) return Ok(new ApiResponse<DtaDto>()
        {
            Total = updatedDta.Total,
            StatusCode = BadRequest().StatusCode,
            Messages = new [] {"Error during DTA update."},
            Data = updatedDta.Data
        });
        
        return Ok(new ApiResponse<DtaDto>()
        {
            Total = dta.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dta.Data
        });
    }

    [HttpDelete("data-transfers/{dtpId:int}/accesses/{id:int}")]
    [SwaggerOperation(Tags = new []{"Data transfer access endpoint"})]
    public async Task<IActionResult> DeleteDta(int dtpId, int id)
    {
        var dt = await _dtpService.GetDtp(dtpId);
        if (dt.Total == 0 && dt.Data.Length == 0) return Ok(new ApiResponse<DtpDto>()
        {
            Total = dt.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] {"No related DTA have been found."},
            Data = dt.Data
        });

        var dta = await _dtpService.GetDta(id);
        if (dta.Total == 0 && dta.Data.Length == 0) return Ok(new ApiResponse<DtaDto>()
        {
            Total = dta.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] {"No related DTA have been found."},
            Data = dta.Data
        });
        
        var count = await _dtpService.DeleteDta(id);
        return Ok(new ApiResponse<DtaDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] {"DTA has been removed."},
            Data = Array.Empty<DtaDto>()
        });
    }

    [HttpDelete("data-transfers/{dtpId:int}/accesses")]
    [SwaggerOperation(Tags = new []{"Data transfer access endpoint"})]
    public async Task<IActionResult> DeleteAllDta(int dtpId)
    {
        var dt = await _dtpService.GetDtp(dtpId);
        if (dt.Total == 0 && dt.Data.Length == 0) return Ok(new ApiResponse<DtpDto>()
        {
            Total = dt.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] {"No related DTA have been found."},
            Data = dt.Data
        });

        var count = await _dtpService.DeleteAllDta(dtpId);
        return Ok(new ApiResponse<DtaDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] {"All DTAs have been removed."},
            Data = Array.Empty<DtaDto>()
        });
    }
    
}