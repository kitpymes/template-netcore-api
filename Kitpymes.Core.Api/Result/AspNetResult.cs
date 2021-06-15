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
    using Kitpymes.Core.Shared.Util;
    using Microsoft.AspNetCore.Mvc;

    /*
        Clase para devolver resultados de los controladores AspNetResult
        Contiene los métodos para devolver valores
    */

    /// <summary>
    /// Clase para devolver resultados de los controladores <c>AspNetResult</c>.
    /// Contiene los metodos para devolver valores.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todos los métodos para devolver resultados de las api.</para>
    /// </remarks>
    public class AspNetResult : IActionResult
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AspNetResult"/>.
        /// </summary>
        /// <param name="result">Resultado.</param>
        public AspNetResult(IResult result) => Result = result;

        private IResult Result { get; }

        /// <inheritdoc/>
        public async Task ExecuteResultAsync(ActionContext context)
        {
            if (context != null)
            {
                var status = HttpStatusCode.InternalServerError;

                string result;

                if (Result != null)
                {
                    status = Result.Status.HasValue ? Result.Status.Value.ToEnum(status) : status;
                    result = Result.ToJson();
                }
                else
                {
                    result = Shared.Util.Result.InternalServerError().ToJson();
                }

                await context.HttpContext.Response.ToResultAsync(status, result).ConfigureAwait(false);
            }
        }
    }
}
