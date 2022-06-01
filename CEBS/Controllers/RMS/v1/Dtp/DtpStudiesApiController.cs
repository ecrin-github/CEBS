using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.RMS.DTO.v1;
using CEBS.Interfaces.RMS.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.RMS.v1.Dtp;

public class DtpStudiesApiController : BaseRmsApiController
{
    private readonly IDtpService _dtpService;

    public DtpStudiesApiController(IDtpService dtpService)
    {
        _dtpService = dtpService ?? throw new ArgumentNullException(nameof(dtpService));
    }


    [HttpGet("data-transfers/{dtpId:int}/studies")]
    [SwaggerOperation(Tags = new[] { "Data transfer process studies endpoint" })]
    public async Task<IActionResult> GetDtpStudyList(int dtpId)
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
        var dtpStudies = await _dtpService.GetAllDtpStudies(dtpId);
        if (dtpStudies.Total == 0 && dtpStudies.Data.Length == 0)
            return Ok(new ApiResponse<DtpStudyDto>()
            {
                Total = dtpStudies.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP studies have been found." },
                Data = dtpStudies.Data
            });
        return Ok(new ApiResponse<DtpStudyDto>()
        {
            Total = dtpStudies.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dtpStudies.Data
        });
    }

    [HttpGet("data-transfers/{dtpId:int}/studies/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Data transfer process studies endpoint" })]
    public async Task<IActionResult> GetDtpStudy(int dtpId, int id)
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

        var dtpStudy = await _dtpService.GetDtpStudy(id);
        if (dtpStudy.Total == 0 && dtpStudy.Data.Length == 0)
            return Ok(new ApiResponse<DtpStudyDto>()
            {
                Total = dtpStudy.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP study has been found." },
                Data = dtpStudy.Data
            });
        return Ok(new ApiResponse<DtpStudyDto>()
        {
            Total = dtpStudy.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dtpStudy.Data
        });
    }

    [HttpPost("data-transfers/{dtpId:int}/studies")]
    [SwaggerOperation(Tags = new[] { "Data transfer process studies endpoint" })]
    public async Task<IActionResult> CreateDtpStudy(int dtpId, [FromBody] DtpStudyDto dtpStudyDto)
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

        var dtpStudy = await _dtpService.CreateDtpStudy(dtpId, dtpStudyDto.StudyId, dtpStudyDto);
        if (dtpStudy.Total == 0 && dtpStudy.Data.Length == 0)
            return Ok(new ApiResponse<DtpStudyDto>()
            {
                Total = dtpStudy.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during DTP study creation." },
                Data = dtpStudy.Data
            });
        return Ok(new ApiResponse<DtpStudyDto>()
        {
            Total = dtpStudy.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dtpStudy.Data
        });
    }

    [HttpPut("data-transfers/{dtpId:int}/studies/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Data transfer process studies endpoint" })]
    public async Task<IActionResult> UpdateDtpStudy(int dtpId, int id, [FromBody] DtpStudyDto dtpStudyDto)
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

        var dtpStudy = await _dtpService.GetDtpStudy(id);
        if (dtpStudy.Total == 0 && dtpStudy.Data.Length == 0)
            return Ok(new ApiResponse<DtpStudyDto>()
            {
                Total = dtpStudy.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP study has been found." },
                Data = dtpStudy.Data
            });

        var updatedDtpStudy = await _dtpService.UpdateDtpStudy(dtpStudyDto);
        if (updatedDtpStudy.Total == 0 && updatedDtpStudy.Data.Length == 0)
            return Ok(new ApiResponse<DtpStudyDto>()
            {
                Total = updatedDtpStudy.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during DTP study update." },
                Data = updatedDtpStudy.Data
            });
        return Ok(new ApiResponse<DtpStudyDto>()
        {
            Total = updatedDtpStudy.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedDtpStudy.Data
        });
    }

    [HttpDelete("data-transfers/{dtpId:int}/studies/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Data transfer process studies endpoint" })]
    public async Task<IActionResult> DeleteDtpStudy(int dtpId, int id)
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

        var dtpStudy = await _dtpService.GetDtpStudy(id);
        if (dtpStudy.Total == 0 && dtpStudy.Data.Length == 0)
            return Ok(new ApiResponse<DtpStudyDto>()
            {
                Total = dtpStudy.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP study has been found." },
                Data = dtpStudy.Data
            });

        var count = await _dtpService.DeleteDtpStudy(id);
        return Ok(new ApiResponse<DtpStudyDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "DTP study has been removed." },
            Data = Array.Empty<DtpStudyDto>()
        });
    }

    [HttpDelete("data-transfers/{dtpId:int}/studies")]
    [SwaggerOperation(Tags = new[] { "Data transfer process studies endpoint" })]
    public async Task<IActionResult> DeleteAllDtpStudies(int dtpId)
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

        var count = await _dtpService.DeleteAllDtpStudies(dtpId);
        return Ok(new ApiResponse<DtpStudyDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All DTP studies have been found." },
            Data = Array.Empty<DtpStudyDto>()
        });
    }
}