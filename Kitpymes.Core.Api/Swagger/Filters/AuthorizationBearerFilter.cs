// -----------------------------------------------------------------------
// <copyright file="AuthorizationBearerFilter.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary>
    /// Filtro para la autorización.
    /// </summary>
    public class AuthorizationBearerFilter : IOperationFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authorizeAttributes = context.GetControllerAndActionAttributes<AuthorizeAttribute>();

            if (authorizeAttributes is not null && authorizeAttributes.Any())
            {
                var policies = authorizeAttributes.Select(attr => attr.Policy).Distinct().ToList();

                if (operation != null)
                {
                    operation.Security ??= new List<OpenApiSecurityRequirement>();

                    operation.Security.Add(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Name = "Authorization",

                                Scheme = "Bearer",

                                In = ParameterLocation.Header,

                                Type = SecuritySchemeType.ApiKey,

                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,

                                    Id = "Bearer",
                                },
                            },
                            policies
                        },
                    });
                }
            }
        }
    }
}
