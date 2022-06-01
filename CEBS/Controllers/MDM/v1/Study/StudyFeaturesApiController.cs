using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Services.Study;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Study;

public class StudyFeaturesApiController : BaseMdmApiController
{
    
    private readonly IStudyService _studyService;
    private readonly IStudyFeatureService _studyFeatureService;

    public StudyFeaturesApiController(IStudyService studyService, IStudyFeatureService studyFeatureService)
    {
        _studyService = studyService ?? throw new ArgumentNullException(nameof(studyService));
        _studyFeatureService = studyFeatureService ?? throw new ArgumentNullException(nameof(studyFeatureService));
    }

    [HttpGet("studies/{sdSid}/features")]
    [SwaggerOperation(Tags = new[] { "Study features endpoint" })]
    public async Task<IActionResult> GetStudyFeatures(string sdSid)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });
        
        var studyFeatures = await _studyFeatureService.GetStudyFeatures(sdSid);
        if (studyFeatures.Total == 0 && studyFeatures.Data.Length == 0)
            return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = studyFeatures.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No study features have been found." },
                Data = studyFeatures.Data
            });
        
        return Ok(new ApiResponse<StudyFeatureDto>()
        {
            Total = studyFeatures.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyFeatures.Data
        });
    }

    [HttpGet("studies/{sdSid}/features/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Study features endpoint" })]
    public async Task<IActionResult> GetStudyFeature(string sdSid, int id)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyFeature = await _studyFeatureService.GetStudyFeature(id);
        if (studyFeature.Total == 0 && studyFeature.Data.Length == 0) return Ok(new ApiResponse<StudyFeatureDto>()
        {
            Total = studyFeature.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study features have been found." },
            Data = studyFeature.Data
        });

        return Ok(new ApiResponse<StudyFeatureDto>()
        {
            Total = study.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyFeature.Data
        });
    }

    [HttpPost("studies/{sdSid}/features")]
    [SwaggerOperation(Tags = new []{"Study features endpoint"})]
    public async Task<IActionResult> CreateStudyFeature(string sdSid, [FromBody] StudyFeatureDto studyFeatureDto)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        studyFeatureDto.SdSid ??= sdSid;

        var studyFeature = await _studyFeatureService.CreateStudyFeature(studyFeatureDto);
        if (studyFeature.Total == 0 && studyFeature.Data.Length == 0)
            return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = studyFeature.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during study feature creation." },
                Data = studyFeature.Data
            });

        return Ok(new ApiResponse<StudyFeatureDto>()
        {
            Total = studyFeature.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyFeature.Data
        });
    }

    [HttpPut("studies/{sdSid}/features/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study features endpoint"})]
    public async Task<IActionResult> UpdateStudyFeature(string sdSid, int id, [FromBody] StudyFeatureDto studyFeatureDto)
    {
        studyFeatureDto.Id ??= id;
        studyFeatureDto.SdSid ??= sdSid;
        
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });
        
        var studyFeature = await _studyFeatureService.GetStudyFeature(id);
        if (studyFeature.Total == 0 && studyFeature.Data.Length == 0) return Ok(new ApiResponse<StudyFeatureDto>()
        {
            Total = studyFeature.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study features have been found." },
            Data = studyFeature.Data
        });
        
        var updatedStudyFeature = await _studyFeatureService.UpdateStudyFeature(studyFeatureDto);
        if (updatedStudyFeature.Total == 0 && updatedStudyFeature.Data.Length == 0)
            return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = updatedStudyFeature.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during study feature update." },
                Data = updatedStudyFeature.Data
            });

        return Ok(new ApiResponse<StudyFeatureDto>()
        {
            Total = updatedStudyFeature.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedStudyFeature.Data
        });
    }

    [HttpDelete("studies/{sdSid}/features/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study features endpoint"})]
    public async Task<IActionResult> DeleteStudyFeature(string sdSid, int id)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });
        
        var studyFeature = await _studyFeatureService.GetStudyFeature(id);
        if (studyFeature.Total == 0 && studyFeature.Data.Length == 0) return Ok(new ApiResponse<StudyFeatureDto>()
        {
            Total = studyFeature.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study features have been found." },
            Data = studyFeature.Data
        });
        
        var count = await _studyFeatureService.DeleteStudyFeature(id);
        return Ok(new ApiResponse<StudyFeatureDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Study feature has been removed." },
            Data = Array.Empty<StudyFeatureDto>()
        });
    }

    [HttpDelete("studies/{sdSid}/features")]
    [SwaggerOperation(Tags = new []{"Study features endpoint"})]
    public async Task<IActionResult> DeleteAllStudyFeatures(string sdSid)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });
        
        var count = await _studyFeatureService.DeleteAllStudyFeatures(sdSid);
        return Ok(new ApiResponse<StudyFeatureDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All study features have been removed." },
            Data = Array.Empty<StudyFeatureDto>()
        });
    }
    
}