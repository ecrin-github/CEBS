using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Object;

public class ObjectApiController : BaseMdmApiController
{
    private readonly IDataObjectService _dataObjectService;

    public ObjectApiController(IDataObjectService dataObjectService)
    {
        _dataObjectService = dataObjectService ?? throw new ArgumentNullException(nameof(dataObjectService));
    }
    
    [HttpGet("data-objects")]
    [SwaggerOperation(Tags = new []{"Data objects endpoint"})]
    public async Task<IActionResult> GetAllDataObjects()
    {
        var dataObjects = await _dataObjectService.GetDataObjects();
        if (dataObjects.Total == 0 && dataObjects.Data.Length == 0)
            return Ok(new ApiResponse<DataObjectDto>()
            {
                Total = dataObjects.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No data objects have been found." },
                Data = dataObjects.Data
            });
        
        return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObjects.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dataObjects.Data
        });
    }
    
    [HttpGet("data-objects/{sdOid}")]
    [SwaggerOperation(Tags = new []{"Data objects endpoint"})]
    public async Task<IActionResult> GetObjectBySdOid(string sdOid)
    {
        var dataObject = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object has been found." },
            Data = dataObject.Data
        });

        return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dataObject.Data
        });
    }
    
    [HttpGet("data-objects/{id:int}")]
    [SwaggerOperation(Tags = new []{"Data objects endpoint"})]
    public async Task<IActionResult> GetObjectById(int id)
    {
        var dataObject = await _dataObjectService.GetObjectById(id);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object has been found." },
            Data = dataObject.Data
        });

        return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dataObject.Data
        });
    }

    [HttpPost("data-objects")]
    [SwaggerOperation(Tags = new []{"Data objects endpoint"})]
    public async Task<IActionResult> CreateDataObject([FromBody] DataObjectDto dataObjectDto)
    {
        var dataObj = await _dataObjectService.CreateDataObject(dataObjectDto);
        if (dataObj.Total == 0 && dataObj.Data.Length == 0)
            return Ok(new ApiResponse<DataObjectDto>()
            {
                Total = dataObj.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during data object creation." },
                Data = dataObj.Data
            });

        return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObj.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dataObj.Data
        });
    }
    
    [HttpPut("data-objects/{sdOid}")]
    [SwaggerOperation(Tags = new []{"Data objects endpoint"})]
    public async Task<IActionResult> UpdateDataObject(string sdOid, [FromBody] DataObjectDto dataObjectDto)
    {
        dataObjectDto.SdOid ??= sdOid;
        
        var dataObject = await _dataObjectService.GetObjectBySdOid(dataObjectDto.SdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object has been found." },
            Data = dataObject.Data
        });
        
        var updatedDataObj = await _dataObjectService.UpdateDataObject(dataObjectDto);
        if (updatedDataObj.Total == 0 && updatedDataObj.Data.Length == 0)
            return Ok(new ApiResponse<DataObjectDto>()
            {
                Total = updatedDataObj.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during data object update." },
                Data = updatedDataObj.Data
            });

        return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = updatedDataObj.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedDataObj.Data
        });
    }

    [HttpDelete("data-objects/{sdOid}")]
    [SwaggerOperation(Tags = new []{"Data objects endpoint"})]
    public async Task<IActionResult> DeleteDataObject(string sdOid)
    {
        var dataObject = await _dataObjectService.GetObjectBySdOid(sdOid);
        if (dataObject.Total == 0 && dataObject.Data.Length == 0) return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = dataObject.Total,
            StatusCode = NotFound().StatusCode,
            Messages = new [] { "No data object has been found." },
            Data = dataObject.Data
        });
        
        var count = await _dataObjectService.DeleteDataObject(sdOid);
        return Ok(new ApiResponse<DataObjectDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "Data object has been removed." },
            Data = Array.Empty<DataObjectDto>()
        });
    }
    }