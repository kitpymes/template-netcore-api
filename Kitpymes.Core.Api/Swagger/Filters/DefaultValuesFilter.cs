// -----------------------------------------------------------------------
// <copyright file="DefaultValuesFilter.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System.Linq;
    using Microsoft.OpenApi.Any;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary>
    /// Filtro para los valores pode defecto.
    /// </summary>
    public sealed class DefaultValuesFilter : IOperationFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var parameters = operation?.Parameters?.OfType<OpenApiParameter>();

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    var description = context?.ApiDescription.ParameterDescriptions.FirstOrDefault(p => p.Name == parameter.Name);

                    if (description != null)
                    {
                        parameter.Description ??= description.ModelMetadata?.Description;

                        if (description.RouteInfo != null)
                        {
                            parameter.Required |= !description.RouteInfo.IsOptional;
                        }

                        if (description.DefaultValue != null)
                        {
                            parameter.Schema.Default ??= new OpenApiString(description.DefaultValue.ToString());
                        }
                    }
                }
            }
        }
    }
}
