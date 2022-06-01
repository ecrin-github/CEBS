using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authentication;

namespace CEBS.Controllers.MDM.v1.Object;

public class ObjectDescriptionsApiController : BaseMdmApiController
{
    private readonly IDataObjectService _dataObjectService;
    private readonly IObjectDescriptionService _objectDescriptionService;

    public ObjectDescriptionsApiController(IDataObjectService dataObjectService, IObjectDescriptionService objectDescriptionService)
    {
        _dataObjectService = dataObjectService ?? throw new ArgumentNullException(nameof(dataObjectService));
        _objectDescriptionService = objectDescriptionService ?? throw new ArgumentNullException(nameof(objectDescriptionService));
    }
    
    [HttpGet("data-objects/{sdOid}/descriptions")]
    [SwaggerOperation(Tags = new []{"Object descriptions endpoint"})]
    public async Task<IActionResult> GetObjectDescriptions(string sdOid)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objDescriptions = await _objectDescriptionService.GetObjectDescriptions(sdOid);
        if (objDescriptions.Total == 0 && objDescriptions.Data.Length == 0)
            return Ok(new ApiResponse<ObjectDescriptionDto>()
            {
                Total = objDescriptions.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No data object descriptions have been found." },
                Data = objDescriptions.Data
            });
        
        return Ok(new ApiResponse<ObjectDescriptionDto>()
        {
            Total = objDescriptions.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objDescriptions.Data
        });
    }
    
    [HttpGet("data-objects/{sdOid}/descriptions/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object descriptions endpoint"})]
    public async Task<IActionResult> GetObjectDescription(string sdOid, int id)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objDesc = await _objectDescriptionService.GetObjectDescription(id);
        if (objDesc.Total == 0 && objDesc.Data.Length == 0) return Ok(new ApiResponse<ObjectDescriptionDto>()
        {
            Total = objDesc.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object descriptions have been found." },
            Data = objDesc.Data
        });

        return Ok(new ApiResponse<ObjectDescriptionDto>()
        {
            Total = objDesc.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objDesc.Data
        });
    }

    [HttpPost("data-objects/{sdOid}/descriptions")]
    [SwaggerOperation(Tags = new []{"Object descriptions endpoint"})]
    public async Task<IActionResult> CreateObjectDescription(string sdOid,
        [FromBody] ObjectDescriptionDto objectDescriptionDto)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });
        
        objectDescriptionDto.SdOid ??= sdOid;
        var objDesc = await _objectDescriptionService.CreateObjectDescription(objectDescriptionDto);
        if (objDesc.Total == 0 && objDesc.Data.Length == 0) return Ok(new ApiResponse<ObjectDescriptionDto>()
        {
            Total = objDesc.Total,
            StatusCode = BadRequest().StatusCode,
            Messages = new [] { "Error during object description creation." },
            Data = objDesc.Data
        });

        return Ok(new ApiResponse<ObjectDescriptionDto>()
        {
            Total = objDesc.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objDesc.Data
        });
    }

    [HttpPut("data-objects/{sdOid}/descriptions/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object descriptions endpoint"})]
    public async Task<IActionResult> UpdateObjectDescription(string sdOid, int id, [FromBody] ObjectDescriptionDto objectDescriptionDto)
    {
        objectDescriptionDto.Id ??= id;
        objectDescriptionDto.SdOid ??= sdOid;
        
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });
        
        var objDesc = await _objectDescriptionService.GetObjectDescription(id);
        if (objDesc.Total == 0 && objDesc.Data.Length == 0) return Ok(new ApiResponse<ObjectDescriptionDto>()
        {
            Total = objDesc.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object descriptions have been found." },
            Data = objDesc.Data
        });
        
        var updatedObjDesc = await _objectDescriptionService.UpdateObjectDescription(objectDescriptionDto);
        if (updatedObjDesc.Total == 0 && updatedObjDesc.Data.Length == 0) return Ok(new ApiResponse<ObjectDescriptionDto>()
        {
            Total = updatedObjDesc.Total,
            StatusCode = BadRequest().StatusCode,
            Messages = new [] { "Error during data object description update." },
            Data = updatedObjDesc.Data
        });

        return Ok(new ApiResponse<ObjectDescriptionDto>()
        {
            Total = updatedObjDesc.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedObjDesc.Data
        });
    }
    
    [HttpDelete("data-objects/{sdOid}/descriptions/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object descriptions endpoint"})]
    public async Task<IActionResult> DeleteObjectDescription(string sdOid, int id)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });
        
        var objDesc = await _objectDescriptionService.GetObjectDescription(id);
        if (objDesc.Total == 0 && objDesc.Data.Length == 0) return Ok(new ApiResponse<ObjectDescriptionDto>()
        {
            Total = objDesc.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object descriptions have been found." },
            Data = objDesc.Data
        });
        
        var count = await _objectDescriptionService.DeleteObjectDescription(id);
        return Ok(new ApiResponse<ObjectDescriptionDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Object description has been removed." },
            Data = Array.Empty<ObjectDescriptionDto>()
        });
    }

    [HttpDelete("data-objects/{sdOid}/descriptions")]
    [SwaggerOperation(Tags = new []{"Object descriptions endpoint"})]
    public async Task<IActionResult> DeleteAllObjectDescriptions(string sdOid)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });
        
        var count = await _objectDescriptionService.DeleteAllObjectDescriptions(sdOid);
        return Ok(new ApiResponse<ObjectDescriptionDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All object descriptions have been removed." },
            Data = Array.Empty<ObjectDescriptionDto>()
        });
    }
}