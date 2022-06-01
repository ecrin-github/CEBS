using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.RMS.DTO.v1;
using CEBS.Interfaces.RMS.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.RMS.v1.Dtp;

public class DtpApiController : BaseRmsApiController
{
    private readonly IDtpService _dtpService;

    public DtpApiController(IDtpService dtpService)
    {
        _dtpService = dtpService ?? throw new ArgumentNullException(nameof(dtpService));
    }


    [HttpGet("data-transfers/processes")]
    [SwaggerOperation(Tags = new[] { "Data transfer process endpoint" })]
    public async Task<IActionResult> GetDtpList()
    {
        var data = await _dtpService.GetAllDtp();
        if (data.Total == 0 && data.Data.Length == 0)
            return Ok(new ApiResponse<DtpDto>()
            {
                Total = data.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTPs have been found." },
                Data = data.Data
            });
        return Ok(new ApiResponse<DtpDto>()
        {
            Total = data.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = data.Data
        });
    }

    [HttpGet("data-transfers/processes/recent/{number:int}")]
    [SwaggerOperation(Tags = new[] { "Data transfer process endpoint" })]
    public async Task<IActionResult> GetRecentDtp(int number)
    {
        var recentData = await _dtpService.GetRecentDtp(number);
        if (recentData.Total == 0 && recentData.Data.Length == 0)
            return Ok(new ApiResponse<DtpDto>()
            {
                Total = recentData.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTPs have been found." },
                Data = recentData.Data
            });
        return Ok(new ApiResponse<DtpDto>()
        {
            Total = recentData.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = recentData.Data
        });
    }

    [HttpGet("data-transfers/processes/{dtpId:int}")]
    [SwaggerOperation(Tags = new[] { "Data transfer process endpoint" })]
    public async Task<IActionResult> GetDtp(int dtpId)
    {
        var dtp = await _dtpService.GetDtp(dtpId);
        if (dtp.Total == 0 && dtp.Data.Length == 0)
            return Ok(new ApiResponse<DtpDto>()
            {
                Total = dtp.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTPs have been found." },
                Data = dtp.Data
            });

        return Ok(new ApiResponse<DtpDto>()
        {
            Total = dtp.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dtp.Data
        });
    }

    [HttpPost("data-transfers/processes")]
    [SwaggerOperation(Tags = new[] { "Data transfer process endpoint" })]
    public async Task<IActionResult> CreateDtp([FromBody] DtpDto dtpDto)
    {
        var dtp = await _dtpService.CreateDtp(dtpDto);
        if (dtp.Total == 0 && dtp.Data.Length == 0)
            return Ok(new ApiResponse<DtpDto>()
            {
                Total = dtp.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during DTP creation." },
                Data = dtp.Data
            });
        return Ok(new ApiResponse<DtpDto>()
        {
            Total = dtp.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dtp.Data
        });
    }

    [HttpPut("data-transfers/processes/{dtpId:int}")]
    [SwaggerOperation(Tags = new[] { "Data transfer process endpoint" })]
    public async Task<IActionResult> UpdateDtp(int dtpId, [FromBody] DtpDto dtpDto)
    {
        var dtp = await _dtpService.GetDtp(dtpId);
        if (dtp.Total == 0 && dtp.Data.Length == 0)
            return Ok(new ApiResponse<DtpDto>()
            {
                Total = dtp.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTPs have been found." },
                Data = dtp.Data
            });

        var updatedDtp = await _dtpService.UpdateDtp(dtpDto);
        if (updatedDtp.Total == 0 && updatedDtp.Data.Length == 0)
            return Ok(new ApiResponse<DtpDto>()
            {
                Total = updatedDtp.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during DTP update." },
                Data = updatedDtp.Data
            });

        return Ok(new ApiResponse<DtpDto>()
        {
            Total = updatedDtp.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedDtp.Data
        });
    }

    [HttpDelete("data-transfers/processes/{dtpId:int}")]
    [SwaggerOperation(Tags = new[] { "Data transfer process endpoint" })]
    public async Task<IActionResult> DeleteDtp(int dtpId)
    {
        var dtp = await _dtpService.GetDtp(dtpId);
        if (dtp.Total == 0 && dtp.Data.Length == 0)
            return Ok(new ApiResponse<DtpDto>()
            {
                Total = dtp.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTPs have been found." },
                Data = dtp.Data
            });

        var count = await _dtpService.DeleteDtp(dtpId);
        return Ok(new ApiResponse<DtpDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "DTP has been removed." },
            Data = Array.Empty<DtpDto>()
        });
    }
}