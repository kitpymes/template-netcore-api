// -----------------------------------------------------------------------
// <copyright file="SwaggerApplicationBuilderExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System.Linq;
    using Kitpymes.Core.Shared;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;

    /*
        Clase de extensión SwaggerApplicationBuilderExtensions
        Contiene las extensiones para la configuración de swagger
    */

    /// <summary>
    /// Clase de extensión <c>SwaggerApplicationBuilderExtensions</c>.
    /// Contiene las extensiones para la configuración de swagger.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las extensiones para la configuración de swagger.</para>
    /// </remarks>
    public static class SwaggerApplicationBuilderExtensions
    {
        /// <summary>
        /// Carga las solicitudes de configuración de swagger.
        /// </summary>
        /// <param name="application">Define una clase que proporciona los mecanismos para configurar la solicitud de una aplicación.</param>
        /// <returns>IApplicationBuilder.</returns>
        public static IApplicationBuilder LoadSwagger(this IApplicationBuilder application)
        {
            var apiVersionDescriptionProvider = application.ToService<IApiVersionDescriptionProvider>();

            apiVersionDescriptionProvider.ToIsNullOrEmptyThrow(nameof(apiVersionDescriptionProvider));

            application
                .UseSwagger(options =>
                {
                    // options.RouteTemplate = swaggerSettings?.RoutePrefixWithSlash + "{documentName}/swagger.json";
                })
                .UseSwaggerUI(options =>
                {
                    /*
                        apiVersionDescriptionProvider
                            .ApiVersionDescriptions
                            .ToList()
                            .ForEach(description =>
                            {
                                options.SwaggerEndpoint(
                                   $"/{settings.RoutePrefixWithSlash}{description.GroupName}/swagger.json",
                                    description.GroupName.ToUpperInvariant());
                                options.RoutePrefix = settings.RoutePrefix;
                            });
                    */

                    apiVersionDescriptionProvider
                        .ApiVersionDescriptions
                        .ToList()
                        .ForEach(description =>
                        {
                            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                        });
                });

            return application;
        }
    }
}
