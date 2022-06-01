using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Object;

public class ObjectTopicsApiController : BaseMdmApiController
{
    
    private readonly IDataObjectService _dataObjectService;
    private readonly IObjectTopicService _objectTopicService;

    public ObjectTopicsApiController(IDataObjectService objectService, IObjectTopicService objectTopicService)
    {
        _dataObjectService = objectService ?? throw new ArgumentNullException(nameof(objectService));
        _objectTopicService = objectTopicService ?? throw new ArgumentNullException(nameof(objectTopicService));
    }
    
    
    [HttpGet("data-objects/{sdOid}/topics")]
    [SwaggerOperation(Tags = new []{"Object topics endpoint"})]
    public async Task<IActionResult> GetObjectTopics(string sdOid)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objTopics = await _objectTopicService.GetObjectTopics(sdOid);
        if (objTopics.Total == 0 && objTopics.Data.Length == 0)
            return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = objTopics.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No data object topics have been found." },
                Data = objTopics.Data
            });
        
        return Ok(new ApiResponse<ObjectTopicDto>()
        {
            Total = objTopics.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objTopics.Data
        });
    }
    
    [HttpGet("data-objects/{sdOid}/topics/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object topics endpoint"})]
    public async Task<IActionResult> GetObjectTopic(string sdOid, int id)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objTopic = await _objectTopicService.GetObjectTopic(id);
        if (objTopic.Total == 0 && objTopic.Data.Length == 0) return Ok(new ApiResponse<ObjectTopicDto>()
        {
            Total = objTopic.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object topics have been found." },
            Data = objTopic.Data
        });

        return Ok(new ApiResponse<ObjectTopicDto>()
        {
            Total = objTopic.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objTopic.Data
        });
    }

    [HttpPost("data-objects/{sdOid}/topics")]
    [SwaggerOperation(Tags = new []{"Object topics endpoint"})]
    public async Task<IActionResult> CreateObjectTopic(string sdOid,
        [FromBody] ObjectTopicDto objectTopicDto)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        objectTopicDto.SdOid ??= sdOid;

        var objTopic = await _objectTopicService.CreateObjectTopic(objectTopicDto);
        if (objTopic.Total == 0 && objTopic.Data.Length == 0) return Ok(new ApiResponse<ObjectTopicDto>()
        {
            Total = objTopic.Total,
            StatusCode = BadRequest().StatusCode,
            Messages = new [] { "Error during object topic creation." },
            Data = objTopic.Data
        });

        return Ok(new ApiResponse<ObjectTopicDto>()
        {
            Total = objTopic.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objTopic.Data
        });
    }

    [HttpPut("data-objects/{sdOid}/topics/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object topics endpoint"})]
    public async Task<IActionResult> UpdateObjectTopic(string sdOid, int id, [FromBody] ObjectTopicDto objectTopicDto)
    {
        objectTopicDto.Id ??= id;
        objectTopicDto.SdOid ??= sdOid;
        
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objTopic = await _objectTopicService.GetObjectTopic(id);
        if (objTopic.Total == 0 && objTopic.Data.Length == 0) return Ok(new ApiResponse<ObjectTopicDto>()
        {
            Total = objTopic.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object topics have been found." },
            Data = objTopic.Data
        });

        var updatedObjectTopic = await _objectTopicService.UpdateObjectTopic(objectTopicDto);
        if (updatedObjectTopic.Total == 0 && updatedObjectTopic.Data.Length == 0)
            return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = updatedObjectTopic.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during object topic update." },
                Data = updatedObjectTopic.Data
            });

        return Ok(new ApiResponse<ObjectTopicDto>()
        {
            Total = updatedObjectTopic.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedObjectTopic.Data
        });
    }
    
    [HttpDelete("data-objects/{sdOid}/topics/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object topics endpoint"})]
    public async Task<IActionResult> DeleteObjectTopic(string sdOid, int id)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objTopic = await _objectTopicService.GetObjectTopic(id);
        if (objTopic.Total == 0 && objTopic.Data.Length == 0) return Ok(new ApiResponse<ObjectTopicDto>()
        {
            Total = objTopic.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object topics have been found." },
            Data = objTopic.Data
        });
        
        var count = await _objectTopicService.DeleteObjectTopic(id);
        return Ok(new ApiResponse<ObjectTopicDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Object topic has been removed." },
            Data = Array.Empty<ObjectTopicDto>()
        });
    }

    [HttpDelete("data-objects/{sdOid}/topics")]
    [SwaggerOperation(Tags = new []{"Object topics endpoint"})]
    public async Task<IActionResult> DeleteAllObjectTopics(string sdOid)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var count = await _objectTopicService.DeleteAllObjectTopics(sdOid);
        return Ok(new ApiResponse<ObjectTopicDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All object topics have been removed." },
            Data = Array.Empty<ObjectTopicDto>()
        });
    }
    
}