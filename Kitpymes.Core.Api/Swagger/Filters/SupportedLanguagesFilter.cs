// -----------------------------------------------------------------------
// <copyright file="SupportedLanguagesFilter.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------
namespace Kitpymes.Core.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Options;
    using Microsoft.OpenApi.Any;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary>
    /// Filtro del documento de api explorer.
    /// </summary>
    public class SupportedLanguagesFilter : IOperationFilter
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SupportedLanguagesFilter"/>.
        /// </summary>
        /// <param name="serviceProvider">Provee un objeto para obtener servicios.</param>
        public SupportedLanguagesFilter(IServiceProvider serviceProvider)
        => ServiceProvider = serviceProvider;

        private IServiceProvider? ServiceProvider { get; }

        /// <inheritdoc/>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            var options = (ServiceProvider?.GetService(typeof(IOptions<RequestLocalizationOptions>)) as IOptions<RequestLocalizationOptions>)?.Value;

            var defaultRequestCulture = options?.DefaultRequestCulture.Culture.Name;

            var supportedCultures = options?.SupportedCultures?.Select(c => new OpenApiString(c.Name)).ToList<IOpenApiAny>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Accept-Language",

                In = ParameterLocation.Header,

                Description = "Supported languages",

                Required = false,

                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Enum = supportedCultures,
                    Default = new OpenApiString(defaultRequestCulture),
                },
            });
        }
    }
}