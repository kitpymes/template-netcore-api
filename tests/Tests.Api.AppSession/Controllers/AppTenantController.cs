using Kitpymes.Core.Shared.Util;
using Kitpymes.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Api.AppSession.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppTenantController : ControllerBase
    {
        [HttpGet]
        public IResult Get() 
        => Result<TenantSession>.Ok(Kitpymes.Core.Entities.AppSession.Tenant);
    }
}
