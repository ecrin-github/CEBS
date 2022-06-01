using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.RMS.DTO.v1;
using CEBS.Interfaces.RMS.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.RMS.v1.Dup;

public class DupPrereqsApiController : BaseRmsApiController
{
    private readonly IDupService _dupService;

    public DupPrereqsApiController(IDupService dupService)
    {
        _dupService = dupService ?? throw new ArgumentNullException(nameof(dupService));
    }


    [HttpGet("data-uses/{dupId:int}/prereqs")]
    [SwaggerOperation(Tags = new[] { "Data use process prereqs endpoint" })]
    public async Task<IActionResult> GetDupPrereqList(int dupId)
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

        var dupPrereqs = await _dupService.GetDupPrereqs(dupId);
        if (dupPrereqs.Total == 0 && dupPrereqs.Data.Length == 0)
            return Ok(new ApiResponse<DupPrereqDto>()
            {
                Total = dupPrereqs.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUP prereqs have been found." },
                Data = dupPrereqs.Data
            });

        return Ok(new ApiResponse<DupPrereqDto>()
        {
            Total = dupPrereqs.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dupPrereqs.Data
        });
    }

    [HttpGet("data-uses/{dupId:int}/prereqs/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Data use process prereqs endpoint" })]
    public async Task<IActionResult> GetDupPrereq(int dupId, int id)
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

        var dupPrereq = await _dupService.GetDupPrereq(id);
        if (dupPrereq.Total == 0 && dupPrereq.Data.Length == 0)
            return Ok(new ApiResponse<DupPrereqDto>()
            {
                Total = dupPrereq.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUP prereq has been found." },
                Data = dupPrereq.Data
            });

        return Ok(new ApiResponse<DupPrereqDto>()
        {
            Total = dupPrereq.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dupPrereq.Data
        });
    }

    [HttpPost("data-uses/{dupId:int}/prereqs")]
    [SwaggerOperation(Tags = new[] { "Data use process prereqs endpoint" })]
    public async Task<IActionResult> CreateDupPrereq(int dupId, [FromBody] DupPrereqDto dupPrereqDto)
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

        var dupPrereq = await _dupService.CreateDupPrereq(dupId, dupPrereqDto);
        if (dupPrereq.Total == 0 && dupPrereq.Data.Length == 0)
            return Ok(new ApiResponse<DupPrereqDto>()
            {
                Total = dupPrereq.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during DUP prereq creation." },
                Data = dupPrereq.Data
            });

        return Ok(new ApiResponse<DupPrereqDto>()
        {
            Total = dupPrereq.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dupPrereq.Data
        });
    }

    [HttpPut("data-uses/{dupId:int}/prereqs/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Data use process prereqs endpoint" })]
    public async Task<IActionResult> UpdateDupPrereq(int dupId, int id, [FromBody] DupPrereqDto dupPrereqDto)
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

        var dupPrereq = await _dupService.GetDupPrereq(id);
        if (dupPrereq.Total == 0 && dupPrereq.Data.Length == 0)
            return Ok(new ApiResponse<DupPrereqDto>()
            {
                Total = dupPrereq.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUP prereq has been found." },
                Data = dupPrereq.Data
            });

        var updatedDupPrereq = await _dupService.UpdateDupPrereq(dupPrereqDto);
        if (updatedDupPrereq.Total == 0 && updatedDupPrereq.Data.Length == 0)
            return Ok(new ApiResponse<DupPrereqDto>()
            {
                Total = updatedDupPrereq.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during DUP prereq update." },
                Data = updatedDupPrereq.Data
            });

        return Ok(new ApiResponse<DupPrereqDto>()
        {
            Total = updatedDupPrereq.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedDupPrereq.Data
        });
    }

    [HttpDelete("data-uses/{dupId:int}/prereqs/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Data use process prereqs endpoint" })]
    public async Task<IActionResult> DeleteDupPrereq(int dupId, int id)
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

        var dupPrereq = await _dupService.GetDupPrereq(id);
        if (dupPrereq.Total == 0 && dupPrereq.Data.Length == 0)
            return Ok(new ApiResponse<DupPrereqDto>()
            {
                Total = dupPrereq.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUP prereq has been found." },
                Data = dupPrereq.Data
            });

        var count = await _dupService.DeleteDupPrereq(id);
        return Ok(new ApiResponse<DupPrereqDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "DUP prereq has been removed." },
            Data = Array.Empty<DupPrereqDto>()
        });
    }

    [HttpDelete("data-uses/{dupId:int}/prereqs")]
    [SwaggerOperation(Tags = new[] { "Data use process prereqs endpoint" })]
    public async Task<IActionResult> DeleteAllDupPrereqs(int dupId)
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

        var count = await _dupService.DeleteAllDupPrereqs(dupId);
        return Ok(new ApiResponse<DupPrereqDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All DUP prereqs have been removed." },
            Data = Array.Empty<DupPrereqDto>()
        });
    }
}