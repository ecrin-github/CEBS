using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Services.Study;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Study;

public class StudyTopicsApiController : BaseMdmApiController
{
    private readonly IStudyService _studyService;
    private readonly IStudyTopicService _studyTopicService;

    public StudyTopicsApiController(IStudyService studyService, IStudyTopicService studyTopicService)
    {
        _studyService = studyService ?? throw new ArgumentNullException(nameof(studyService));
        _studyTopicService = studyTopicService ?? throw new ArgumentNullException(nameof(studyTopicService));
    }
    
    
    [HttpGet("studies/{sdSid}/topics")]
    [SwaggerOperation(Tags = new []{"Study topics endpoint"})]
    public async Task<IActionResult> GetStudyTopics(string sdSid)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyTopics = await _studyTopicService.GetStudyTopics(sdSid);
        if (studyTopics.Total == 0 && studyTopics.Data.Length == 0)
            return Ok(new ApiResponse<StudyTopicDto>()
            {
                Total = studyTopics.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No study topics have been found." },
                Data = studyTopics.Data
            });
        
        return Ok(new ApiResponse<StudyTopicDto>()
        {
            Total = studyTopics.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyTopics.Data
        });
    }
    
    [HttpGet("studies/{sdSid}/topics/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study topics endpoint"})]
    public async Task<IActionResult> GetStudyTopic(string sdSid, int id)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyTopic = await _studyTopicService.GetStudyTopic(id);
        if (studyTopic.Total == 0 && studyTopic.Data.Length == 0) return Ok(new ApiResponse<StudyTopicDto>()
        {
            Total = studyTopic.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study topics have been found." },
            Data = studyTopic.Data
        });

        return Ok(new ApiResponse<StudyTopicDto>()
        {
            Total = studyTopic.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyTopic.Data
        });
    }

    [HttpPost("studies/{sdSid}/topics")]
    [SwaggerOperation(Tags = new []{"Study topics endpoint"})]
    public async Task<IActionResult> CreateStudyTopic(string sdSid, [FromBody] StudyTopicDto studyTopicDto)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        studyTopicDto.SdSid ??= sdSid;
        
        var studyTopic = await _studyTopicService.CreateStudyTopic(studyTopicDto);
        if (studyTopic.Total == 0 && studyTopic.Data.Length == 0) return Ok(new ApiResponse<StudyTopicDto>()
        {
            Total = studyTopic.Total,
            StatusCode = BadRequest().StatusCode,
            Messages = new [] { "Error during study topic creation." },
            Data = studyTopic.Data
        });

        return Ok(new ApiResponse<StudyTopicDto>()
        {
            Total = studyTopic.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = studyTopic.Data
        });
    }

    [HttpPut("studies/{sdSid}/topics/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study topics endpoint"})]
    public async Task<IActionResult> UpdateStudyTopic(string sdSid, int id, [FromBody] StudyTopicDto studyTopicDto)
    {
        studyTopicDto.Id ??= id;
        studyTopicDto.SdSid ??= sdSid;
        
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyTopic = await _studyTopicService.GetStudyTopic(id);
        if (studyTopic.Total == 0 && studyTopic.Data.Length == 0) return Ok(new ApiResponse<StudyTopicDto>()
        {
            Total = studyTopic.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study topics have been found." },
            Data = studyTopic.Data
        });

        var updatedStudyTopic = await _studyTopicService.UpdateStudyTopic(studyTopicDto);
        if (updatedStudyTopic.Total == 0 && updatedStudyTopic.Data.Length == 0)
            return Ok(new ApiResponse<StudyTopicDto>()
            {
                Total = updatedStudyTopic.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during study topic update." },
                Data = updatedStudyTopic.Data
            });

        return Ok(new ApiResponse<StudyTopicDto>()
        {
            Total = updatedStudyTopic.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedStudyTopic.Data
        });
    }

    [HttpDelete("studies/{sdSid}/topics/{id:int}")]
    [SwaggerOperation(Tags = new []{"Study topics endpoint"})]
    public async Task<IActionResult> DeleteStudyTopic(string sdSid, int id)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });

        var studyTopic = await _studyTopicService.GetStudyTopic(id);
        if (studyTopic.Total == 0 && studyTopic.Data.Length == 0) return Ok(new ApiResponse<StudyTopicDto>()
        {
            Total = studyTopic.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No study topics have been found." },
            Data = studyTopic.Data
        });
        
        var count = await _studyTopicService.DeleteStudyTopic(id);
        return Ok(new ApiResponse<StudyTopicDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Study topic has been found." },
            Data = Array.Empty<StudyTopicDto>()
        });
    }

    [HttpDelete("studies/{sdSid}/topics")]
    [SwaggerOperation(Tags = new []{"Study topics endpoint"})]
    public async Task<IActionResult> DeleteAllStudyTopics(string sdSid)
    {
        var study = await _studyService.GetStudyBySdSid(sdSid);
        if (study.Total == 0 && study.Data.Length == 0) return Ok(new ApiResponse<StudyDto>()
        {
            Total = study.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No studies have been found." },
            Data = study.Data
        });
        
        var count = await _studyTopicService.DeleteAllStudyTopics(sdSid);
        return Ok(new ApiResponse<StudyTopicDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All study topics have been removed." },
            Data = Array.Empty<StudyTopicDto>()
        });
    }
}