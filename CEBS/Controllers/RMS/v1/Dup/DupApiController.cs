using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.RMS.DTO.v1;
using CEBS.Interfaces.RMS.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.RMS.v1.Dup;

public class DupApiController : BaseRmsApiController
{
    private readonly IDupService _dupService;

    public DupApiController(IDupService dupService)
    {
        _dupService = dupService ?? throw new ArgumentNullException(nameof(dupService));
    }


    [HttpGet("data-uses/processes")]
    [SwaggerOperation(Tags = new[] { "Data use process endpoint" })]
    public async Task<IActionResult> GetDupList()
    {
        var dupList = await _dupService.GetAllDup();
        if (dupList.Total == 0 && dupList.Data.Length == 0)
            return Ok(new ApiResponse<DupDto>()
            {
                Total = dupList.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUPs have been found." },
                Data = dupList.Data
            });
        return Ok(new ApiResponse<DupDto>()
        {
            Total = dupList.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dupList.Data
        });
    }

    [HttpGet("data-uses/processes/{dupId:int}")]
    [SwaggerOperation(Tags = new[] { "Data use process endpoint" })]
    public async Task<IActionResult> GetDup(int dupId)
    {
        var dup = await _dupService.GetDup(dupId);
        if (dup.Total == 0 && dup.Data.Length == 0)
            return Ok(new ApiResponse<DupDto>()
            {
                Total = dup.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUP has been found." },
                Data = dup.Data
            });
        return Ok(new ApiResponse<DupDto>()
        {
            Total = dup.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dup.Data
        });
    }

    [HttpPost("data-uses/processes")]
    [SwaggerOperation(Tags = new[] { "Data use process endpoint" })]
    public async Task<IActionResult> CreateDup([FromBody] DupDto dupDto)
    {
        var dup = await _dupService.CreateDup(dupDto);
        if (dup.Total == 0 && dup.Data.Length == 0)
            return Ok(new ApiResponse<DupDto>()
            {
                Total = dup.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during DUP creation." },
                Data = dup.Data
            });
        return Ok(new ApiResponse<DupDto>()
        {
            Total = dup.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dup.Data
        });
    }

    [HttpPut("data-uses/processes/{dupId:int}")]
    [SwaggerOperation(Tags = new[] { "Data use process endpoint" })]
    public async Task<IActionResult> UpdateDup(int dupId, [FromBody] DupDto dupDto)
    {
        var dup = await _dupService.GetDup(dupId);
        if (dup.Total == 0 && dup.Data.Length == 0)
            return Ok(new ApiResponse<DupDto>()
            {
                Total = dup.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUP has been found." },
                Data = dup.Data
            });
        var updatedDup = await _dupService.UpdateDup(dupDto);
        if (updatedDup.Total == 0 && updatedDup.Data.Length == 0)
            return Ok(new ApiResponse<DupDto>()
            {
                Total = updatedDup.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during DUP update." },
                Data = updatedDup.Data
            });
        return Ok(new ApiResponse<DupDto>()
        {
            Total = updatedDup.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedDup.Data
        });
    }

    [HttpDelete("data-uses/processes/{dupId:int}")]
    [SwaggerOperation(Tags = new[] { "Data use process endpoint" })]
    public async Task<IActionResult> DeleteDup(int dupId)
    {
        var dup = await _dupService.GetDup(dupId);
        if (dup.Total == 0 && dup.Data.Length == 0)
            return Ok(new ApiResponse<DupDto>()
            {
                Total = dup.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUP has been found." },
                Data = dup.Data
            });

        var count = await _dupService.DeleteDup(dupId);
        return Ok(new ApiResponse<DupDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "DUP has been removed." },
            Data = Array.Empty<DupDto>()
        });
    }
}