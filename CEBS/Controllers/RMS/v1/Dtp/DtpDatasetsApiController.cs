using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.RMS.DTO.v1;
using CEBS.Interfaces.RMS.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.RMS.v1.Dtp;

public class DtpDatasetsApiController : BaseRmsApiController
{
    private readonly IDtpService _dtpService;

    public DtpDatasetsApiController(IDtpService dtpService)
    {
        _dtpService = dtpService ?? throw new ArgumentNullException(nameof(dtpService));
    }


    [HttpGet("data-transfers/datasets")]
    [SwaggerOperation(Tags = new[] { "Data transfer process datasets endpoint" })]
    public async Task<IActionResult> GetDtpDatasetList()
    {
        var dataset = await _dtpService.GetAllDtpDatasets();
        if (dataset.Total == 0 && dataset.Data.Length == 0)
            return Ok(new ApiResponse<DtpDatasetDto>()
            {
                Total = dataset.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP datasets have been found." },
                Data = dataset.Data
            });
        return Ok(new ApiResponse<DtpDatasetDto>()
        {
            Total = dataset.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dataset.Data
        });
    }

    [HttpGet("data-transfers/datasets/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Data transfer process datasets endpoint" })]
    public async Task<IActionResult> GetDtpDataset(int id)
    {
        var dtpDataset = await _dtpService.GetDtpDataset(id);
        if (dtpDataset.Total == 0 && dtpDataset.Data.Length == 0)
            return Ok(new ApiResponse<DtpDatasetDto>()
            {
                Total = dtpDataset.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP datasets have been found." },
                Data = dtpDataset.Data
            });
        return Ok(new ApiResponse<DtpDatasetDto>()
        {
            Total = dtpDataset.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dtpDataset.Data
        });
    }

    [HttpPost("data-transfers/datasets/{objectId}")]
    [SwaggerOperation(Tags = new[] { "Data transfer process datasets endpoint" })]
    public async Task<IActionResult> CreateDta(string objectId, [FromBody] DtpDatasetDto dtpDatasetDto)
    {
        var dataset = await _dtpService.CreateDtpDataset(objectId, dtpDatasetDto);
        if (dataset.Total == 0 && dataset.Data.Length == 0)
            return Ok(new ApiResponse<DtpDatasetDto>()
            {
                Total = dataset.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during DTP dataset creation." },
                Data = dataset.Data
            });
        return Ok(new ApiResponse<DtpDatasetDto>()
        {
            Total = dataset.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = dataset.Data
        });
    }

    [HttpPut("data-transfers/datasets/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Data transfer process datasets endpoint" })]
    public async Task<IActionResult> UpdateDtpDataset(int id, [FromBody] DtpDatasetDto dtpDatasetDto)
    {
        var dtpDataset = await _dtpService.GetDtpDataset(id);
        if (dtpDataset.Total == 0 && dtpDataset.Data.Length == 0)
            return Ok(new ApiResponse<DtpDatasetDto>()
            {
                Total = dtpDataset.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP datasets have been found." },
                Data = dtpDataset.Data
            });

        var updatedDataset = await _dtpService.UpdateDtpDataset(dtpDatasetDto);
        if (updatedDataset.Total == 0 && updatedDataset.Data.Length == 0)
            return Ok(new ApiResponse<DtpDatasetDto>()
            {
                Total = updatedDataset.Total,
                StatusCode = BadRequest().StatusCode,
                Messages = new [] { "Error during DTP dataset update." },
                Data = updatedDataset.Data
            });
        return Ok(new ApiResponse<DtpDatasetDto>()
        {
            Total = updatedDataset.Total,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>(),
            Data = updatedDataset.Data
        });
    }

    [HttpDelete("data-transfers/datasets/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Data transfer process datasets endpoint" })]
    public async Task<IActionResult> DeleteDtpDataset(int id)
    {
        var dtpDataset = await _dtpService.GetDtpDataset(id);
        if (dtpDataset.Total == 0 && dtpDataset.Data.Length == 0)
            return Ok(new ApiResponse<DtpDatasetDto>()
            {
                Total = dtpDataset.Total,
                StatusCode = NotFound().StatusCode,
                Messages = new [] { "No DTP datasets have been found." },
                Data = dtpDataset.Data
            });

        var count = await _dtpService.DeleteDtpDataset(id);
        return Ok(new ApiResponse<DtpDatasetDto>()
        {
            Total = count,
            StatusCode = Ok().StatusCode,
            Messages = new [] { "DTP dataset has been removed." },
            Data = Array.Empty<DtpDatasetDto>()
        });
    }
}