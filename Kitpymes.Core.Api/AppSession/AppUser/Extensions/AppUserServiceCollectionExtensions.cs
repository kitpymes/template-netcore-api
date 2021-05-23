// -----------------------------------------------------------------------
// <copyright file="AppUserServiceCollectionExtensions.cs" company="Kitpymes">
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
        Clase de extensión AppUserServiceCollectionExtensions
        Contiene las extensiones para los servicios del usuario logueado
    */

    /// <summary>
    /// Clase de extensión <c>AppUserServiceCollectionExtensions</c>.
    /// Contiene las extensiones para los servicios del usuario logueado.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las extensiones para el servicio del usuario logueado.</para>
    /// </remarks>
    public static class AppUserServiceCollectionExtensions
    {
        /// <summary>
        /// Carga el servicio del usuario logueado.
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <param name="options">Configuración del servicio del usuario logueado.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection LoadAppUser(
            this IServiceCollection services,
            Action<AppUserOptions> options)
        => services.LoadAppUser(options.ToConfigureOrDefault().AppUserSettings);

        /// <summary>
        /// Carga el servicio del usuario logueado.
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <param name="settings">Configuración del servicio del usuario logueado.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection LoadAppUser(
            this IServiceCollection services,
            AppUserSettings settings)
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
