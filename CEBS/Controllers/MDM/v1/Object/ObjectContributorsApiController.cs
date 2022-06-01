using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Object;

public class ObjectContributorsApiController : BaseMdmApiController
{
    
    private readonly IDataObjectService _dataObjectService;
    private readonly IObjectContributorService _objectContributorService;

    public ObjectContributorsApiController(
        IDataObjectService dataObjectService, 
        IObjectContributorService objectContributorService
    )
    {
        _dataObjectService = dataObjectService ?? throw new ArgumentNullException(nameof(dataObjectService));
        _objectContributorService = objectContributorService ??
                                    throw new ArgumentNullException(nameof(objectContributorService));
    }


    [HttpGet("data-objects/{sdOid}/contributors")]
    [SwaggerOperation(Tags = new []{"Object contributors endpoint"})]
    public async Task<IActionResult> GetObjectContributors(string sdOid)
    {
        var dataObject = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object has been found." },
            Data = dataObject.Data
        });

        var objectContributors = await _objectContributorService.GetObjectContributors(sdOid);
        if (objectContributors.Total == 0 && objectContributors.Data.Length == 0) return Ok(new ApiResponse<ObjectContributorDto>()
        {
            Total = objectContributors.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object contributors have been found." },
            Data = objectContributors.Data
        });
        
        return Ok(new ApiResponse<ObjectContributorDto>()
        {
            Total = objectContributors.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objectContributors.Data
        });
    }
    
    [HttpGet("data-objects/{sdOid}/contributors/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object contributors endpoint"})]
    public async Task<IActionResult> GetObjectContributor(string sdOid, int id)
    {
        var dataObject = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object has been found." },
            Data = dataObject.Data
        });

        var objContrib = await _objectContributorService.GetObjectContributor(id);
        if (objContrib.Total == 0 && objContrib.Data.Length == 0) return Ok(new ApiResponse<ObjectContributorDto>()
        {
            Total = objContrib.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object contributor has been found." },
            Data = objContrib.Data
        });

        return Ok(new ApiResponse<ObjectContributorDto>()
        {
            Total = objContrib.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objContrib.Data
        });
    }

    [HttpPost("data-objects/{sdOid}/contributors")]
    [SwaggerOperation(Tags = new []{"Object contributors endpoint"})]
    public async Task<IActionResult> CreateObjectContributor(string sdOid,
        [FromBody] ObjectContributorDto objectContributorDto)
    {
        var dataObject = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object has been found." },
            Data = dataObject.Data
        });
        
        objectContributorDto.SdOid ??= sdOid;
        var objContrib = await _objectContributorService.CreateObjectContributor(objectContributorDto);
        if (objContrib.Total == 0 && objContrib.Data.Length == 0)
            return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = objContrib.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during data object contributor creation." },
                Data = objContrib.Data
            });

        return Ok(new ApiResponse<ObjectContributorDto>()
        {
            Total = objContrib.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objContrib.Data
        });
    }

    [HttpPut("data-objects/{sdOid}/contributors/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object contributors endpoint"})]
    public async Task<IActionResult> UpdateObjectContributor(string sdOid, int id, [FromBody] ObjectContributorDto objectContributorDto)
    {
        objectContributorDto.Id ??= id;
        objectContributorDto.SdOid ??= sdOid;
        
        var dataObject = await _dataObjectService.GetObjectBySdOid(objectContributorDto.SdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object has been found." },
            Data = dataObject.Data
        });

        var objectContrib = await _objectContributorService.GetObjectContributor(objectContributorDto.Id);
        if (objectContrib.Total == 0 && objectContrib.Data.Length == 0) return Ok(new ApiResponse<ObjectContributorDto>()
        {
            Total = objectContrib.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object contributor has been found." },
            Data = objectContrib.Data
        });
        
        var updatedObjContrib = await _objectContributorService.UpdateObjectContributor(objectContributorDto);
        if (updatedObjContrib.Total == 0 && updatedObjContrib.Data.Length == 0)
            return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = updatedObjContrib.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] {"Error during data object contributor update."},
                Data = updatedObjContrib.Data
            });

        return Ok(new ApiResponse<ObjectContributorDto>()
        {
            Total = updatedObjContrib.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedObjContrib.Data
        });
    }
    
    [HttpDelete("data-objects/{sdOid}/contributors/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object contributors endpoint"})]
    public async Task<IActionResult> DeleteObjectContributor(string sdOid, int id)
    {
        var dataObject = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object has been found." },
            Data = dataObject.Data
        });

        var objectContrib = await _objectContributorService.GetObjectContributor(id);
        if (objectContrib.Total == 0 && objectContrib.Data.Length == 0) return Ok(new ApiResponse<ObjectContributorDto>()
        {
            Total = objectContrib.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object contributors have been found." },
            Data = objectContrib.Data
        });
        
        var count = await _objectContributorService.DeleteObjectContributor(id);
        return Ok(new ApiResponse<ObjectContributorDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Object contributor has been removed." },
            Data = Array.Empty<ObjectContributorDto>()
        });
    }

    [HttpDelete("data-objects/{sdOid}/contributors")]
    [SwaggerOperation(Tags = new []{"Object contributors endpoint"})]
    public async Task<IActionResult> DeleteAllObjectContributors(string sdOid)
    {
        var dataObject = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object has been found." },
            Data = dataObject.Data
        });
        
        var count = await _objectContributorService.DeleteAllObjectContributors(sdOid);
        return Ok(new ApiResponse<ObjectContributorDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All object contributors have been removed." },
            Data = Array.Empty<ObjectContributorDto>()
        });
    }
}