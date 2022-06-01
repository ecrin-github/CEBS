using CEBS.Contracts.Responses;
using CEBS.Interfaces.RMS.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.RMS.v1.Statistics;

public class StatisticsApiController : BaseRmsApiController
{
    private readonly IDtpService _dtpService;
    private readonly IDupService _dupService;

    public StatisticsApiController(
        IDtpService dtpService,
        IDupService dupService)
    {
        _dtpService = dtpService ?? throw new ArgumentNullException(nameof(dtpService));
        _dupService = dupService ?? throw new ArgumentNullException(nameof(dupService));
    }

    [HttpGet("statistics/dtp/statistics")]
    [SwaggerOperation(Tags = new[] { "Statistics" })]
    public async Task<IActionResult> GetDtpStatistics()
    {
        return Ok(new ApiResponse<int>()
        {
            Total = await _dtpService.GetTotalDtp(),
        });
    }

    [HttpGet("statistics/dup/statistics")]
    [SwaggerOperation(Tags = new[] { "Statistics" })]
    public async Task<IActionResult> GetDupStatistics()
    {
        return Ok(new ApiResponse<int>()
        {
            Total = await _dupService.GetTotalDup(),
        });
    }
}