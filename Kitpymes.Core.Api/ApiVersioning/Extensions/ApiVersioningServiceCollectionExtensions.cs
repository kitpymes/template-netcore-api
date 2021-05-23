// -----------------------------------------------------------------------
// <copyright file="ApiVersioningServiceCollectionExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;
    using Kitpymes.Core.Shared;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Versioning;
    using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /*
        Clase de extensión ApiVersioningServiceCollectionExtensions
        Contiene las extensiones para los servicios del versionado de la api
    */

    /// <summary>
    /// Clase de extensión <c>ApiVersioningServiceCollectionExtensions</c>.
    /// Contiene las extensiones para los servicios del versionado de la api.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las extensiones para el versionado de la api.</para>
    /// </remarks>
    public static class ApiVersioningServiceCollectionExtensions
    {
        /// <summary>
        /// Carga el servicio de versionado.
        /// <para><strong>- Ejemplos:</strong></para>
        /// <para>
        ///     conventions.Controller{HomeV1Controller}().HasApiVersion(new ApiVersion(1, 0, ApiVersionStatus.Alpha.ToString()));.
        /// </para>
        /// <para>
        ///     conventions.Controller{HomeV2Controller}().HasApiVersion(new ApiVersion(2, 0));.
        /// <para>
        /// </para>
        ///     conventions.Controller{HomeV3Controller}()
        ///         <br/> .HasDeprecatedApiVersion(3, 0)
        ///         <br/> .HasApiVersion(3, 1)
        ///         <br/> .HasApiVersion(4, 0)
        ///         <br/> .Action(c => c.Get3_0()).MapToApiVersion(3, 0)
        ///         <br/> .Action(c => c.Get3_1()).MapToApiVersion(3, 1)
        ///         <br/> .Action(c => c.Get4_0()).MapToApiVersion(4, 0);.
        /// </para>
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <param name="configuration">Configuración del servicio de versionado.</param>
        /// <param name="apiVersionReader">Lector de la versión de la API.</param>
        /// <param name="conventions">Configuración de los endpoints de los controladores.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection LoadApiVersioning(
            this IServiceCollection services,
            IConfiguration configuration,
            IApiVersionReader? apiVersionReader = null,
            IApiVersionConventionBuilder? conventions = null)
        {
            var settings = configuration?.Get<ApiVersioningSettings>();

            var config = settings.ToIsNullOrEmptyThrow(nameof(settings));

            if (apiVersionReader != null)
            {
                config.ApiVersionReader = apiVersionReader;
            }

            if (conventions != null)
            {
                config.Conventions = conventions;
            }

            return services.LoadApiVersioning(config);
        }

        /// <summary>
        /// Carga el servicio de versionado.
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <param name="options">Configuración del servicio de versionado.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection LoadApiVersioning(
             this IServiceCollection services,
             Action<ApiVersioningOptions> options)
        => services.LoadApiVersioning(options.ToConfigureOrDefault().ApiVersioningSettings);

        /// <summary>
        /// Carga el servicio de versionado.
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <param name="settings">Configuración del servicio de versionado.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection LoadApiVersioning(
            this IServiceCollection services,
            ApiVersioningSettings settings)
        {
            var config = settings.ToIsNullOrEmptyThrow(nameof(settings));

            if (config.Enabled == true)
            {
                services
                  .AddApiVersioning(options =>
                  {
                      options.DefaultApiVersion = new ApiVersion(config.MajorVersion!.Value, config.MinorVersion!.Value);

                      options.AssumeDefaultVersionWhenUnspecified = config.AssumeDefaultVersionWhenUnspecified!.Value;

                      options.ApiVersionReader = config.ApiVersionReader!;

                      options.ReportApiVersions = config.ReportApiVersions!.Value;

                      if (config.Conventions != null)
                      {
                          options.Conventions = config.Conventions;
                      }
                  })
                  .AddVersionedApiExplorer(options =>
                  {
                      options.AssumeDefaultVersionWhenUnspecified = config.AssumeDefaultVersionWhenUnspecified!.Value;

                      options.GroupNameFormat = config.GroupNameFormat!;

                      options.SubstituteApiVersionInUrl = config.SubstituteApiVersionInUrl!.Value;
                  });
            }

            return services;
        }
    }
}