// -----------------------------------------------------------------------
// <copyright file="SpaServiceCollectionExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using Microsoft.Extensions.DependencyInjection;

    /*
       Clase de extensión SpaServiceCollectionExtensions
       Contiene las extensiones de los servicios para las applicaciones de una sola página
    */

    /// <summary>
    /// Clase de extensión <c>SpaServiceCollectionExtensions</c>.
    /// Contiene las extensiones de los servicios para las applicaciones de una sola página.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las extensiones de los servicios para las applicaciones de una sola página.</para>
    /// </remarks>
    public static class SpaServiceCollectionExtensions
    {
        /// <summary>
        /// Valor por defecto que indica la ruta raiz del proyecto.
        /// </summary>
        public const string DefaultRootPath = "ClientApp/dist";

        /// <summary>
        /// Carga los servicios de applicaciones de una sola página (SPA).
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <param name="rootPath">Ruta raiz del proyecto.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection LoadSpa(
            this IServiceCollection services,
            string rootPath = DefaultRootPath)
        {
            if (!string.IsNullOrWhiteSpace(rootPath))
            {
                services.AddSpaStaticFiles(options =>
                {
                    options.RootPath = rootPath;
                });
            }

            return services;
        }
    }
}
