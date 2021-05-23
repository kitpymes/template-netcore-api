// -----------------------------------------------------------------------
// <copyright file="AppTenantApplicationBuilderExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using Microsoft.AspNetCore.Builder;

    /*
      Clase de extensión AppTenantApplicationBuilderExtensions
      Contiene las extensiones para la configuración de los inquilinos
    */

    /// <summary>
    /// Clase de extensión <c>AppTenantApplicationBuilderExtensions</c>.
    /// Contiene las extensiones para la configuración de los inquilinos.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las extensiones para la configuración de los inquilinos.</para>
    /// </remarks>
    public static class AppTenantApplicationBuilderExtensions
    {
        /// <summary>
        /// Carga el middlware para la configuración de los inquilinos.
        /// </summary>
        /// <param name="application">Define una clase que proporciona los mecanismos para configurar la solicitud de una aplicación.</param>
        /// <returns>IApplicationBuilder.</returns>
        public static IApplicationBuilder LoadAppTenant(this IApplicationBuilder application)
        {
            application.UseMiddleware<AppTenantMiddleware>();

            return application;
       }
    }
}
