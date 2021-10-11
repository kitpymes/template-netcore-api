// -----------------------------------------------------------------------
// <copyright file="ApiExplorerDocumentFilter.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------
namespace Kitpymes.Core.Api
{
    using System.Globalization;
    using System.Text.RegularExpressions;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.Options;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary>
    /// Filtro del documento de api explorer.
    /// </summary>
    public class ApiExplorerDocumentFilter : IDocumentFilter
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ApiExplorerDocumentFilter"/>.
        /// </summary>
        /// <param name="options">Configuración del ApiExplorer.</param>
        public ApiExplorerDocumentFilter(IOptions<ApiExplorerOptions> options)
        => ApiExplorerOptions = options?.Value;

        private ApiExplorerOptions? ApiExplorerOptions { get; }

        /// <inheritdoc/>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var defaultApiVersion = ApiExplorerOptions?.DefaultApiVersion;

            var versionSegment = defaultApiVersion?.ToString(ApiExplorerOptions?.SubstitutionFormat, CultureInfo.CurrentCulture);

            if (context?.ApiDescriptions != null)
            {
                foreach (var apiDescription in context.ApiDescriptions)
                {
                    // If the version is default remove paths like: api/v1.0/controller
                    if (apiDescription.GetApiVersion() == defaultApiVersion)
                    {
                        if (versionSegment != null)
                        {
                            if (apiDescription.RelativePath.Contains(versionSegment, System.StringComparison.CurrentCulture))
                            {
                                var path = "/" + apiDescription.RelativePath;

                                swaggerDoc?.Paths.Remove(path);
                            }
                        }
                    }

                    // If the version is not default remove paths like api/controller
                    else
                    {
                        var match = Regex.Match(apiDescription.RelativePath, @"^api\/v\d+");

                        if (!match.Success)
                        {
                            var path = "/" + apiDescription.RelativePath;

                            swaggerDoc?.Paths.Remove(path);
                        }
                    }
                }
            }
        }
    }
}
