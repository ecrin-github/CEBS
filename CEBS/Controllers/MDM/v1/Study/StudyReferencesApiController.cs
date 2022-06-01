using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Services.Study;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Study;

public class StudyReferencesApiController : BaseMdmApiController
{
    
    private readonly IStudyService _studyService;
    private readonly IStudyReferenceService _studyReferenceService;

    public StudyReferencesApiController(IStudyService studyService, IStudyReferenceService studyReferenceService)
    {
        _studyService = studyService ?? throw new ArgumentNullException(nameof(studyService));
        _studyReferenceService = studyReferenceService ?? throw new ArgumentNullException(nameof(studyReferenceService));
    }
    
    [HttpGet("studies/{sdSid}/references")]
    [SwaggerOperation(Tags = new []{"Study references endpoint"})]
    public async Task<IActionResult> GetStudyReferences(string sdSid)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyRefs = await _studyReferenceService.GetStudyReferences(sdSid);
        if (studyRefs.Total == 0 && studyRefs.Data.Length == 0)
            return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = studyRefs.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No study references have been found." },
                Data = studyRefs.Data
            });
        
        return Ok(new ApiResponse<StudyReferenceDto>()
        {
            Total = studyRefs.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyRefs.Data
        });
    }
    
    [HttpGet("studies/{sdSid}/references/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study references endpoint"})]
    public async Task<IActionResult> GetStudyReferences(string sdSid, int id)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyRef = await _studyReferenceService.GetStudyReference(id);
        if (studyRef.Total == 0 && studyRef.Data.Length == 0) return Ok(new ApiResponse<StudyReferenceDto>()
        {
            Total = studyRef.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study references have been found." },
            Data = studyRef.Data
        });

        return Ok(new ApiResponse<StudyReferenceDto>()
        {
            Total = studyRef.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyRef.Data
        });
    }

    [HttpPost("studies/{sdSid}/references")]
    [SwaggerOperation(Tags = new []{"Study references endpoint"})]
    public async Task<IActionResult> CreateStudyReference(string sdSid,
        [FromBody] StudyReferenceDto studyReferenceDto)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        studyReferenceDto.SdSid ??= sdSid;

        var studyRef = await _studyReferenceService.CreateStudyReference(studyReferenceDto);
        if (studyRef.Total == 0 && studyRef.Data.Length == 0)
            return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = studyRef.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during study reference creation." },
                Data = studyRef.Data
            });

        return Ok(new ApiResponse<StudyReferenceDto>()
        {
            Total = studyRef.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyRef.Data
        });
    }

    [HttpPut("studies/{sdSid}/references/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study references endpoint"})]
    public async Task<IActionResult> UpdateStudyReference(string sdSid, int id, [FromBody] StudyReferenceDto studyReferenceDto)
    {
        studyReferenceDto.Id ??= id;
        studyReferenceDto.SdSid ??= sdSid;
        
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });
        var studyRef = await _studyReferenceService.GetStudyReference(id);
        if (studyRef.Total == 0 && studyRef.Data.Length == 0) return Ok(new ApiResponse<StudyReferenceDto>()
        {
            Total = studyRef.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study references have been found." },
            Data = studyRef.Data
        });

        var updatedStudyRef = await _studyReferenceService.UpdateStudyReference(studyReferenceDto);
        if (updatedStudyRef.Total == 0 && updatedStudyRef.Data.Length == 0)
            return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = updatedStudyRef.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during study reference update." },
                Data = updatedStudyRef.Data
            });

        return Ok(new ApiResponse<StudyReferenceDto>()
        {
            Total = updatedStudyRef.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedStudyRef.Data
        });
    }

    [HttpDelete("studies/{sdSid}/references/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study references endpoint"})]
    public async Task<IActionResult> DeleteStudyReference(string sdSid, int id)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyRef = await _studyReferenceService.GetStudyReference(id);
        if (studyRef.Total == 0 && studyRef.Data.Length == 0) return Ok(new ApiResponse<StudyReferenceDto>()
        {
            Total = studyRef.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study references have been found." },
            Data = studyRef.Data
        });
        
        var count = await _studyReferenceService.DeleteStudyReference(id);
        return Ok(new ApiResponse<StudyReferenceDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Study reference has been removed." },
            Data = Array.Empty<StudyReferenceDto>()
        });
    }

    [HttpDelete("studies/{sdSid}/references")]
    [SwaggerOperation(Tags = new []{"Study references endpoint"})]
    public async Task<IActionResult> DeleteAllStudyReferences(string sdSid)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });
        
        var count = await _studyReferenceService.DeleteAllStudyReferences(sdSid);
        return Ok(new ApiResponse<StudyReferenceDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All study references have been removed." },
            Data = Array.Empty<StudyReferenceDto>()
        });
    }
    
}