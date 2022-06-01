using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.RMS.DTO.v1;
using CEBS.Interfaces.RMS.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.RMS.v1.Dup;

public class DupObjectsApiController : BaseRmsApiController
{
    private readonly IDupService _dupService;

    public DupObjectsApiController(IDupService dupService)
    {
        _dupService = dupService ?? throw new ArgumentNullException(nameof(dupService));
    }


    [HttpGet("data-uses/{dupId:int}/objects")]
    [SwaggerOperation(Tags = new[] { "Data use process objects endpoint" })]
    public async Task<IActionResult> GetDupObjectList(int dupId)
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

        var dupObjects = await _dupService.GetDupObjects(dupId);
        if (dupObjects.Total == 0 && dupObjects.Data.Length == 0)
            return Ok(new ApiResponse<DupObjectDto>()
            {
                Total = dupObjects.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUP objects have been found." },
                Data = dupObjects.Data
            });

        return Ok(new ApiResponse<DupObjectDto>()
        {
            Total = dupObjects.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dupObjects.Data
        });
    }

    [HttpGet("data-uses/{dupId:int}/objects/{id}")]
    [SwaggerOperation(Tags = new[] { "Data use process objects endpoint" })]
    public async Task<IActionResult> GetDupObject(int dupId, int id)
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

        var dupObj = await _dupService.GetDupObject(id);
        if (dupObj.Total == 0 && dupObj.Data.Length == 0)
            return Ok(new ApiResponse<DupObjectDto>()
            {
                Total = dupObj.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUP objects has been found." },
                Data = dupObj.Data
            });

        return Ok(new ApiResponse<DupObjectDto>()
        {
            Total = dupObj.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dupObj.Data
        });
    }

    [HttpPost("data-uses/{dupId:int}/objects")]
    [SwaggerOperation(Tags = new[] { "Data use process objects endpoint" })]
    public async Task<IActionResult> CreateDupObject(int dupId, [FromBody] DupObjectDto dupObjectDto)
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

        var dupObj = await _dupService.CreateDupObject(dupId, dupObjectDto);
        if (dupObj.Total == 0 && dupObj.Data.Length == 0)
            return Ok(new ApiResponse<DupObjectDto>()
            {
                Total = dupObj.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during DUP object creation." },
                Data = dupObj.Data
            });

        return Ok(new ApiResponse<DupObjectDto>()
        {
            Total = dupObj.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dupObj.Data
        });
    }

    [HttpPut("data-uses/{dupId:int}/objects/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Data use process objects endpoint" })]
    public async Task<IActionResult> UpdateDupObject(int dupId, int id, [FromBody] DupObjectDto dupObjectDto)
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

        var dupObj = await _dupService.GetDupObject(id);
        if (dupObj.Total == 0 && dupObj.Data.Length == 0)
            return Ok(new ApiResponse<DupObjectDto>()
            {
                Total = dupObj.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUP object has been found." },
                Data = dupObj.Data
            });

        var updatedDupObject = await _dupService.UpdateDupObject(dupObjectDto);
        if (updatedDupObject.Total == 0 && updatedDupObject.Data.Length == 0)
            return Ok(new ApiResponse<DupObjectDto>()
            {
                Total = updatedDupObject.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during DUP object update." },
                Data = updatedDupObject.Data
            });

        return Ok(new ApiResponse<DupObjectDto>()
        {
            Total = updatedDupObject.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedDupObject.Data
        });
    }

    [HttpDelete("data-uses/{dupId:int}/objects/{id}")]
    [SwaggerOperation(Tags = new[] { "Data use process objects endpoint" })]
    public async Task<IActionResult> DeleteDupObject(int dupId, int id)
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

        var dupObj = await _dupService.GetDupObject(id);
        if (dupObj.Total == 0 && dupObj.Data.Length == 0)
            return Ok(new ApiResponse<DupObjectDto>()
            {
                Total = dupObj.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DUP object has been found." },
                Data = dupObj.Data
            });

        var count = await _dupService.DeleteDupObject(id);
        return Ok(new ApiResponse<DupObjectDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "DUP object has been removed." },
            Data = Array.Empty<DupObjectDto>()
        });
    }

    [HttpDelete("data-uses/{dupId:int}/objects")]
    [SwaggerOperation(Tags = new[] { "Data use process objects endpoint" })]
    public async Task<IActionResult> DeleteAllDupObjects(int dupId)
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

        var count = await _dupService.DeleteAllDupObjects(dupId);
        return Ok(new ApiResponse<DupObjectDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All DUP objects have been removed." },
            Data = Array.Empty<DupObjectDto>()
        });
    }
}