using CEBS.Configs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CEBS.Controllers.Audit.v1;

[Authorize]
[Route($"{ApiConfigs.AuditApiConfigs.ApiUrl}/{ApiConfigs.AuditApiConfigs.ApiVersion}")]
public class BaseAuditController : BaseApiController
{
    
}