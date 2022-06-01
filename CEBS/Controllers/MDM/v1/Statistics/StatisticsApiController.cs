using CEBS.Contracts.Responses;
using CEBS.Interfaces.MDM.Services.Object;
using CEBS.Interfaces.MDM.Services.Study;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.MDM.v1.Statistics
{
    public class StatisticsApiController : BaseMdmApiController
    {
        private readonly IDataObjectService _objectService;
        private readonly IStudyService _studyService;

        public StatisticsApiController(
            IDataObjectService objectService,
            IStudyService studyService)
        {
            _objectService = objectService ?? throw new ArgumentNullException(nameof(objectService));
            _studyService = studyService ?? throw new ArgumentNullException(nameof(studyService));
        }

        [HttpGet("statistics/studies/statistics")]
        [SwaggerOperation(Tags = new []{"Statistics"})]
        public async Task<IActionResult> GetTotalStudies()
        {
            return Ok(new ApiResponse<int>()
            {
                Total = await _studyService.GetTotalStudies()
            });    
        }

        [HttpGet("statistics/data-objects/statistics")]
        [SwaggerOperation(Tags = new []{"Statistics"})]
        public async Task<IActionResult> GetTotalDataObjects()
        {
            return Ok(new ApiResponse<int>()
            {
                Total = await _objectService.GetTotalDataObjects()
            });    
        }
    }
}