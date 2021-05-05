// -----------------------------------------------------------------------
// <copyright file="SwaggerApplicationBuilderExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using Kitpymes.Core.Shared;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;

    public static class SwaggerApplicationBuilderExtensions
    {
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
                    if (apiVersionDescriptionProvider != null)
                    {
                        // options.RoutePrefix = swaggerSettings?.RoutePrefix;

                        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                        {
                            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());

                            // options.SwaggerEndpoint($"/{swaggerSettings?.RoutePrefixWithSlash}{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                        }
                    }
                });

            return application;
        }
    }
}
