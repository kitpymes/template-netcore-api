using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.Api.Swagger.Controllers
{
    /// <summary>
    /// Constrolador de la api.
    /// </summary>
    /// <typeparam name="TController"></typeparam>
    [ApiController]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class ApiControllerBase<TController> : ControllerBase
    {
        /// <summary>
        /// Resultado de la Api.
        /// </summary>
        /// <param name="Ok"></param>
        /// <param name="Errors"></param>
        /// <returns></returns>
        protected async Task<IActionResult> Result
        (
            Func<object> Ok = null,

            Func<(bool condition, string messageError)[]> Errors = null
        )
        {
            try
            {

                if (Errors != null)
                {
                    var list = Errors().ToList().Where(x => x.condition).Select(x => x.messageError);

                    if (list.Any())
                    {
                        return BadRequest("Errors: " + string.Join(", ", list));
                    }
                }

                await Task.Delay(0);
            }
            catch (Exception)
            {
                return InternalServerError("Ocurrio un error inesperado, por favor intentelo mas tarde.");
            }

            return new OkObjectResult(Ok?.Invoke());
        }

        private ObjectResult InternalServerError(string errorMessage)
        {
            return new ObjectResult(errorMessage)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
