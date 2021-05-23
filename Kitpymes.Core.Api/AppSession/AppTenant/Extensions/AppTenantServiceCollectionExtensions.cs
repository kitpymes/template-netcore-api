// -----------------------------------------------------------------------
// <copyright file="AppTenantServiceCollectionExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;
    using Kitpymes.Core.Shared;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    /*
        Clase de extensión AppTenantServiceCollectionExtensions
        Contiene las extensiones para los servicios de los inquilinos
    */

    /// <summary>
    /// Clase de extensión <c>AppTenantServiceCollectionExtensions</c>.
    /// Contiene las extensiones para los servicios de los inquilinos.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las extensiones para el servicio de los inquilinos.</para>
    /// </remarks>
    public static class AppTenantServiceCollectionExtensions
    {
        /// <summary>
        /// Carga el servicio de inquilinos.
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <param name="options">Configuración del servicio de inquilinos.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection LoadAppTenant(
            this IServiceCollection services,
            Action<AppTenantOptions> options)
        => services.LoadAppTenant(options.ToConfigureOrDefault().TenantSettings);

        /// <summary>
        /// Carga el servicio de inquilinos.
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <param name="settings">Configuración del servicio de inquilinos.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection LoadAppTenant(
            this IServiceCollection services,
            AppTenantSettings settings)
        {
            var config = settings.ToIsNullOrEmptyThrow(nameof(settings));

            if (config.Enabled == true)
            {
                services.TryAddSingleton(config);
            }

            return services;
        }
    }
}
