// -----------------------------------------------------------------------
// <copyright file="AppUserApplicationBuilderExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using Microsoft.AspNetCore.Builder;

    /*
      Clase de extensión AppUserApplicationBuilderExtensions
      Contiene las extensiones para la configuración del usuario logueado
    */

    /// <summary>
    /// Clase de extensión <c>AppUserApplicationBuilderExtensions</c>.
    /// Contiene las extensiones para la configuración del usuario logueado.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las extensiones para la configuración del usuario logueado.</para>
    /// </remarks>
    public static class AppUserApplicationBuilderExtensions
    {
        /// <summary>
        /// Carga el middlware para la configuración del usuario logueado.
        /// </summary>
        /// <param name="application">Define una clase que proporciona los mecanismos para configurar la solicitud de una aplicación.</param>
        /// <returns>IApplicationBuilder.</returns>
        public static IApplicationBuilder LoadAppUser(this IApplicationBuilder application)
        {
            application.UseMiddleware<AppUserMiddleware>();

            return application;
       }
    }
}
