using Microsoft.AspNetCore.Mvc;

namespace Tests.Api.ApiVersioning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        
    }
}
