using CEBS.Configs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CEBS.Controllers.MDM.v1;

[Authorize]
[Route($"{ApiConfigs.MdmApiConfigs.ApiUrl}/{ApiConfigs.MdmApiConfigs.ApiVersion}")]
public class BaseMdmApiController : BaseApiController
{
        
}