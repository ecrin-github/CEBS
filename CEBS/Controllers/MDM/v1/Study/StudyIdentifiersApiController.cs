using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Services.Study;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Study;

public class StudyIdentifiersApiController : BaseMdmApiController
{

    private readonly IStudyService _studyService;
    private readonly IStudyIdentifierService _studyIdentifierService;

    public StudyIdentifiersApiController(IStudyService studyService, IStudyIdentifierService studyIdentifierService)
    {
        _studyService = studyService ?? throw new ArgumentNullException(nameof(studyService));
        _studyIdentifierService = studyIdentifierService ?? throw new ArgumentNullException(nameof(studyIdentifierService));
    }
    
    
    [HttpGet("studies/{sdSid}/identifiers")]
    [SwaggerOperation(Tags = new []{"Study identifiers endpoint"})]
    public async Task<IActionResult> GetStudyIdentifiers(string sdSid)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyIdents = await _studyIdentifierService.GetStudyIdentifiers(sdSid);
        if (studyIdents.Total == 0 && studyIdents.Data.Length == 0)
            return Ok(new ApiResponse<StudyIdentifierDto>()
            {
                Total = studyIdents.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No study identifiers have been found." },
                Data = studyIdents.Data
            });
        
        return Ok(new ApiResponse<StudyIdentifierDto>()
        {
            Total = studyIdents.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyIdents.Data
        });
    }
    
    [HttpGet("studies/{sdSid}/identifiers/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study identifiers endpoint"})]
    public async Task<IActionResult> GetStudyIdentifier(string sdSid, int id)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyIdent = await _studyIdentifierService.GetStudyIdentifier(id);
        if (studyIdent.Total == 0 && studyIdent.Data.Length == 0) return Ok(new ApiResponse<StudyIdentifierDto>()
        {
            Total = studyIdent.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study features have been found." },
            Data = studyIdent.Data
        });

        return Ok(new ApiResponse<StudyIdentifierDto>()
        {
            Total = studyIdent.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyIdent.Data
        });
    }

    [HttpPost("studies/{sdSid}/identifiers")]
    [SwaggerOperation(Tags = new []{"Study identifiers endpoint"})]
    public async Task<IActionResult> CreateStudyIdentifier(string sdSid, [FromBody] StudyIdentifierDto studyIdentifierDto)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        studyIdentifierDto.SdSid ??= sdSid;

        var studyIdent = await _studyIdentifierService.CreateStudyIdentifier(studyIdentifierDto);
        if (studyIdent.Total == 0 && studyIdent.Data.Length == 0)
            return Ok(new ApiResponse<StudyIdentifierDto>()
            {
                Total = studyIdent.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during study identifier creation." },
                Data = studyIdent.Data
            });

        return Ok(new ApiResponse<StudyIdentifierDto>()
        {
            Total = studyIdent.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyIdent.Data
        });
    }

    [HttpPut("studies/{sdSid}/identifiers/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study identifiers endpoint"})]
    public async Task<IActionResult> UpdateStudyIdentifier(string sdSid, int id, [FromBody] StudyIdentifierDto studyIdentifierDto)
    {
        studyIdentifierDto.Id ??= id;
        studyIdentifierDto.SdSid ??= sdSid;
        
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });
        
        var studyIdent = await _studyIdentifierService.GetStudyIdentifier(id);
        if (studyIdent.Total == 0 && studyIdent.Data.Length == 0) return Ok(new ApiResponse<StudyIdentifierDto>()
        {
            Total = studyIdent.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study identifiers have been found." },
            Data = studyIdent.Data
        });

        var updatedStudyIdent = await _studyIdentifierService.UpdateStudyIdentifier(studyIdentifierDto);
        if (updatedStudyIdent.Total == 0 && updatedStudyIdent.Data.Length == 0)
            return Ok(new ApiResponse<StudyIdentifierDto>()
            {
                Total = updatedStudyIdent.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during study identifier update." },
                Data = updatedStudyIdent.Data
            });

        return Ok(new ApiResponse<StudyIdentifierDto>()
        {
            Total = updatedStudyIdent.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedStudyIdent.Data
        });
    }

    [HttpDelete("studies/{sdSid}/identifiers/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study identifiers endpoint"})]
    public async Task<IActionResult> DeleteStudyIdentifier(string sdSid, int id)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });
        
        var studyIdent = await _studyIdentifierService.GetStudyIdentifier(id);
        if (studyIdent.Total == 0 && studyIdent.Data.Length == 0) return Ok(new ApiResponse<StudyIdentifierDto>()
        {
            Total = studyIdent.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study identifiers have been found." },
            Data = studyIdent.Data
        });
        
        var count = await _studyIdentifierService.DeleteStudyIdentifier(id);
        return Ok(new ApiResponse<StudyIdentifierDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Study identifier has been removed." },
            Data = studyIdent.Data
        });
    }

    [HttpDelete("studies/{sdSid}/identifiers")]
    [SwaggerOperation(Tags = new []{"Study identifiers endpoint"})]
    public async Task<IActionResult> DeleteAllStudyIdentifiers(string sdSid)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });
        
        var count = await _studyIdentifierService.DeleteAllStudyIdentifiers(sdSid);
        return Ok(new ApiResponse<StudyIdentifierDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All study identifiers have been removed." },
            Data = Array.Empty<StudyIdentifierDto>()
        });
    }
    
}