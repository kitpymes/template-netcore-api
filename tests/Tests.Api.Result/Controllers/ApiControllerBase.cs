namespace Tests.Api.Result.Controllers
{
    using Kitpymes.Core.Api;
    using Kitpymes.Core.Shared.Util;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public abstract class ApiControllerBase<TController> : ControllerBase
    {
        protected static AspNetResult ApiResult(IResult result) => new (result);
    }
}
