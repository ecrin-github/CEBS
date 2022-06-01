using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Object;

public class ObjectRelationshipsApiController : BaseMdmApiController
{
    
    private readonly IDataObjectService _dataObjectService;
    private readonly IObjectRelationshipService _objectRelationshipService;

    public ObjectRelationshipsApiController(IDataObjectService dataObjectService, IObjectRelationshipService objectRelationshipService)
    {
        _dataObjectService = dataObjectService ?? throw new ArgumentNullException(nameof(dataObjectService));
        _objectRelationshipService = objectRelationshipService ?? throw new ArgumentNullException(nameof(objectRelationshipService));
    }
    
    
    [HttpGet("data-objects/{sdOid}/relationships")]
    [SwaggerOperation(Tags = new []{"Object relationships endpoint"})]
    public async Task<IActionResult> GetObjectRelationships(string sdOid)
    {
        var dataObject = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObject.Data
        });

        var objRel = await _objectRelationshipService.GetObjectRelationships(sdOid);
        if (objRel.Total == 0 && objRel.Data.Length == 0)
            return Ok(new ApiResponse<ObjectRelationshipDto>()
            {
                Total = objRel.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No data object relationships have been found." },
                Data = objRel.Data
            });
        
        return Ok(new ApiResponse<ObjectRelationshipDto>()
        {
            Total = objRel.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objRel.Data
        });
    }
    
    [HttpGet("data-objects/{sdOid}/relationships/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object relationships endpoint"})]
    public async Task<IActionResult> GetObjectRelationship(string sdOid, int id)
    {
        var dataObject = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObject.Data
        });

        var objRel = await _objectRelationshipService.GetObjectRelationship(id);
        if (objRel.Total == 0 && objRel.Data.Length == 0) return Ok(new ApiResponse<ObjectRelationshipDto>()
        {
            Total = objRel.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object relationships have been found." },
            Data = objRel.Data
        });

        return Ok(new ApiResponse<ObjectRelationshipDto>()
        {
            Total = objRel.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objRel.Data
        });
    }

    [HttpPost("data-objects/{sdOid}/relationships")]
    [SwaggerOperation(Tags = new []{"Object relationships endpoint"})]
    public async Task<IActionResult> CreateObjectRelationship(string sdOid,
        [FromBody] ObjectRelationshipDto objectRelationshipDto)
    {
        var dataObject = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObject.Data
        });
        
        objectRelationshipDto.SdOid ??= sdOid;
        var objRel = await _objectRelationshipService.CreateObjectRelationship(objectRelationshipDto);
        if (objRel.Total == 0 && objRel.Data.Length == 0)
            return Ok(new ApiResponse<ObjectRelationshipDto>()
            {
                Total = objRel.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during object relationship creation." },
                Data = objRel.Data
            });

        return Ok(new ApiResponse<ObjectRelationshipDto>()
        {
            Total = objRel.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objRel.Data
        });
    }

    [HttpPut("data-objects/{sdOid}/relationships/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object relationships endpoint"})]
    public async Task<IActionResult> UpdateObjectRelationship(string sdOid, int id, [FromBody] ObjectRelationshipDto objectRelationshipDto)
    {
        objectRelationshipDto.Id ??= id;
        objectRelationshipDto.SdOid ??= sdOid;
        
        var dataObject = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObject.Data
        });
        
        var objRel = await _objectRelationshipService.GetObjectRelationship(id);
        if (objRel.Total == 0 && objRel.Data.Length == 0) return Ok(new ApiResponse<ObjectRelationshipDto>()
        {
            Total = objRel.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object relationships have been found." },
            Data = objRel.Data
        });
        
        var updatedObjectRel = await _objectRelationshipService.UpdateObjectRelationship(objectRelationshipDto);
        if (updatedObjectRel.Total == 0 && updatedObjectRel.Data.Length == 0) return Ok(new ApiResponse<ObjectRelationshipDto>()
        {
            Total = updatedObjectRel.Total,
            StatusCode = BadRequest().StatusCode,
            Messages = new [] { "Error during object relationship update." },
            Data = updatedObjectRel.Data
        });

        return Ok(new ApiResponse<ObjectRelationshipDto>()
        {
            Total = updatedObjectRel.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedObjectRel.Data
        });
    }
    
    [HttpDelete("data-objects/{sdOid}/relationships/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object relationships endpoint"})]
    public async Task<IActionResult> DeleteObjectRelationship(string sdOid, int id)
    {
        var dataObject = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObject.Data
        });
        
        var objRel = await _objectRelationshipService.GetObjectRelationship(id);
        if (objRel.Total == 0 && objRel.Data.Length == 0) return Ok(new ApiResponse<ObjectRelationshipDto>()
        {
            Total = objRel.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object relationships have been found." },
            Data = objRel.Data
        });
        
        var count = await _objectRelationshipService.DeleteObjectRelationship(id);
        return Ok(new ApiResponse<ObjectRelationshipDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Object relationship has been removed." },
            Data = Array.Empty<ObjectRelationshipDto>()
        });
    }

    [HttpDelete("data-objects/{sdOid}/relationships")]
    [SwaggerOperation(Tags = new []{"Object relationships endpoint"})]
    public async Task<IActionResult> DeleteAllObjectRelationships(string sdOid)
    {
        var dataObject = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObject.Data
        });
        
        var count = await _objectRelationshipService.DeleteAllObjectRelationships(sdOid);
        return Ok(new ApiResponse<ObjectRelationshipDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All object relationships have been removed." },
            Data = Array.Empty<ObjectRelationshipDto>()
        });
    }
    
}