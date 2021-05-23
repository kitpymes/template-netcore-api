// -----------------------------------------------------------------------
// <copyright file="SpaApplicationBuilderExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;
    using Kitpymes.Core.Shared;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.SpaServices.AngularCli;

    /*
        Clase de extensión SpaApplicationBuilderExtensions
        Contiene las extensiones para la configuración de los servicios de las applicaciones de una sola página
    */

    /// <summary>
    /// Clase de extensión <c>SpaApplicationBuilderExtensions</c>.
    /// Contiene las extensiones para la configuración de los servicios de las applicaciones de una sola página.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las extensiones para la configuración de los servicios de las applicaciones de una sola página.</para>
    /// </remarks>
    public static class SpaApplicationBuilderExtensions
    {
        /// <summary>
        /// Carga la configuración de una aplicación de una sola página o SPA.
        /// </summary>
        /// <param name="application">Define una clase que proporciona los mecanismos para configurar la solicitud de una aplicación.</param>
        /// <param name="options">Configuración del servicio.</param>
        /// <returns>IApplicationBuilder.</returns>
        public static IApplicationBuilder LoadSpa(
           this IApplicationBuilder application,
           Action<SpaOptions> options)
        => application.LoadSpa(options.ToConfigureOrDefault().SpaSettings);

        /// <summary>
        /// Carga la configuración de una aplicación de una sola página o SPA.
        /// </summary>
        /// <param name="application">Define una clase que proporciona los mecanismos para configurar la solicitud de una aplicación.</param>
        /// <param name="settings">Configuración del servicio.</param>
        /// <returns>IApplicationBuilder.</returns>
        public static IApplicationBuilder LoadSpa(
           this IApplicationBuilder application,
           SpaSettings settings)
        {
            if (settings.Enabled == true)
            {
                SpaBaseSettings? baseSettings = null;

                if (settings.AngularSettings?.Enabled == true)
                {
                    baseSettings = settings.AngularSettings;
                }

                if (baseSettings != null)
                {
                    application.UseSpa(configuration =>
                    {
                        configuration.Options.SourcePath = baseSettings?.SourcePath;

                        if (!string.IsNullOrWhiteSpace(baseSettings?.NpmScript))
                        {
                            configuration.UseAngularCliServer(baseSettings?.NpmScript);
                        }

                        if (!string.IsNullOrWhiteSpace(baseSettings?.BaseUri))
                        {
                            configuration.UseProxyToSpaDevelopmentServer(baseSettings?.BaseUri);
                        }
                    });
                }
            }

            return application;
        }
    }
}
