using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CEBS.Controllers.Audit.v1;

[ApiController]
[Authorize]
public class BaseAuditController : ControllerBase
{
    
}