using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CEBS.Controllers.User.v1;

[ApiController]
[Authorize]
public class BaseApiController : ControllerBase
{
        
}