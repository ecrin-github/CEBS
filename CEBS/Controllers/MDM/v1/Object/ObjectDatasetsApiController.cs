using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Object;

public class ObjectDatasetsApiController : BaseMdmApiController
{
    
    private readonly IDataObjectService _dataObjectService;
    private readonly IObjectDatasetService _objectDatasetService;

    public ObjectDatasetsApiController(
        IDataObjectService objectService,
        IObjectDatasetService objectDatasetService
    )
    {
        _dataObjectService = objectService ?? throw new ArgumentNullException(nameof(objectService));
        _objectDatasetService = objectDatasetService ?? throw new ArgumentNullException(nameof(objectDatasetService));
    }
    
    
    [HttpGet("data-objects/{sdOid}/datasets")]
    [SwaggerOperation(Tags = new []{"Object datasets endpoint"})]
    public async Task<IActionResult> GetObjectDatasets(string sdOid)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objDatasets = await _objectDatasetService.GetObjectDatasets(sdOid);
        if (objDatasets.Total == 0 && objDatasets.Data.Length == 0)
            return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = objDatasets.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No data object datasets have been found." },
                Data = objDatasets.Data
            });
        
        return Ok(new ApiResponse<ObjectDatasetDto>()
        {
            Total = objDatasets.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objDatasets.Data
        });
    }
    
    
    [HttpGet("data-objects/{sdOid}/datasets/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object datasets endpoint"})]
    public async Task<IActionResult> GetObjectDatasets(string sdOid, int id)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objDataset = await _objectDatasetService.GetObjectDataset(id);
        if (objDataset.Total == 0 && objDataset.Data.Length == 0) return Ok(new ApiResponse<ObjectDatasetDto>()
        {
            Total = objDataset.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects datasets have been found." },
            Data = objDataset.Data
        });

        return Ok(new ApiResponse<ObjectDatasetDto>()
        {
            Total = objDataset.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objDataset.Data
        });
    }
    

    [HttpPost("data-objects/{sdOid}/datasets")]
    [SwaggerOperation(Tags = new []{"Object datasets endpoint"})]
    public async Task<IActionResult> CreateObjectDataset(string sdOid,
        [FromBody] ObjectDatasetDto objectDatasetDto)
    {
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });
        
        objectDatasetDto.SdOid ??= sdOid;
        var objDataset = await _objectDatasetService.CreateObjectDataset(objectDatasetDto);
        if (objDataset.Total == 0 && objDataset.Data.Length == 0)
            return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = objDataset.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during dataset creation." },
                Data = objDataset.Data
            });

        return Ok(new ApiResponse<ObjectDatasetDto>()
        {
            Total = objDataset.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = objDataset.Data
        });
    }

    [HttpPut("data-objects/{sdOid}/datasets/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object datasets endpoint"})]
    public async Task<IActionResult> UpdateObjectDataset(string sdOid, int id, [FromBody] ObjectDatasetDto objectDatasetDto)
    {
        objectDatasetDto.Id ??= id;
        objectDatasetDto.SdOid ??= sdOid;
        
        var dataObj = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObj.Data
        });

        var objDataset = await _objectDatasetService.GetObjectDataset(id);
        if (objDataset.Total == 0 && objDataset.Data.Length == 0) return Ok(new ApiResponse<ObjectDatasetDto>()
        {
            Total = objDataset.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object datasets have been found." },
            Data = objDataset.Data
        });
        
        var updatedObjDataset = await _objectDatasetService.UpdateObjectDataset(objectDatasetDto);
        if (updatedObjDataset.Total == 0 && updatedObjDataset.Data.Length == 0)
            return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = updatedObjDataset.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during dataset update." },
                Data = updatedObjDataset.Data
            });

        return Ok(new ApiResponse<ObjectDatasetDto>()
        {
            Total = updatedObjDataset.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedObjDataset.Data
        });
    }
    
    [HttpDelete("data-objects/{sdOid}/datasets/{id:int}")]
    [SwaggerOperation(Tags = new []{"Object datasets endpoint"})]
    public async Task<IActionResult> DeleteObjectDataset(string sdOid, int id)
    {
        var dataObject = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObject.Data
        });

        var objectDataset = await _objectDatasetService.GetObjectDataset(id);
        if (objectDataset.Total == 0 && objectDataset.Data.Length == 0) return Ok(new ApiResponse<ObjectDatasetDto>()
        {
            Total = objectDataset.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object datasets have been found." },
            Data = objectDataset.Data
        });
        
        var count = await _objectDatasetService.DeleteObjectDataset(id);
        return Ok(new ApiResponse<ObjectDatasetDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Object dataset has been removed." },
            Data = Array.Empty<ObjectDatasetDto>()
        });
    }

    [HttpDelete("data-objects/{sdOid}/datasets")]
    [SwaggerOperation(Tags = new []{"Object datasets endpoint"})]
    public async Task<IActionResult> DeleteAllObjectDatasets(string sdOid)
    {
        var dataObject = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data objects have been found." },
            Data = dataObject.Data
        });
        
        var count = await _objectDatasetService.DeleteAllObjectDatasets(sdOid);
        return Ok(new ApiResponse<ObjectDatasetDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "All object datasets have been removed." },
            Data = Array.Empty<ObjectDatasetDto>()
        });
    }
    
}