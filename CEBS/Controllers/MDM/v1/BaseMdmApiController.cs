using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CEBS.Controllers.MDM.v1;

[ApiController]
[Authorize]
public class BaseMdmApiController : ControllerBase
{
        
}