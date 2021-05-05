// -----------------------------------------------------------------------
// <copyright file="AspNetResult.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System.Net;
    using System.Threading.Tasks;
    using Kitpymes.Core.Shared;
    using Microsoft.AspNetCore.Mvc;

    /*
      Clase de resultados AspNetResult
      Contiene los métodos que devuelven los resultados
   */

    /// <summary>
    /// Clase de resultados <c>AspNetResult</c>.
    /// Contiene los métodos que devuelven los resultados.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todos los métodos que devuelven resultados.</para>
    /// </remarks>
    public class AspNetResult : IActionResult
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AspNetResult"/>.
        /// </summary>
        /// <param name="result">Resultado.</param>
        public AspNetResult(Shared.Util.IResult result) => Result = result;

        private Shared.Util.IResult Result { get; }

        /// <inheritdoc/>
        public async Task ExecuteResultAsync(ActionContext context)
        {
            if (context != null)
            {
                await context.HttpContext.Response.ToResultAsync(
                    status: Result.StatusCode!.Value.ToEnum<HttpStatusCode>(),
                    message: Result.ToJson())
                .ConfigureAwait(false);
            }
        }
    }
}
