using CEBS.Configs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CEBS.Controllers.User.v1;

[Authorize]
[Route($"{ApiConfigs.UserApiConfigs.ApiUrl}/{ApiConfigs.UserApiConfigs.ApiVersion}")]
public class BaseUserApiController : BaseApiController
{
        
}