// -----------------------------------------------------------------------
// <copyright file="AppTenantMiddleware.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System.Linq;
    using System.Threading.Tasks;
    using Kitpymes.Core.Entities;
    using Kitpymes.Core.Shared;
    using Microsoft.AspNetCore.Http;

    /*
        Clase del middlware AppTenantMiddleware
        Valida y carga los datos del inquilino en sesión
    */

    /// <summary>
    /// Clase del middlware <c>AppTenantMiddleware</c>.
    /// Valida y carga los datos del inquilino en sesión.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las validaciones y la forma en que se cargan en sesión los datos del inquilino.</para>
    /// </remarks>
    public class AppTenantMiddleware
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AppTenantMiddleware"/>.
        /// </summary>
        /// <param name="requestDelegate">Una función que puede procesar una solicitud HTTP.</param>
        public AppTenantMiddleware(RequestDelegate requestDelegate) => RequestDelegate = requestDelegate;

        private RequestDelegate RequestDelegate { get; }

        /// <summary>
        /// Valida y carga los datos del inquilino en sesión.
        /// </summary>
        /// <param name="httpContext">Encapsula toda la información específica de una solicitud HTTP.</param>
        /// <returns>Task.</returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext != null)
            {
                var subdomain = httpContext.Request.ToSubdomain().ToIsSubdomainThrow(nameof(TenantSession.Subdomain));

                if (subdomain != "localhost")
                {
                    var settings = (AppTenantSettings)httpContext.RequestServices.GetService(typeof(AppTenantSettings));

                    if (settings?.Enabled == true)
                    {
                        if (httpContext.User.ToIsAuthenticated())
                        {
                            AppSession.Tenant = httpContext.User.ToGet<TenantSession>(nameof(TenantSession));
                        }
                        else
                        {
                            var tenant = settings.Tenants.FirstOrDefault(x => x.Subdomain?.ToLower() == subdomain.ToLower())
                                .ToIsNullOrEmptyThrow(nameof(AppSession.Tenant));

                            if (tenant.Enabled == false)
                            {
                                Shared.Util.Check.Throw($"El inquilino '{tenant.Subdomain}' se encuentra desabilitado.");
                            }

                            AppSession.Tenant = new TenantSession
                            {
                                Enabled = tenant.Enabled,
                                Id = tenant.Id,
                                Subdomain = tenant.Subdomain,
                            };
                        }
                    }
                }

                await RequestDelegate(httpContext).ConfigureAwait(false);
            }
        }
    }
}