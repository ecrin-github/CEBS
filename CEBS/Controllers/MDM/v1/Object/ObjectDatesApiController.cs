using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Object;

public class ObjectDatesApiController : BaseMdmApiController
{
    private readonly IDataObjectService _dataObjectService;
    private readonly IObjectDateService _objectDateService;

    public ObjectDatesApiController(IDataObjectService objectService, IObjectDateService objectDateService)
    {
        _dataObjectService = objectService ?? throw new ArgumentNullException(nameof(objectService));
        _objectDateService = objectDateService ?? throw new ArgumentNullException(nameof(objectDateService));
    }
    
    [HttpGet("data-objects/{sdOid}/dates")]
    [SwaggerOperation(Tags = new []{"Object dates endpoint"})]
    public async Task<IActionResult> GetObjectDates(string sdOid)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objDates = await _objectDateService.GetObjectDates(sdOid);
        if (objDates.Total == 0 && objDates.Data.Length == 0)
            return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = objDates.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No data object dates have been found." },
                Data = objDates.Data
            });
        
        return Ok(new ApiResponse<ObjectDateDto>()
        {
            Total = objDates.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objDates.Data
        });
    }
    
    [HttpGet("data-objects/{sdOid}/dates/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object dates endpoint"})]
    public async Task<IActionResult> GetObjectDate(string sdOid, int id)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objDate = await _objectDateService.GetObjectDate(id);
        if (objDate.Total == 0 && objDate.Data.Length == 0) return Ok(new ApiResponse<ObjectDateDto>()
        {
            Total = objDate.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object dates have been found." },
            Data = objDate.Data
        });

        return Ok(new ApiResponse<ObjectDateDto>()
        {
            Total = objDate.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objDate.Data
        });
    }

    [HttpPost("data-objects/{sdOid}/dates")]
    [SwaggerOperation(Tags = new []{"Object dates endpoint"})]
    public async Task<IActionResult> CreateObjectDate(string sdOid,
        [FromBody] ObjectDateDto objectDateDto)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });
        
        objectDateDto.SdOid ??= sdOid;
        var objDate = await _objectDateService.CreateObjectDate(objectDateDto);
        if (objDate.Total == 0 && objDate.Data.Length == 0)
            return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = objDate.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during object date creation." },
                Data = objDate.Data
            });

        return Ok(new ApiResponse<ObjectDateDto>()
        {
            Total = objDate.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objDate.Data
        });
    }

    [HttpPut("data-objects/{sdOid}/dates/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object dates endpoint"})]
    public async Task<IActionResult> UpdateObjectDate(string sdOid, int id, [FromBody] ObjectDateDto objectDateDto)
    {
        objectDateDto.Id ??= id;
        objectDateDto.SdOid ??= sdOid;
        
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objDate = await _objectDateService.GetObjectDate(id);
        if (objDate.Total == 0 && objDate.Data.Length == 0) return Ok(new ApiResponse<ObjectDateDto>()
        {
            Total = objDate.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object dates have been found." },
            Data = objDate.Data
        });

        var updatedObjDate = await _objectDateService.UpdateObjectDate(objectDateDto);
        if (updatedObjDate.Total == 0 && updatedObjDate.Data.Length == 0)
            return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = updatedObjDate.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during object date update." },
                Data = updatedObjDate.Data
            });

        return Ok(new ApiResponse<ObjectDateDto>()
        {
            Total = updatedObjDate.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedObjDate.Data
        });
    }
    
    [HttpDelete("data-objects/{sdOid}/dates/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object dates endpoint"})]
    public async Task<IActionResult> DeleteObjectDate(string sdOid, int id)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objDate = await _objectDateService.GetObjectDate(id);
        if (objDate.Total == 0 && objDate.Data.Length == 0) return Ok(new ApiResponse<ObjectDateDto>()
        {
            Total = objDate.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object dates have been found." },
            Data = objDate.Data
        });
        
        var count = await _objectDateService.DeleteObjectDate(id);
        return Ok(new ApiResponse<ObjectDateDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Object date has been removed." },
            Data = Array.Empty<ObjectDateDto>()
        });
    }

    [HttpDelete("data-objects/{sdOid}/dates")]
    [SwaggerOperation(Tags = new []{"Object dates endpoint"})]
    public async Task<IActionResult> DeleteAllObjectDates(string sdOid)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });
        
        var count = await _objectDateService.DeleteAllObjectDates(sdOid);
        return Ok(new ApiResponse<ObjectDateDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All object dates have been removed." },
            Data = Array.Empty<ObjectDateDto>()
        });
    }
}