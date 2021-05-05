// -----------------------------------------------------------------------
// <copyright file="MultitenancyApplicationBuilderExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using Kitpymes.Core.Entities;
    using Microsoft.AspNetCore.Builder;

    public static class MultitenancyApplicationBuilderExtensions
    {
        public static IApplicationBuilder LoadMultitenancy(this IApplicationBuilder application)
        {
            if (AppSession.Tenant?.Enabled == true)
            {
                application.UseMiddleware<MultitenancyMiddleware>();
            }

            return application;
       }
    }
}
