using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Object;

public class ObjectRightsApiController : BaseMdmApiController
{
    
    private readonly IDataObjectService _dataObjectService;
    private readonly IObjectRightService _objectRightService;

    public ObjectRightsApiController(IDataObjectService objectService, IObjectRightService objectRightService)
    {
        _dataObjectService = objectService ?? throw new ArgumentNullException(nameof(objectService));
        _objectRightService = objectRightService ?? throw new ArgumentNullException(nameof(objectRightService));
    }
    
    
    [HttpGet("data-objects/{sdOid}/rights")]
    [SwaggerOperation(Tags = new []{"Object rights endpoint"})]
    public async Task<IActionResult> GetObjectRights(string sdOid)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objRights = await _objectRightService.GetObjectRights(sdOid);
        if (objRights.Total == 0 && objRights.Data.Length == 0) return Ok(new ApiResponse<ObjectRightDto>()
        {
            Total = objRights.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object rights have been found." },
            Data = objRights.Data
        });
        
        return Ok(new ApiResponse<ObjectRightDto>()
        {
            Total = objRights.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objRights.Data
        });
    }
    
    [HttpGet("data-objects/{sdOid}/rights/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object rights endpoint"})]
    public async Task<IActionResult> GetObjectRight(string sdOid, int id)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objRight = await _objectRightService.GetObjectRight(id);
        if (objRight.Total == 0 && objRight.Data.Length == 0) return Ok(new ApiResponse<ObjectRightDto>()
        {
            Total = objRight.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object rights have been found." },
            Data = objRight.Data
        });

        return Ok(new ApiResponse<ObjectRightDto>()
        {
            Total = objRight.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objRight.Data
        });
    }

    [HttpPost("data-objects/{sdOid}/rights")]
    [SwaggerOperation(Tags = new []{"Object rights endpoint"})]
    public async Task<IActionResult> CreateObjectRight(string sdOid,
        [FromBody] ObjectRightDto objectRightDto)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        objectRightDto.SdOid ??= sdOid;
        
        var objRight = await _objectRightService.CreateObjectRight(objectRightDto);
        if (objRight.Total == 0 && objRight.Data.Length == 0) return Ok(new ApiResponse<ObjectRightDto>()
        {
            Total = objRight.Total,
            StatusCode = BadRequest().StatusCode,
            Messages = new [] { "Error during object right creation." },
            Data = objRight.Data
        });

        return Ok(new ApiResponse<ObjectRightDto>()
        {
            Total = objRight.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objRight.Data
        });
    }

    [HttpPut("data-objects/{sdOid}/rights/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object rights endpoint"})]
    public async Task<IActionResult> UpdateObjectRight(string sdOid, int id, [FromBody] ObjectRightDto objectRightDto)
    {
        objectRightDto.Id ??= id;
        objectRightDto.SdOid ??= sdOid;
        
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });
        
        var objRight = await _objectRightService.GetObjectRight(id);
        if (objRight.Total == 0 && objRight.Data.Length == 0) return Ok(new ApiResponse<ObjectRightDto>()
        {
            Total = objRight.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object rights have been found." },
            Data = objRight.Data
        });

        var updatedObjRight = await _objectRightService.UpdateObjectRight(objectRightDto);
        if (updatedObjRight.Total == 0 && updatedObjRight.Data.Length == 0)
            return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = updatedObjRight.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during object right update." },
                Data = updatedObjRight.Data
            });

        return Ok(new ApiResponse<ObjectRightDto>()
        {
            Total = updatedObjRight.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedObjRight.Data
        });
    }
    
    [HttpDelete("data-objects/{sdOid}/rights/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object rights endpoint"})]
    public async Task<IActionResult> DeleteObjectRight(string sdOid, int id)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });
        
        var objRight = await _objectRightService.GetObjectRight(id);
        if (objRight.Total == 0 && objRight.Data.Length == 0) return Ok(new ApiResponse<ObjectRightDto>()
        {
            Total = objRight.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object rights have been found." },
            Data = objRight.Data
        });
        
        var count = await _objectRightService.DeleteObjectRight(id);
        return Ok(new ApiResponse<ObjectRightDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Object right has been removed." },
            Data = Array.Empty<ObjectRightDto>()
        });
    }

    [HttpDelete("data-objects/{sdOid}/rights")]
    [SwaggerOperation(Tags = new []{"Object rights endpoint"})]
    public async Task<IActionResult> DeleteAllObjectRights(string sdOid)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });
        
        var count = await _objectRightService.DeleteAllObjectRights(sdOid);
        return Ok(new ApiResponse<ObjectRightDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All object rights have been removed." },
            Data = Array.Empty<ObjectRightDto>()
        });
    }
    
}