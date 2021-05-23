// -----------------------------------------------------------------------
// <copyright file="AppUserMiddleware.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System.Threading.Tasks;
    using Kitpymes.Core.Entities;
    using Kitpymes.Core.Shared;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Hosting;

    /*
        Clase del middlware AppUserMiddleware
        Valida y carga los datos del usuario logueado
    */

    /// <summary>
    /// Clase del middlware <c>AppUserMiddleware</c>.
    /// Valida y carga los datos del usuario logueado.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las validaciones y la forma en que se cargan en sesión los datos del usuario logueado.</para>
    /// </remarks>
    public class AppUserMiddleware
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AppUserMiddleware"/>.
        /// </summary>
        /// <param name="requestDelegate">Una función que puede procesar una solicitud HTTP.</param>
        public AppUserMiddleware(RequestDelegate requestDelegate) => RequestDelegate = requestDelegate;

        private RequestDelegate RequestDelegate { get; }

        /// <summary>
        /// Valida y carga los datos del usuario logueado.
        /// </summary>
        /// <param name="httpContext">Encapsula toda la información específica de una solicitud HTTP.</param>
        /// <returns>Task.</returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext != null)
            {
                var environment = httpContext.RequestServices.ToEnvironment();

                AppSession.IsDevelopment = environment?.IsDevelopment() ?? true;

                if (httpContext.User.ToIsAuthenticated())
                {
                    var settings = (AppUserSettings)httpContext.RequestServices.GetService(typeof(AppUserSettings));

                    if (settings?.Enabled == true)
                    {
                        AppSession.User = httpContext.User.ToGet<UserSession>(nameof(UserSession));
                    }
                }
            }

            await RequestDelegate(httpContext).ConfigureAwait(false);
        }
    }
}