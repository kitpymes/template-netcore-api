// -----------------------------------------------------------------------
// <copyright file="AppSessionApplicationBuilderExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using Microsoft.AspNetCore.Builder;

    /*
       Clase de extensión AppSessionApplicationBuilderExtensions
       Contiene las extensiones para la configuración de la sesión de la app
    */

    /// <summary>
    /// Clase de extensión <c>AppSessionApplicationBuilderExtensions</c>.
    /// Contiene las extensiones para la configuración de la sesión de la app.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las extensiones para la configuración de la sesión de la app.</para>
    /// </remarks>
    public static class AppSessionApplicationBuilderExtensions
    {
        /// <summary>
        /// Carga el middlware para la sesión de la app.
        /// <para>
        /// La configuración del middleware de la sesión de la api, carga los datos de usuario autenticado.
        /// </para>
        /// </summary>
        /// <param name="application">Define una clase que proporciona los mecanismos para configurar la solicitud de una aplicación.</param>
        /// <returns>IApplicationBuilder.</returns>
        public static IApplicationBuilder LoadAppSession(this IApplicationBuilder application)
        {
            application.UseMiddleware<AppSessionMiddleware>();

            return application;
       }
    }
}
