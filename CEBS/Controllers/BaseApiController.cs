using CEBS.Configs;
using Microsoft.AspNetCore.Mvc;

namespace CEBS.Controllers;

[ApiController]
[Route($"{ApiConfigs.RootApiUrl}/{ApiConfigs.RootApiVersion}")]
public class BaseApiController : ControllerBase
{
    
}