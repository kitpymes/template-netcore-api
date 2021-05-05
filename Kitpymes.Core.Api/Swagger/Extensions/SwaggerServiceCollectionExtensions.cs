// -----------------------------------------------------------------------
// <copyright file="SwaggerServiceCollectionExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;
    using Kitpymes.Core.Shared;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public static class SwaggerServiceCollectionExtensions
    {
        public static IServiceCollection LoadSwagger(
           this IServiceCollection services,
           Action<SwaggerSettings>? settings = null)
        => services.LoadSwagger(settings.ToConfigureOrDefault());

        public static IServiceCollection LoadSwagger(
            this IServiceCollection services,
            SwaggerSettings settings)
        {
            services
                .AddSwaggerGen(setupAction =>
                {
                    setupAction.IgnoreObsoleteActions();

                    setupAction.IgnoreObsoleteProperties();

                    setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",

                        Scheme = "Bearer",

                        In = ParameterLocation.Header,

                        Type = SecuritySchemeType.ApiKey,

                        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    });

                    var apiVersionDescriptionProvider = services.ToService<IApiVersionDescriptionProvider>();

                    AddSwaggerDocs(setupAction, settings, apiVersionDescriptionProvider);

                    AddXmlComments(setupAction, settings);

                    setupAction.OperationFilter<StatusCodesFilter>();

                    setupAction.OperationFilter<AuthorizationBearerFilter>();

                    setupAction.OperationFilter<DefaultValuesFilter>();

                    setupAction.DocumentFilter<ApiExplorerDocumentFilter>();

                    setupAction.DocumentFilter<YamlDocumentFilter>();
                });

            return services;
        }

        private static void AddXmlComments(SwaggerGenOptions setupAction, SwaggerSettings settings)
        {
            foreach (var xmlPath in settings.XmlCommentsPaths)
            {
                setupAction.IncludeXmlComments(xmlPath);
            }
        }

        private static void AddSwaggerDocs(SwaggerGenOptions setupAction, SwaggerSettings settings, IApiVersionDescriptionProvider? apiVersionDescriptionProvider)
        {
            var info = new OpenApiInfo()
            {
                Title = settings.Title,

                Version = settings.Version,

                Description = settings.Description,

                TermsOfService = settings.TermsOfServiceUrl?.ToUri(),

                Contact = new OpenApiContact
                {
                    Email = settings.Contact.Email,

                    Name = settings.Contact.Name,

                    Url = settings.Contact.Url?.ToUri(),
                },

                License = new OpenApiLicense
                {
                    Name = settings.License.Name,

                    Url = settings.License.Url?.ToUri(),
                },
            };

            if (apiVersionDescriptionProvider != null)
            {
                foreach (var apiVersionDescription in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    if (string.IsNullOrWhiteSpace(info.Version))
                    {
                        info.Version = apiVersionDescription.ApiVersion.ToString();
                    }

                    if (apiVersionDescription.IsDeprecated)
                    {
                        info.Description += " - DEPRECATED";
                    }

                    setupAction.SwaggerDoc(apiVersionDescription.GroupName, info);
                }
            }
        }
    }
}
