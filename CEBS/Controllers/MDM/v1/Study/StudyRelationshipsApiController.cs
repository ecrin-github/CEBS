using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Services.Study;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Study;

public class StudyRelationshipsApiController : BaseMdmApiController
{
    
    private readonly IStudyService _studyService;
    private readonly IStudyRelationshipService _studyRelationshipService;

    public StudyRelationshipsApiController(IStudyService studyService, IStudyRelationshipService studyRelationshipService)
    {
        _studyService = studyService ?? throw new ArgumentNullException(nameof(studyService));
        _studyRelationshipService = studyRelationshipService ?? throw new ArgumentNullException(nameof(studyRelationshipService));
    }
    
    [HttpGet("studies/{sdSid}/relationships")]
    [SwaggerOperation(Tags = new []{"Study relationships endpoint"})]
    public async Task<IActionResult> GetStudyRelationships(string sdSid)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyRelationships = await _studyRelationshipService.GetStudyRelationships(sdSid);
        if (studyRelationships.Total == 0 && studyRelationships.Data.Length == 0)
            return Ok(new ApiResponse<StudyRelationshipDto>()
            {
                Total = studyRelationships.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No study relationships have been found." },
                Data = studyRelationships.Data
            });
        
        return Ok(new ApiResponse<StudyRelationshipDto>()
        {
            Total = studyRelationships.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyRelationships.Data
        });
    }
    
    [HttpGet("studies/{sdSid}/relationships/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study relationships endpoint"})]
    public async Task<IActionResult> GetStudyRelationship(string sdSid, int id)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyRel = await _studyRelationshipService.GetStudyRelationship(id);
        if (studyRel.Total == 0 && studyRel.Data.Length == 0) return Ok(new ApiResponse<StudyRelationshipDto>()
        {
            Total = studyRel.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study relationships have been found." },
            Data = studyRel.Data
        });

        return Ok(new ApiResponse<StudyRelationshipDto>()
        {
            Total = studyRel.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyRel.Data
        });
    }

    [HttpPost("studies/{sdSid}/relationships")]
    [SwaggerOperation(Tags = new []{"Study relationships endpoint"})]
    public async Task<IActionResult> CreateStudyRelationship(string sdSid,
        [FromBody] StudyRelationshipDto studyRelationshipDto)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        studyRelationshipDto.SdSid ??= sdSid;

        var studyRel = await _studyRelationshipService.CreateStudyRelationship(studyRelationshipDto);
        if (studyRel.Total == 0 && studyRel.Data.Length == 0)
            return Ok(new ApiResponse<StudyRelationshipDto>()
            {
                Total = studyRel.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during study relationship creation." },
                Data = studyRel.Data
            });

        return Ok(new ApiResponse<StudyRelationshipDto>()
        {
            Total = studyRel.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyRel.Data
        });
    }

    [HttpPut("studies/{sdSid}/relationships/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study relationships endpoint"})]
    public async Task<IActionResult> UpdateStudyRelationship(string sdSid, int id, [FromBody] StudyRelationshipDto studyRelationshipDto)
    {
        studyRelationshipDto.Id ??= id;
        studyRelationshipDto.SdSid ??= sdSid;
        
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyRel = await _studyRelationshipService.GetStudyRelationship(id);
        if (studyRel.Total == 0 && studyRel.Data.Length == 0) return Ok(new ApiResponse<StudyRelationshipDto>()
        {
            Total = studyRel.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study relationships have been found." },
            Data = studyRel.Data
        });
        
        var updatedStudyRel = await _studyRelationshipService.UpdateStudyRelationship(studyRelationshipDto);
        if (updatedStudyRel.Total == 0 && updatedStudyRel.Data.Length == 0)
            return Ok(new ApiResponse<StudyRelationshipDto>()
            {
                Total = updatedStudyRel.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during study relationship update." },
                Data = updatedStudyRel.Data
            });

        return Ok(new ApiResponse<StudyRelationshipDto>()
        {
            Total = updatedStudyRel.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedStudyRel.Data
        });
    }

    [HttpDelete("studies/{sdSid}/relationships/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study relationships endpoint"})]
    public async Task<IActionResult> DeleteStudyRelationship(string sdSid, int id)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyRel = await _studyRelationshipService.GetStudyRelationship(id);
        if (studyRel.Total == 0 && studyRel.Data.Length == 0) return Ok(new ApiResponse<StudyRelationshipDto>()
        {
            Total = studyRel.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study relationships have been found." },
            Data = studyRel.Data
        });
        
        var count = await _studyRelationshipService.DeleteStudyRelationship(id);
        return Ok(new ApiResponse<StudyRelationshipDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Study relationship has been removed." },
            Data = Array.Empty<StudyRelationshipDto>()
        });
    }

    [HttpDelete("studies/{sdSid}/relationships")]
    [SwaggerOperation(Tags = new []{"Study relationships endpoint"})]
    public async Task<IActionResult> DeleteAllStudyRelationships(string sdSid)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var count = await _studyRelationshipService.DeleteAllStudyRelationships(sdSid);
        return Ok(new ApiResponse<StudyRelationshipDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All study relationships have been removed." },
            Data = Array.Empty<StudyRelationshipDto>()
        });
    }

}