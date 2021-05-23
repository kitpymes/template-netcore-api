// -----------------------------------------------------------------------
// <copyright file="SwaggerServiceCollectionExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;
    using System.IO;
    using Kitpymes.Core.Shared;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /*
       Clase de extensión SwaggerServiceCollectionExtensions
       Contiene las extensiones para los servicios de swagger
    */

    /// <summary>
    /// Clase de extensión <c>SwaggerServiceCollectionExtensions</c>.
    /// Contiene las extensiones para los servicios de swagger.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las extensiones para los servicios de swagger.</para>
    /// </remarks>
    public static class SwaggerServiceCollectionExtensions
    {
        /// <summary>
        /// Carga los servicios de swagger.
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <param name="options">Configuración del servicio de swagger.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection LoadSwagger(
           this IServiceCollection services,
           Action<SwaggerOptions> options)
        => services.LoadSwagger(options.ToConfigureOrDefault().SwaggerSettings);

        /// <summary>
        /// Carga los servicios de swagger.
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <param name="settings">Configuración del servicio de swagger.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection LoadSwagger(
            this IServiceCollection services,
            SwaggerSettings settings)
        {
            if (settings?.Enabled == true)
            {
                services
                   .AddSwaggerGen(setupAction =>
                   {
                       setupAction.IgnoreObsoleteActions();

                       setupAction.IgnoreObsoleteProperties();

                       setupAction.AddSecurityDefinition(settings.Security.Title, GetOpenApiSecurityScheme(settings));

                       var apiVersionDescriptionProvider = services.ToService<IApiVersionDescriptionProvider>();

                       if (apiVersionDescriptionProvider != null)
                       {
                           AddSwaggerDocs(setupAction, settings, apiVersionDescriptionProvider);
                       }

                       var xmlComments = GetXmlComments(settings);

                       if (xmlComments != null)
                       {
                           setupAction.IncludeXmlComments(xmlComments);
                       }

                       setupAction.OperationFilter<StatusCodesFilter>();

                       setupAction.OperationFilter<AuthorizationBearerFilter>();

                       setupAction.OperationFilter<DefaultValuesFilter>();

                       setupAction.DocumentFilter<ApiExplorerDocumentFilter>();

                       setupAction.DocumentFilter<YamlDocumentFilter>();
                   });
            }

            return services;
        }

        private static OpenApiSecurityScheme GetOpenApiSecurityScheme(SwaggerSettings settings)
        {
            var openApiSecurityScheme = new OpenApiSecurityScheme
            {
                Name = settings.Security.Name,

                Scheme = settings.Security.Scheme,

                Description = settings.Security.Description,
            };

            if (settings.Security.ParameterLocation.HasValue)
            {
                openApiSecurityScheme.In = settings.Security.ParameterLocation.Value.ToEnum<ParameterLocation>();
            }

            if (settings.Security.SecurityType.HasValue)
            {
                openApiSecurityScheme.Type = settings.Security.SecurityType.Value.ToEnum<SecuritySchemeType>();
            }

            return openApiSecurityScheme;
        }

        private static string? GetXmlComments(SwaggerSettings settings)
        {
            if (settings.XmlComments != null)
            {
                var xmlFile = $"{settings.XmlComments.GetName().Name}.xml";

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                if (File.Exists(xmlPath))
                {
                    return xmlPath;
                }
            }

            return null;
        }

        private static void AddSwaggerDocs(SwaggerGenOptions setupAction, SwaggerSettings settings, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
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
