// -----------------------------------------------------------------------
// <copyright file="DependencyInjectionSession.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;
    using Kitpymes.Core.Shared;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    /*
        Clase de extensión DependencyInjectionSession
        Contiene las extensiones para los servicios del usuario logueado
    */

    /// <summary>
    /// Clase de extensión <c>DependencyInjectionSession</c>.
    /// Contiene las extensiones para los servicios del usuario logueado.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las extensiones para el servicio del usuario logueado.</para>
    /// </remarks>
    public static class DependencyInjectionSession
    {
        /// <summary>
        /// Carga el servicio de sesión.
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <param name="options">Configuración del servicio de sesión.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection LoadSession(
            this IServiceCollection services,
            Action<SessionOptions> options)
        {
            var settings = options.ToConfigureOrDefault().SessionSettings;

            if (settings?.Enabled == true)
            {
                services.TryAddSingleton(settings);
            }

            return services;
        }

        /// <summary>
        /// Carga el servicio de sesión con la configuración del appsettings.
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection LoadSession(this IServiceCollection services)
        {
            var settings = services.ToSettings<SessionSettings>();

            if (settings?.Enabled == true)
            {
                services.TryAddSingleton(settings);
            }

            return services;
        }

        /// <summary>
        /// Carga el middlware para la configuración del usuario logueado.
        /// </summary>
        /// <param name="application">Define una clase que proporciona los mecanismos para configurar la solicitud de una aplicación.</param>
        /// <returns>IApplicationBuilder.</returns>
        public static IApplicationBuilder LoadSession(this IApplicationBuilder application)
        {
            var settings = application.ToService<SessionSettings>();

            if (settings?.Enabled == true)
            {
                application.UseMiddleware<SessionMiddleware>();
            }

            return application;
        }
    }
}
