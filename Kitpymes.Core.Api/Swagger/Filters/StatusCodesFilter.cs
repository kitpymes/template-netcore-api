// -----------------------------------------------------------------------
// <copyright file="StatusCodesFilter.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System.Globalization;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary>
    /// Filtro para los HTTP Status.
    /// </summary>
    public sealed class StatusCodesFilter : IOperationFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation != null)
            {
                operation.Responses ??= new OpenApiResponses();

                operation.Responses.Add(
                    StatusCodes.Status500InternalServerError.ToString(CultureInfo.CurrentCulture),
                    new OpenApiResponse { Description = Shared.Util.Resources.MsgFriendlyUnexpectedError });

                var authorizeAttributes = context?.MethodInfo?.DeclaringType?
                    .GetCustomAttributes(true)?
                    .Union(context.MethodInfo.GetCustomAttributes(true))?
                    .OfType<AuthorizeAttribute>();

                if (authorizeAttributes != null)
                {
                    operation.Responses.Add(
                        StatusCodes.Status401Unauthorized.ToString(CultureInfo.CurrentCulture),
                        new OpenApiResponse { Description = Shared.Util.Resources.MsgUnauthorizedAccess });
                }
            }
        }
    }
}
