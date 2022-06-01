using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Services.Study;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Study;

public class StudyTitlesApiController : BaseMdmApiController
{
    private readonly IStudyService _studyService;
    private readonly IStudyTitleService _studyTitleService;

    public StudyTitlesApiController(IStudyService studyService, IStudyTitleService studyTitleService)
    {
        _studyService = studyService ?? throw new ArgumentNullException(nameof(studyService));
        _studyTitleService = studyTitleService ?? throw new ArgumentNullException(nameof(studyTitleService));
    }
    
    [HttpGet("studies/{sdSid}/titles")]
    [SwaggerOperation(Tags = new []{"Study titles endpoint"})]
    public async Task<IActionResult> GetStudyTitles(string sdSid)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyTitles = await _studyTitleService.GetStudyTitles(sdSid);
        if (studyTitles.Total == 0 && studyTitles.Data.Length == 0)
            return Ok(new ApiResponse<StudyTitleDto>()
            {
                Total = studyTitles.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No study titles have been found." },
                Data = studyTitles.Data
            });
        
        return Ok(new ApiResponse<StudyTitleDto>()
        {
            Total = studyTitles.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyTitles.Data
        });
    }
    
    [HttpGet("studies/{sdSid}/titles/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study titles endpoint"})]
    public async Task<IActionResult> GetStudyTitle(string sdSid, int id)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyTitle = await _studyTitleService.GetStudyTitle(id);
        if (studyTitle.Total == 0 && studyTitle.Data.Length == 0) return Ok(new ApiResponse<StudyTitleDto>()
        {
            Total = studyTitle.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study titles have been found." },
            Data = studyTitle.Data
        });

        return Ok(new ApiResponse<StudyTitleDto>()
        {
            Total = studyTitle.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyTitle.Data
        });
    }

    [HttpPost("studies/{sdSid}/titles")]
    [SwaggerOperation(Tags = new []{"Study titles endpoint"})]
    public async Task<IActionResult> CreateStudyTitle(string sdSid, [FromBody] StudyTitleDto studyTitleDto)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        studyTitleDto.SdSid ??= sdSid;

        var studyTitle = await _studyTitleService.CreateStudyTitle(studyTitleDto);
        if (studyTitle.Total == 0 && studyTitle.Data.Length == 0) return Ok(new ApiResponse<StudyTitleDto>()
        {
            Total = studyTitle.Total,
            StatusCode = BadRequest().StatusCode,
            Messages = new [] { "Error during study title creation." },
            Data = studyTitle.Data
        });

        return Ok(new ApiResponse<StudyTitleDto>()
        {
            Total = studyTitle.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyTitle.Data
        });
    }

    [HttpPut("studies/{sdSid}/titles/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study titles endpoint"})]
    public async Task<IActionResult> UpdateStudyTitle(string sdSid, int id, [FromBody] StudyTitleDto studyTitleDto)
    {
        studyTitleDto.Id ??= id;
        studyTitleDto.SdSid ??= sdSid;
        
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyTitle = await _studyTitleService.GetStudyTitle(id);
        if (studyTitle.Total == 0 && studyTitle.Data.Length == 0) return Ok(new ApiResponse<StudyTitleDto>()
        {
            Total = studyTitle.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study titles have been found." },
            Data = studyTitle.Data
        });

        var updatedStudyTitle = await _studyTitleService.UpdateStudyTitle(studyTitleDto);
        if (updatedStudyTitle.Total == 0 && updatedStudyTitle.Data.Length == 0)
            return Ok(new ApiResponse<StudyTitleDto>()
            {
                Total = updatedStudyTitle.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during study title update." },
                Data = updatedStudyTitle.Data
            });

        return Ok(new ApiResponse<StudyTitleDto>()
        {
            Total = updatedStudyTitle.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedStudyTitle.Data
        });
    }

    [HttpDelete("studies/{sdSid}/titles/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study titles endpoint"})]
    public async Task<IActionResult> DeleteStudyTitle(string sdSid, int id)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyTitle = await _studyTitleService.GetStudyTitle(id);
        if (studyTitle.Total == 0 && studyTitle.Data.Length == 0) return Ok(new ApiResponse<StudyTitleDto>()
        {
            Total = studyTitle.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study titles have been found." },
            Data = studyTitle.Data
        });
        
        var count = await _studyTitleService.DeleteStudyTitle(id);
        return Ok(new ApiResponse<StudyTitleDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Study title has been removed." },
            Data = Array.Empty<StudyTitleDto>()
        });
    }

    [HttpDelete("studies/{sdSid}/titles")]
    [SwaggerOperation(Tags = new []{"Study titles endpoint"})]
    public async Task<IActionResult> DeleteAllStudyTitles(string sdSid)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });
        
        var count = await _studyTitleService.DeleteAllStudyTitles(sdSid);
        return Ok(new ApiResponse<StudyTitleDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All study titles have been removed." },
            Data = Array.Empty<StudyTitleDto>()
        });
    }
    
}