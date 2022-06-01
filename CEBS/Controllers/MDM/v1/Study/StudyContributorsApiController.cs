using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Services.Study;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Study;

public class StudyContributorsApiController : BaseMdmApiController
{
    private readonly IStudyService _studyService;
    private readonly IStudyContributorService _studyContributorService;

    public StudyContributorsApiController(IStudyService studyService, IStudyContributorService studyContributorService)
    {
        _studyService = studyService ?? throw new ArgumentNullException(nameof(studyService));
        _studyContributorService = studyContributorService ?? throw new ArgumentNullException(nameof(studyContributorService));
    }

    [HttpGet("studies/{sdSid}/contributors")]
    [SwaggerOperation(Tags = new []{"Study contributors endpoint"})]
    public async Task<IActionResult> GetStudyContributors(string sdSid)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyContribs = await _studyContributorService.GetStudyContributors(sdSid);
        if (studyContribs.Total == 0 && studyContribs.Data.Length == 0)
            return Ok(new ApiResponse<StudyContributorDto>()
            {
                Total = studyContribs.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No study contributors have been found." },
                Data = studyContribs.Data
            });
        return Ok(new ApiResponse<StudyContributorDto>()
        {
            Total = studyContribs.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyContribs.Data
        });
    }

    [HttpGet("studies/{sdSid}/contributors/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study contributors endpoint"})]
    public async Task<IActionResult> GetStudyContributor(string sdSid, int id)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });
        
        var studyContributor = await _studyContributorService.GetStudyContributor(id);
        if (studyContributor.Total == 0 && studyContributor.Data.Length == 0) return Ok(new ApiResponse<StudyContributorDto>()
        {
            Total = studyContributor.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study contributors have been found." },
            Data = studyContributor.Data
        });

        return Ok(new ApiResponse<StudyContributorDto>()
        {
            Total = studyContributor.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyContributor.Data
        });
    }

    [HttpPost("studies/{sdSid}/contributors")]
    [SwaggerOperation(Tags = new []{"Study contributors endpoint"})]
    public async Task<IActionResult> CreateStudyContributor(string sdSid, [FromBody] StudyContributorDto studyContributorDto)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        studyContributorDto.SdSid ??= sdSid;

        var studyContrib = await _studyContributorService.CreateStudyContributor(studyContributorDto);
        if (studyContrib.Total == 0 && studyContrib.Data.Length == 0)
            return Ok(new ApiResponse<StudyContributorDto>()
            {
                Total = studyContrib.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during study contributor creation." },
                Data = studyContrib.Data
            });
        
        return Ok(new ApiResponse<StudyContributorDto>()
        {
            Total = studyContrib.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyContrib.Data
        });
    }

    [HttpPut("studies/{sdSid}/contributors/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study contributors endpoint"})]
    public async Task<IActionResult> UpdateStudyContributor(string sdSid, int id, [FromBody] StudyContributorDto studyContributorDto)
    {
        studyContributorDto.Id ??= id;
        studyContributorDto.SdSid ??= sdSid;
        
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0)
            return Ok(new ApiResponse<StudyDto>()
            {
                Total = study.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No studies have been found." },
                Data = study.Data
            });
        
        var studyContributor = await _studyContributorService.GetStudyContributor(id);
        if (studyContributor.Total == 0 && studyContributor.Data.Length == 0) return Ok(new ApiResponse<StudyContributorDto>()
        {
            Total = studyContributor.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study contributors have been found." },
            Data = studyContributor.Data
        });
        
        var updatedStudyContrib = await _studyContributorService.UpdateStudyContributor(studyContributorDto);
        if (updatedStudyContrib.Total == 0 && updatedStudyContrib.Data.Length == 0)
            return Ok(new ApiResponse<StudyContributorDto>()
            {
                Total = updatedStudyContrib.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during study contributor update." },
                Data = updatedStudyContrib.Data
            });

        return Ok(new ApiResponse<StudyContributorDto>()
        {
            Total = updatedStudyContrib.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedStudyContrib.Data
        });
    }

    [HttpDelete("studies/{sdSid}/contributors/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study contributors endpoint"})]
    public async Task<IActionResult> DeleteStudyContributor(string sdSid, int id)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });
        
        var studyContrib = await _studyContributorService.GetStudyContributor(id);
        if (studyContrib.Total == 0 && studyContrib.Data.Length == 0) return Ok(new ApiResponse<StudyContributorDto>()
        {
            Total = studyContrib.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study contributors have been found." },
            Data = studyContrib.Data
        });
        var count = await _studyContributorService.DeleteStudyContributor(id);
        return Ok(new ApiResponse<StudyContributorDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Study contributor has been removed." },
            Data = Array.Empty<StudyContributorDto>()
        });
    }

    [HttpDelete("studies/{sdSid}/contributors")]
    [SwaggerOperation(Tags = new []{"Study contributors endpoint"})]
    public async Task<IActionResult> DeleteAllStudyContributors(string sdSid)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });
        var count = await _studyContributorService.DeleteAllStudyContributors(sdSid);
        return Ok(new ApiResponse<StudyContributorDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All study contributors have been removed." },
            Data = Array.Empty<StudyContributorDto>()
        });
    }

}