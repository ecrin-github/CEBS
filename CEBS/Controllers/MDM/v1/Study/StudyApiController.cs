using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Services.Study;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Study;

public class StudyApiController : BaseMdmApiController
{
    private readonly IStudyService _studyService;

    public StudyApiController(IStudyService studyService)
    {
        _studyService = studyService ?? throw new ArgumentNullException(nameof(studyService));
    }
    
    [HttpGet("studies")]
    [SwaggerOperation(Tags = new []{"Study endpoint"})]
    public async Task<IActionResult> GetAllStudies()
    {
        var studies = await _studyService.GetStudies();
        if (studies.Total == 0 && studies.Data.Length == 0)
            return Ok(new ApiResponse<StudyDto>()
            {
                Total = studies.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No studies have been found." },
                Data = studies.Data
            });
        return Ok(new ApiResponse<StudyDto>()
        {
            Total = studies.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studies.Data
        });
    }

    [HttpGet("studies/{sdSid}")]
    [SwaggerOperation(Tags = new []{"Study endpoint"})]
    public async Task<IActionResult> GetStudyBySdSid(string sdSid)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = study.Data
        });
    }
    
    [HttpGet("studies/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study endpoint"})]
    public async Task<IActionResult> GetStudyById(int id)
    {
        var study = await _studyService.GetStudyById(id);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = study.Data
        });
    }

    [HttpPost("studies")]
    [SwaggerOperation(Tags = new []{"Study endpoint"})]
    public async Task<IActionResult> CreateStudy([FromBody] StudyDto studyDto)
    {
        var study = await _studyService.CreateStudy(studyDto);
        if (study.Total == 0 && study.Data.Length == 0)
            return Ok(new ApiResponse<StudyDto>()
            {
                Total = study.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during study creation." },
                Data = study.Data
            });

        return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = study.Data
        });
    }
    
    [HttpPut("studies/{sdSid}")]
    [SwaggerOperation(Tags = new []{"Study endpoint"})]
    public async Task<IActionResult> UpdateStudy(string sdSid, [FromBody] StudyDto studyDto)
    {
        studyDto.SdSid ??= sdSid;
        
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0)
            return Ok(new ApiResponse<StudyDto>()
            {
                Total = study.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No studies have been found." },
                Data = study.Data
            });

        var updatedStudy = await _studyService.UpdateStudy(studyDto);
        if (updatedStudy.Total == 0 && updatedStudy.Data.Length == 0)
            return Ok(new ApiResponse<StudyDto>()
            {
                Total = updatedStudy.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during study update." },
                Data = updatedStudy.Data
            });

        return Ok(new ApiResponse<StudyDto>()
        {
            Total = updatedStudy.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedStudy.Data
        });
    }

    [HttpDelete("studies/{sdSid}")]
    [SwaggerOperation(Tags = new []{"Study endpoint"})]
    public async Task<IActionResult> DeleteStudy(string sdSid)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });
        var count = await _studyService.DeleteStudy(sdSid);
        return Ok(new ApiResponse<StudyDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Study has been removed." },
            Data = Array.Empty<StudyDto>()
        });
    }
}