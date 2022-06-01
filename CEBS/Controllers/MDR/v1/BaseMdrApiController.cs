using CEBS.Configs;
using Microsoft.AspNetCore.Mvc;

namespace CEBS.Controllers.MDR.v1;

[Route($"{ApiConfigs.MdrApiConfigs.ApiUrl}/{ApiConfigs.MdrApiConfigs.ApiVersion}")]
public class BaseMdrApiController : BaseApiController
{
        
}