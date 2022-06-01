using CEBS.Configs;
using Microsoft.AspNetCore.Mvc;

namespace CEBS.Controllers.Context.v1;

[Route($"{ApiConfigs.ContextApiConfigs.ApiUrl}/{ApiConfigs.ContextApiConfigs.ApiVersion}")]
public class BaseContextApiController : BaseApiController
{
        
}