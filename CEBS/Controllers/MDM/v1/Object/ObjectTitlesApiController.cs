using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Object;

public class ObjectTitlesApiController : BaseMdmApiController
{
    
    private readonly IDataObjectService _dataObjectService;
    private readonly IObjectTitleService _objectTitleService;

    public ObjectTitlesApiController(IDataObjectService dataObjectService, IObjectTitleService objectTitleService)
    {
        _dataObjectService = dataObjectService ?? throw new ArgumentNullException(nameof(dataObjectService));
        _objectTitleService = objectTitleService ?? throw new ArgumentNullException(nameof(objectTitleService));
    }
    
    
    [HttpGet("data-objects/{sdOid}/titles")]
    [SwaggerOperation(Tags = new []{"Object titles endpoint"})]
    public async Task<IActionResult> GetObjectTitles(string sdOid)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objTitles = await _objectTitleService.GetObjectTitles(sdOid);
        if (objTitles.Total == 0 && objTitles.Data.Length == 0)
            return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = objTitles.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No data object titles have been found." },
                Data = objTitles.Data
            });
        
        return Ok(new ApiResponse<ObjectTitleDto>()
        {
            Total = objTitles.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objTitles.Data
        });
    }
    
    [HttpGet("data-objects/{sdOid}/titles/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object titles endpoint"})]
    public async Task<IActionResult> GetObjectTitle(string sdOid, int id)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objTitle = await _objectTitleService.GetObjectTitle(id);
        if (objTitle.Total == 0 && objTitle.Data.Length == 0) return Ok(new ApiResponse<ObjectTitleDto>()
        {
            Total = objTitle.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object titles have been found." },
            Data = objTitle.Data
        });

        return Ok(new ApiResponse<ObjectTitleDto>()
        {
            Total = objTitle.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objTitle.Data
        });
    }

    [HttpPost("data-objects/{sdOid}/titles")]
    [SwaggerOperation(Tags = new []{"Object titles endpoint"})]
    public async Task<IActionResult> CreateObjectTitle(string sdOid,
        [FromBody] ObjectTitleDto objectTitleDto)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        objectTitleDto.SdOid ??= sdOid;
        var objTitle = await _objectTitleService.CreateObjectTitle(objectTitleDto);
        if (objTitle.Total == 0 && objTitle.Data.Length == 0)
            return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = objTitle.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during object title creation." },
                Data = objTitle.Data
            });

        return Ok(new ApiResponse<ObjectTitleDto>()
        {
            Total = objTitle.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objTitle.Data
        });
    }

    [HttpPut("data-objects/{sdOid}/titles/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object titles endpoint"})]
    public async Task<IActionResult> UpdateObjectTitle(string sdOid, int id, [FromBody] ObjectTitleDto objectTitleDto)
    {
        objectTitleDto.Id ??= id;
        objectTitleDto.SdOid ??= sdOid;
        
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objTitle = await _objectTitleService.GetObjectTitle(id);
        if (objTitle.Total == 0 && objTitle.Data.Length == 0) return Ok(new ApiResponse<ObjectTitleDto>()
        {
            Total = objTitle.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object titles have been found." },
            Data = objTitle.Data
        });

        var updatedObjectTitle = await _objectTitleService.UpdateObjectTitle(objectTitleDto);
        if (updatedObjectTitle.Total == 0 && updatedObjectTitle.Data.Length == 0)
            return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = updatedObjectTitle.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during object title update." },
                Data = updatedObjectTitle.Data
            });

        return Ok(new ApiResponse<ObjectTitleDto>()
        {
            Total = updatedObjectTitle.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedObjectTitle.Data
        });
    }
    
    [HttpDelete("data-objects/{sdOid}/titles/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object titles endpoint"})]
    public async Task<IActionResult> DeleteObjectTitle(string sdOid, int id)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objTitle = await _objectTitleService.GetObjectTitle(id);
        if (objTitle.Total == 0 && objTitle.Data.Length == 0) return Ok(new ApiResponse<ObjectTitleDto>()
        {
            Total = objTitle.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object titles have been found." },
            Data = objTitle.Data
        });
        
        var count = await _objectTitleService.DeleteObjectTitle(id);
        return Ok(new ApiResponse<ObjectTitleDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Object title has been removed." },
            Data = Array.Empty<ObjectTitleDto>()
        });
    }

    [HttpDelete("data-objects/{sdOid}/titles")]
    [SwaggerOperation(Tags = new []{"Object titles endpoint"})]
    public async Task<IActionResult> DeleteAllObjectTitles(string sdOid)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });
        
        var count = await _objectTitleService.DeleteAllObjectTitles(sdOid);
        return Ok(new ApiResponse<ObjectTitleDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All object titles have been removed." },
            Data = Array.Empty<ObjectTitleDto>()
        });
    }
}