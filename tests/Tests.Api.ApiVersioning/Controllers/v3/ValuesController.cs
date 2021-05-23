using Kitpymes.Core.Shared.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Api.ApiVersioning.Controllers.v3
{
    public class ValuesController : ApiControllerBase
    {
        [HttpGet]
        public IResult Get() => Result<ApiVersion>.Ok(HttpContext.GetRequestedApiVersion());
    }
}
