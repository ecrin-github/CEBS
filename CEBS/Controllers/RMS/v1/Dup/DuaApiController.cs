using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.RMS.DTO.v1;
using CEBS.Interfaces.RMS.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.RMS.v1.Dup;

public class DuaApiController : BaseRmsApiController
{
    private readonly IDupService _dupService;

    public DuaApiController(IDupService dupService)
    {
        _dupService = dupService ?? throw new ArgumentNullException(nameof(dupService));
    }


    [HttpGet("data-uses/{dupId:int}/accesses")]
    [SwaggerOperation(Tags = new[] { "Data use access endpoint" })]
    public async Task<IActionResult> GetDuaList(int dupId)
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

        var duaList = await _dupService.GetAllDua(dupId);
        if (duaList.Total == 0 && duaList.Data.Length == 0)
            return Ok(new ApiResponse<DuaDto>()
            {
                Total = duaList.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUA have been found." },
                Data = duaList.Data
            });

        return Ok(new ApiResponse<DuaDto>()
        {
            Total = duaList.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = duaList.Data
        });
    }

    [HttpGet("data-uses/{dupId:int}/accesses/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Data use access endpoint" })]
    public async Task<IActionResult> GetDua(int dupId, int id)
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

        var dua = await _dupService.GetDua(id);
        if (dua.Total == 0 && dua.Data.Length == 0)
            return Ok(new ApiResponse<DuaDto>()
            {
                Total = dua.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUA has been found." },
                Data = dua.Data
            });
        return Ok(new ApiResponse<DuaDto>()
        {
            Total = dua.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dua.Data
        });
    }

    [HttpPost("data-uses/{dupId:int}/accesses")]
    [SwaggerOperation(Tags = new[] { "Data use access endpoint" })]
    public async Task<IActionResult> CreateDua(int dupId, [FromBody] DuaDto duaDto)
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

        var dua = await _dupService.CreateDua(dupId, duaDto);
        if (dua.Total == 0 && dua.Data.Length == 0)
            return Ok(new ApiResponse<DuaDto>()
            {
                Total = dua.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during DUA creation." },
                Data = dua.Data
            });

        return Ok(new ApiResponse<DuaDto>()
        {
            Total = dua.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dua.Data
        });
    }

    [HttpPut("data-uses/{dupId:int}/accesses/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Data use access endpoint" })]
    public async Task<IActionResult> UpdateDua(int dupId, int id, [FromBody] DuaDto duaDto)
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

        var dua = await _dupService.GetDua(id);
        if (dua.Total == 0 && dua.Data.Length == 0)
            return Ok(new ApiResponse<DuaDto>()
            {
                Total = dua.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUA has been found." },
                Data = dua.Data
            });

        var updatedDua = await _dupService.UpdateDua(duaDto);
        if (updatedDua.Total == 0 && updatedDua.Data.Length == 0)
            return Ok(new ApiResponse<DuaDto>()
            {
                Total = updatedDua.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during DUA update." },
                Data = updatedDua.Data
            });

        return Ok(new ApiResponse<DuaDto>()
        {
            Total = updatedDua.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedDua.Data
        });
    }

    [HttpDelete("data-uses/{dupId:int}/accesses/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Data use access endpoint" })]
    public async Task<IActionResult> DeleteDua(int dupId, int id)
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

        var dua = await _dupService.GetDua(id);
        if (dua.Total == 0 && dua.Data.Length == 0)
            return Ok(new ApiResponse<DuaDto>()
            {
                Total = dua.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUA has been found." },
                Data = dua.Data
            });

        var count = await _dupService.DeleteDua(id);
        return Ok(new ApiResponse<DuaDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "DUA has been removed." },
            Data = Array.Empty<DuaDto>()
        });
    }

    [HttpDelete("data-uses/{dupId:int}/accesses")]
    [SwaggerOperation(Tags = new[] { "Data use access endpoint" })]
    public async Task<IActionResult> DeleteAllDua(int dupId)
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

        var count = await _dupService.DeleteAllDua(dupId);
        return Ok(new ApiResponse<DuaDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All DUAs have been removed." },
            Data = Array.Empty<DuaDto>()
        });
    }
}