// -----------------------------------------------------------------------
// <copyright file="SessionMiddleware.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System.Linq;
    using System.Threading.Tasks;
    using Kitpymes.Core.Shared;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Hosting;

    /*
        Clase del middlware SessionMiddleware
        Valida y carga los datos del usuario logueado
    */

    /// <summary>
    /// Clase del middlware <c>SessionMiddleware</c>.
    /// Valida y carga los datos del usuario logueado.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las validaciones y la forma en que se cargan en sesión los datos del usuario logueado.</para>
    /// </remarks>
    public class SessionMiddleware
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SessionMiddleware"/>.
        /// </summary>
        /// <param name="requestDelegate">Una función que puede procesar una solicitud HTTP.</param>
        public SessionMiddleware(RequestDelegate requestDelegate) => RequestDelegate = requestDelegate;

        private RequestDelegate RequestDelegate { get; }

        /// <summary>
        /// Valida y carga los datos del usuario logueado.
        /// </summary>
        /// <param name="httpContext">Encapsula toda la información específica de una solicitud HTTP.</param>
        /// <returns>Task.</returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var hasAuthorization = httpContext.Request.ToHeader("Authorization")?
                .Any(x => x.StartsWith("Bearer")) == true;

            if (hasAuthorization && !AppSession.IsUserAutenticated)
            {
                var settings = (SessionSettings)httpContext.RequestServices
                   .GetService(typeof(SessionSettings))
                   .ToIsNullOrEmptyThrow(nameof(SessionSettings));

                if (settings.Enabled == true)
                {
                    AppSession.IsUserAutenticated = true;

                    AppSession.IsDevelopment = httpContext.RequestServices
                        .ToEnvironment()?.IsDevelopment() == true;

                    AppSession.IsMultitenancy = settings.IsMultitenancy == true;

                    if (AppSession.User is null)
                    {
                        AppSession.User = httpContext.User
                            .ToGet<UserSession>(nameof(UserSession))
                            .ToIsNullOrEmptyThrow(nameof(UserSession));
                    }

                    if (AppSession.IsMultitenancy == true && AppSession.Tenant is null)
                    {
                        var subdomain = httpContext.Request.ToSubdomain()
                               .ToIsSubdomainThrow("subdomain")
                               .ToLower();

                        AppSession.Tenant = settings.Tenants
                            .FirstOrDefault(x => x.Subdomain == subdomain && x.Enabled)
                            .ToIsNullOrEmptyThrow(nameof(subdomain));
                    }
                }
            }

            await RequestDelegate(httpContext).ConfigureAwait(false);
        }
    }
}