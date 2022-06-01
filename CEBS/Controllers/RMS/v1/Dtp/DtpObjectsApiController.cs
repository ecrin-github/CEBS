using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.RMS.DTO.v1;
using CEBS.Interfaces.RMS.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.RMS.v1.Dtp;

public class DtpObjectsApiController : BaseRmsApiController
{
    private readonly IDtpService _dtpService;

    public DtpObjectsApiController(IDtpService dtpService)
    {
        _dtpService = dtpService ?? throw new ArgumentNullException(nameof(dtpService));
    }


    [HttpGet("data-transfers/{dtpId:int}/objects")]
    [SwaggerOperation(Tags = new[] { "Data transfer process objects endpoint" })]
    public async Task<IActionResult> GetDtpObjectList(int dtpId)
    {
        var dtp = await _dtpService.GetDtp(dtpId);
        if (dtp.Total == 0 && dtp.Data.Length == 0)
            return Ok(new ApiResponse<DtpDto>()
            {
                Total = dtp.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP has been found." },
                Data = dtp.Data
            });

        var dtpObjects = await _dtpService.GetAllDtpObjects(dtpId);
        if (dtpObjects.Total == 0 && dtpObjects.Data.Length == 0)
            return Ok(new ApiResponse<DtpObjectDto>()
            {
                Total = dtpObjects.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP objects have been found." },
                Data = dtpObjects.Data
            });

        return Ok(new ApiResponse<DtpObjectDto>()
        {
            Total = dtpObjects.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dtpObjects.Data
        });
    }

    [HttpGet("data-transfers/{dtpId:int}/objects/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Data transfer process objects endpoint" })]
    public async Task<IActionResult> GetDtpObject(int dtpId, int id)
    {
        var dtp = await _dtpService.GetDtp(dtpId);
        if (dtp.Total == 0 && dtp.Data.Length == 0)
            return Ok(new ApiResponse<DtpDto>()
            {
                Total = dtp.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP has been found." },
                Data = dtp.Data
            });

        var dtpObj = await _dtpService.GetDtpObject(id);
        if (dtpObj.Total == 0 && dtpObj.Data.Length == 0)
            return Ok(new ApiResponse<DtpObjectDto>()
            {
                Total = dtpObj.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP object has been found." },
                Data = dtpObj.Data
            });

        return Ok(new ApiResponse<DtpObjectDto>()
        {
            Total = dtpObj.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dtpObj.Data
        });
    }

    [HttpPost("data-transfers/{dtpId:int}/objects")]
    [SwaggerOperation(Tags = new[] { "Data transfer process objects endpoint" })]
    public async Task<IActionResult> CreateDtpObject(int dtpId, [FromBody] DtpObjectDto dtpObjectDto)
    {
        var dtp = await _dtpService.GetDtp(dtpId);
        if (dtp.Total == 0 && dtp.Data.Length == 0)
            return Ok(new ApiResponse<DtpDto>()
            {
                Total = dtp.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP has been found." },
                Data = dtp.Data
            });

        var dtpObj = await _dtpService.CreateDtpObject(dtpId, dtpObjectDto.ObjectId, dtpObjectDto);
        if (dtpObj.Total == 0 && dtpObj.Data.Length == 0)
            return Ok(new ApiResponse<DtpObjectDto>()
            {
                Total = dtpObj.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during DTP object creation." },
                Data = dtpObj.Data
            });

        return Ok(new ApiResponse<DtpObjectDto>()
        {
            Total = dtpObj.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dtpObj.Data
        });
    }

    [HttpPut("data-transfers/{dtpId:int}/objects/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Data transfer process objects endpoint" })]
    public async Task<IActionResult> UpdateDtpObject(int dtpId, int id, [FromBody] DtpObjectDto dtpObjectDto)
    {
        var dtp = await _dtpService.GetDtp(dtpId);
        if (dtp.Total == 0 && dtp.Data.Length == 0)
            return Ok(new ApiResponse<DtpDto>()
            {
                Total = dtp.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP has been found." },
                Data = dtp.Data
            });

        var dtpObj = await _dtpService.GetDtpObject(id);
        if (dtpObj.Total == 0 && dtpObj.Data.Length == 0)
            return Ok(new ApiResponse<DtpObjectDto>()
            {
                Total = dtpObj.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP object has been found." },
                Data = dtpObj.Data
            });

        var updatedDtpObj = await _dtpService.UpdateDtpObject(dtpObjectDto);
        if (updatedDtpObj.Total == 0 && updatedDtpObj.Data.Length == 0)
            return Ok(new ApiResponse<DtpObjectDto>()
            {
                Total = updatedDtpObj.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during DTP object update." },
                Data = updatedDtpObj.Data
            });

        return Ok(new ApiResponse<DtpObjectDto>()
        {
            Total = updatedDtpObj.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedDtpObj.Data
        });
    }

    [HttpDelete("data-transfers/{dtpId:int}/objects/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Data transfer process objects endpoint" })]
    public async Task<IActionResult> DeleteDtpObject(int dtpId, int id)
    {
        var dtp = await _dtpService.GetDtp(dtpId);
        if (dtp.Total == 0 && dtp.Data.Length == 0)
            return Ok(new ApiResponse<DtpDto>()
            {
                Total = dtp.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP has been found." },
                Data = dtp.Data
            });

        var dtpObj = await _dtpService.GetDtpObject(id);
        if (dtpObj.Total == 0 && dtpObj.Data.Length == 0)
            return Ok(new ApiResponse<DtpObjectDto>()
            {
                Total = dtpObj.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP object has been found." },
                Data = dtpObj.Data
            });

        var count = await _dtpService.DeleteDtpObject(id);
        return Ok(new ApiResponse<DtpObjectDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "DTP object has been removed." },
            Data = Array.Empty<DtpObjectDto>()
        });
    }

    [HttpDelete("data-transfers/{dtpId:int}/objects")]
    [SwaggerOperation(Tags = new[] { "Data transfer process objects endpoint" })]
    public async Task<IActionResult> DeleteAllDtpObjects(int dtpId)
    {
        var dtp = await _dtpService.GetDtp(dtpId);
        if (dtp.Total == 0 && dtp.Data.Length == 0)
            return Ok(new ApiResponse<DtpDto>()
            {
                Total = dtp.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP has been found." },
                Data = dtp.Data
            });

        var count = await _dtpService.DeleteAllDtpObjects(dtpId);
        return Ok(new ApiResponse<DtpObjectDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All DTP objects have been removed." },
            Data = Array.Empty<DtpObjectDto>()
        });
    }
}