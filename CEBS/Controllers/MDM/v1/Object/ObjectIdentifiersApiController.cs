using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Object;

public class ObjectIdentifiersApiController : BaseMdmApiController
{
    
    private readonly IDataObjectService _dataObjectService;
    private readonly IObjectIdentifierService _objectIdentifierService;

    public ObjectIdentifiersApiController(IDataObjectService objectService, IObjectIdentifierService objectIdentifierService)
    {
        _dataObjectService = objectService ?? throw new ArgumentNullException(nameof(objectService));
        _objectIdentifierService = objectIdentifierService ?? throw new ArgumentNullException(nameof(objectIdentifierService));
    }
    
    
    [HttpGet("data-objects/{sdOid}/identifiers")]
    [SwaggerOperation(Tags = new []{"Object identifiers endpoint"})]
    public async Task<IActionResult> GetObjectIdentifiers(string sdOid)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objIdentifiers = await _objectIdentifierService.GetObjectIdentifiers(sdOid);
        if (objIdentifiers.Total == 0 && objIdentifiers.Data.Length == 0)
            return Ok(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = objIdentifiers.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No data object identifiers have been found." },
                Data = objIdentifiers.Data
            });
        
        return Ok(new ApiResponse<ObjectIdentifierDto>()
        {
            Total = objIdentifiers.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objIdentifiers.Data
        });
    }
    
    [HttpGet("data-objects/{sdOid}/identifiers/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object identifiers endpoint"})]
    public async Task<IActionResult> GetObjectIdentifier(string sdOid, int id)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objIdentifier = await _objectIdentifierService.GetObjectIdentifier(id);
        if (objIdentifier.Total == 0 && objIdentifier.Data.Length == 0) return Ok(new ApiResponse<ObjectIdentifierDto>()
        {
            Total = objIdentifier.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object identifiers have been found." },
            Data = objIdentifier.Data
        });

        return Ok(new ApiResponse<ObjectIdentifierDto>()
        {
            Total = objIdentifier.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objIdentifier.Data
        });
    }

    [HttpPost("data-objects/{sdOid}/identifiers")]
    [SwaggerOperation(Tags = new []{"Object identifiers endpoint"})]
    public async Task<IActionResult> CreateObjectIdentifier(string sdOid,
        [FromBody] ObjectIdentifierDto objectIdentifierDto)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        objectIdentifierDto.SdOid ??= sdOid;
        var objIdent = await _objectIdentifierService.CreateObjectIdentifier(objectIdentifierDto);
        if (objIdent.Total == 0 && objIdent.Data.Length == 0) return Ok(new ApiResponse<ObjectIdentifierDto>()
        {
            Total = objIdent.Total,
            StatusCode = BadRequest().StatusCode,
            Messages = new [] { "Error during object identifier creation." },
            Data = objIdent.Data
        });

        return Ok(new ApiResponse<ObjectIdentifierDto>()
        {
            Total = objIdent.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objIdent.Data
        });
    }

    [HttpPut("data-objects/{sdOid}/identifiers/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object identifiers endpoint"})]
    public async Task<IActionResult> UpdateObjectIdentifier(string sdOid, int id, [FromBody] ObjectIdentifierDto objectIdentifierDto)
    {
        objectIdentifierDto.Id ??= id;
        objectIdentifierDto.SdOid ??= sdOid;
        
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objIdentifier = await _objectIdentifierService.GetObjectIdentifier(id);
        if (objIdentifier.Total == 0 && objIdentifier.Data.Length == 0) return Ok(new ApiResponse<ObjectIdentifierDto>()
        {
            Total = objIdentifier.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object identifiers have been found." },
            Data = objIdentifier.Data
        });

        var updatedObjectIdentifier = await _objectIdentifierService.UpdateObjectIdentifier(objectIdentifierDto);
        if (updatedObjectIdentifier.Total == 0 && updatedObjectIdentifier.Data.Length == 0)
            return Ok(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = updatedObjectIdentifier.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during object identifier update." },
                Data = updatedObjectIdentifier.Data
            });

        return Ok(new ApiResponse<ObjectIdentifierDto>()
        {
            Total = updatedObjectIdentifier.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedObjectIdentifier.Data
        });
    }
    
    [HttpDelete("data-objects/{sdOid}/identifiers/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object identifiers endpoint"})]
    public async Task<IActionResult> DeleteObjectIdentifier(string sdOid, int id)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objIdentifier = await _objectIdentifierService.GetObjectIdentifier(id);
        if (objIdentifier.Total == 0 && objIdentifier.Data.Length == 0) return Ok(new ApiResponse<ObjectIdentifierDto>()
        {
            Total = objIdentifier.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object identifiers have been found." },
            Data = objIdentifier.Data
        });
        
        var count = await _objectIdentifierService.DeleteObjectIdentifier(id);
        return Ok(new ApiResponse<ObjectIdentifierDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Object identifier has been removed." },
            Data = Array.Empty<ObjectIdentifierDto>()
        });
    }

    [HttpDelete("data-object/{sdOid}/identifiers")]
    [SwaggerOperation(Tags = new []{"Object identifiers endpoint"})]
    public async Task<IActionResult> DeleteAllObjectIdentifiers(string sdOid)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var count = await _objectIdentifierService.DeleteAllObjectIdentifiers(sdOid);
        return Ok(new ApiResponse<ObjectIdentifierDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All object identifiers have been removed." },
            Data = Array.Empty<ObjectIdentifierDto>()
        });
    }
    
}