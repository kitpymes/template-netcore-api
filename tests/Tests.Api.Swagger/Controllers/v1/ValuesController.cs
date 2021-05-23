using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Api.Swagger.Controllers.v1
{
    /// <summary>
    /// Controlador de la V1 de la api.
    /// </summary>
    public class ValuesController : ApiControllerBase<ValuesController>
    {
        /// <summary>
        /// GET api/values
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return await Result
            (
                Ok: () => Product.List

            ).ConfigureAwait(false);
        }

        /// <summary>
        /// GET api/values/5
        /// here id is 5
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="cancellation">CancellationToken</param>
        /// <returns>IActionResult</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof((string Key, string ErrorMessage)[]), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id, CancellationToken cancellation)
        {
            cancellation.ThrowIfCancellationRequested();

            return await Result
            (
                Errors: () => new[]
                {
                    (
                        condition: id <= 0,
                        messageError: $"The product id: '{id}' cannot less or equal to 0."
                    ),

                    (
                        condition: !Product.List.Any(x => x.Id == id),
                        messageError: $"The product id: '{id}' not found."
                    )
                },

                Ok: () => Product.List.FirstOrDefault(x => x.Id == id)

            ).ConfigureAwait(false);
        }

        /// <summary>
        /// POST api/values
        /// </summary>
        /// <param name="model">[FromBody] Product </param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof((string Key, string ErrorMessage)[]), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] AddProductModel model)
        {
            return await Result
            (
                Errors: () => new[] 
                {
                    (
                        condition: string.IsNullOrWhiteSpace(model.Name), 
                        messageError: $"The product name: '{model.Name}' cannot be null or empty."
                    ),

                    (
                        condition: Product.List.Any(x => x.Name == model.Name),
                        messageError: $"The product name: '{model.Name}' it already exists."
                    )
                },

                Ok: () => 
                {
                    Product.List.Add(new Product
                    {
                        Id = Product.List.Last().Id + 1,
                        Name = model.Name,
                        CreatedDate = DateTime.Now
                    });

                    return Product.List.Last();
                }

            ).ConfigureAwait(false);
        }

        /// <summary>
        /// PUT api/values/5
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="model">[FromBody] Product</param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof((string Key, string ErrorMessage)[]), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] EditProductModel model)
        {
            return await Result
            (
                Errors: () => new[]
                {
                    (
                        condition: id <= 0 && string.IsNullOrWhiteSpace(model.Name),
                        messageError: $"Invalid id: '{id}' or name: '{model.Name}'"
                    ),

                    (
                        condition: !Product.List.Any(x => x.Id == id),
                        messageError: $"The product id: '{id}' not found."
                    )
                },

                Ok: () =>
                {
                    var edit = Product.List.FirstOrDefault(x => x.Id == id);

                    edit.Name = model.Name;

                    return true;
                }

            ).ConfigureAwait(false);
        }

        /// <summary>
        /// DELETE api/values/5
        /// </summary>
        /// <param name="id">int</param>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof((string Key, string ErrorMessage)[]), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await Result
            (
                Errors: () => new[]
                {
                    (
                        condition: id <= 0,
                        messageError: $"Invalid {nameof(id)}"
                    ),

                    (
                        condition: !Product.List.Any(x => x.Id == id),
                        messageError: $"The product id: {nameof(id)} not found."
                    )
                },

                Ok: () =>
                {
                    Product.List.RemoveAll(x => x.Id == id);

                    return true;
                }

            ).ConfigureAwait(false);
        }
    }
}
