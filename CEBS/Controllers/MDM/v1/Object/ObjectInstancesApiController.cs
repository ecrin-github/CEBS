using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Object;

public class ObjectInstancesApiController : BaseMdmApiController
{
    
    private readonly IDataObjectService _dataObjectService;
    private readonly IObjectInstanceService _objectInstanceService;

    public ObjectInstancesApiController(IDataObjectService objectService, IObjectInstanceService objectInstanceService)
    {
        _dataObjectService = objectService ?? throw new ArgumentNullException(nameof(objectService));
        _objectInstanceService = objectInstanceService ?? throw new ArgumentNullException(nameof(objectInstanceService));
    }
    
    
    [HttpGet("data-objects/{sdOid}/instances")]
    [SwaggerOperation(Tags = new []{"Object instances endpoint"})]
    public async Task<IActionResult> GetObjectInstances(string sdOid)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objInstances = await _objectInstanceService.GetObjectInstances(sdOid);
        if (objInstances.Total == 0 && objInstances.Data.Length == 0)
            return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = objInstances.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No data object instances have been found." },
                Data = objInstances.Data
            });

        return Ok(new ApiResponse<ObjectInstanceDto>()
        {
            Total = objInstances.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objInstances.Data
        });
    }
    
    [HttpGet("data-objects/{sdOid}/instances/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object instances endpoint"})]
    public async Task<IActionResult> GetObjectInstance(string sdOid, int id)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objInstance = await _objectInstanceService.GetObjectInstance(id);
        if (objInstance.Total == 0 && objInstance.Data.Length == 0) return Ok(new ApiResponse<ObjectInstanceDto>()
        {
            Total = objInstance.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object instances have been found." },
            Data = objInstance.Data
        });

        return Ok(new ApiResponse<ObjectInstanceDto>()
        {
            Total = objInstance.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objInstance.Data
        });
    }

    [HttpPost("data-objects/{sdOid}/instances")]
    [SwaggerOperation(Tags = new []{"Object instances endpoint"})]
    public async Task<IActionResult> CreateObjectInstance(string sdOid,
        [FromBody] ObjectInstanceDto objectInstanceDto)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });
        
        objectInstanceDto.SdOid ??= sdOid;
        var objInstance = await _objectInstanceService.CreateObjectInstance(objectInstanceDto);
        if (objInstance.Total == 0 && objInstance.Data.Length == 0) return Ok(new ApiResponse<ObjectInstanceDto>()
        {
            Total = objInstance.Total,
            StatusCode = BadRequest().StatusCode,
            Messages = new [] { "Error during object instance creation." },
            Data = objInstance.Data
        });

        return Ok(new ApiResponse<ObjectInstanceDto>()
        {
            Total = objInstance.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objInstance.Data
        });
    }

    [HttpPut("data-objects/{sdOid}/instances/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object instances endpoint"})]
    public async Task<IActionResult> UpdateObjectInstance(string sdOid, int id, [FromBody] ObjectInstanceDto objectInstanceDto)
    {
        objectInstanceDto.Id ??= id;
        objectInstanceDto.SdOid ??= sdOid;
        
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });
        
        var objInstance = await _objectInstanceService.GetObjectInstance(id);
        if (objInstance.Total == 0 && objInstance.Data.Length == 0) return Ok(new ApiResponse<ObjectInstanceDto>()
        {
            Total = objInstance.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object instances have been found." },
            Data = objInstance.Data
        });
        
        var updatedObjInst = await _objectInstanceService.UpdateObjectInstance(objectInstanceDto);
        if (updatedObjInst.Total == 0 && updatedObjInst.Data.Length == 0)
            return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = updatedObjInst.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during object instance update." },
                Data = updatedObjInst.Data
            });

        return Ok(new ApiResponse<ObjectInstanceDto>()
        {
            Total = updatedObjInst.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedObjInst.Data
        });
    }
    
    [HttpDelete("data-objects/{sdOid}/instances/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object instances endpoint"})]
    public async Task<IActionResult> DeleteObjectInstance(string sdOid, int id)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });
        
        var objInstance = await _objectInstanceService.GetObjectInstance(id);
        if (objInstance.Total == 0 && objInstance.Data.Length == 0) return Ok(new ApiResponse<ObjectInstanceDto>()
        {
            Total = objInstance.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object instances have been found." },
            Data = objInstance.Data
        });
        
        var count = await _objectInstanceService.DeleteObjectInstance(id);
        return Ok(new ApiResponse<ObjectInstanceDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Object instance has been removed." },
            Data = Array.Empty<ObjectInstanceDto>()
        });
    }

    [HttpDelete("data-objects/{sdOid}/instances")]
    [SwaggerOperation(Tags = new []{"Object instances endpoint"})]
    public async Task<IActionResult> DeleteAllObjectInstances(string sdOid)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });
        
        var count = await _objectInstanceService.DeleteAllObjectInstances(sdOid);
        return Ok(new ApiResponse<ObjectInstanceDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All object instances have been removed." },
            Data = Array.Empty<ObjectInstanceDto>()
        });
    }
    
}