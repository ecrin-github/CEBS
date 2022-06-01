using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CEBS.Controllers.RMS.v1;

[ApiController]
[Authorize]
public class BaseRmsApiController : ControllerBase
{
        
}