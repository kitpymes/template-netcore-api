using Kitpymes.Core.Shared.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Api.Controllers.v3
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IResult Get() => Result<ApiVersion>.Ok(HttpContext.GetRequestedApiVersion());
    }
}
