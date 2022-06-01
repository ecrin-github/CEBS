using CEBS.Configs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CEBS.Controllers.RMS.v1;

[Authorize]
[Route($"{ApiConfigs.RmsApiConfigs.ApiUrl}/{ApiConfigs.RmsApiConfigs.ApiVersion}")]
public class BaseRmsApiController : BaseApiController
{
        
}