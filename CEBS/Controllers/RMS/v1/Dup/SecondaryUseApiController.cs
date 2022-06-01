using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.RMS.DTO.v1;
using CEBS.Interfaces.RMS.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.RMS.v1.Dup;

public class SecondaryUseApiController : BaseRmsApiController
{
    private readonly IDupService _dupService;

    public SecondaryUseApiController(IDupService dupService)
    {
        _dupService = dupService ?? throw new ArgumentNullException(nameof(dupService));
    }


    [HttpGet("data-uses/{dupId:int}/secondary-use")]
    [SwaggerOperation(Tags = new[] { "Secondary use endpoint" })]
    public async Task<IActionResult> GetSecondaryUseList(int dupId)
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

        var secUses = await _dupService.GetSecondaryUses(dupId);
        if (secUses.Total == 0 && secUses.Data.Length == 0)
            return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = secUses.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No secondary uses have been found." },
                Data = secUses.Data
            });

        return Ok(new ApiResponse<SecondaryUseDto>()
        {
            Total = secUses.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = secUses.Data
        });
    }

    [HttpGet("data-uses/{dupId:int}/secondary-use/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Secondary use endpoint" })]
    public async Task<IActionResult> GetSecondaryUse(int dupId, int id)
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

        var secUse = await _dupService.GetSecondaryUse(id);
        if (secUse.Total == 0 && secUse.Data.Length == 0)
            return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = secUse.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No secondary use has been found." },
                Data = secUse.Data
            });

        return Ok(new ApiResponse<SecondaryUseDto>()
        {
            Total = secUse.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = secUse.Data
        });
    }

    [HttpPost("data-uses/{dupId:int}/secondary-use")]
    [SwaggerOperation(Tags = new[] { "Secondary use endpoint" })]
    public async Task<IActionResult> CreateSecondaryUse(int dupId, [FromBody] SecondaryUseDto secondaryUseDto)
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

        var secUse = await _dupService.CreateSecondaryUse(dupId, secondaryUseDto);
        if (secUse.Total == 0 && secUse.Data.Length == 0)
            return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = secUse.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during secondary use creation." },
                Data = secUse.Data
            });

        return Ok(new ApiResponse<SecondaryUseDto>()
        {
            Total = secUse.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = secUse.Data
        });
    }

    [HttpPut("data-uses/{dupId:int}/secondary-use/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Secondary use endpoint" })]
    public async Task<IActionResult> UpdateSecondaryUse(int dupId, int id, [FromBody] SecondaryUseDto secondaryUseDto)
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

        var secUse = await _dupService.GetSecondaryUse(id);
        if (secUse.Total == 0 && secUse.Data.Length == 0)
            return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = secUse.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No secondary use has been found." },
                Data = secUse.Data
            });

        var updateSecUse = await _dupService.UpdateSecondaryUse(secondaryUseDto);
        if (updateSecUse.Total == 0 && updateSecUse.Data.Length == 0)
            return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = updateSecUse.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during secondary use update." },
                Data = updateSecUse.Data
            });

        return Ok(new ApiResponse<SecondaryUseDto>()
        {
            Total = updateSecUse.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updateSecUse.Data
        });
    }

    [HttpDelete("data-uses/{dupId:int}/secondary-use/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Secondary use endpoint" })]
    public async Task<IActionResult> DeleteSecondaryUse(int dupId, int id)
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

        var secUse = await _dupService.GetSecondaryUse(id);
        if (secUse.Total == 0 && secUse.Data.Length == 0)
            return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = secUse.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No secondary use has been found." },
                Data = secUse.Data
            });

        var count = await _dupService.DeleteSecondaryUse(id);
        return Ok(new ApiResponse<SecondaryUseDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Secondary use has been removed." },
            Data = Array.Empty<SecondaryUseDto>()
        });
    }

    [HttpDelete("data-uses/{dupId:int}/secondary-use")]
    [SwaggerOperation(Tags = new[] { "Secondary use endpoint" })]
    public async Task<IActionResult> DeleteAllSecondaryUses(int dupId)
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

        var count = await _dupService.DeleteAllSecondaryUses(dupId);
        return Ok(new ApiResponse<SecondaryUseDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All secondary uses have been removed." },
            Data = Array.Empty<SecondaryUseDto>()
        });
    }
}