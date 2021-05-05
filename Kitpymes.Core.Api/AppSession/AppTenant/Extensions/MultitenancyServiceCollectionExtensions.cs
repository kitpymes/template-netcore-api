// -----------------------------------------------------------------------
// <copyright file="MultitenancyServiceCollectionExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;
    using Kitpymes.Core.Entities;
    using Kitpymes.Core.Shared;
    using Microsoft.Extensions.DependencyInjection;

    public static class MultitenancyServiceCollectionExtensions
    {
        public static IServiceCollection LoadMultitenancy(
            this IServiceCollection services,
            Action<MultitenancySettings> settings)
        => services.LoadMultitenancy(settings.ToConfigureOrDefault());

        public static IServiceCollection LoadMultitenancy(
            this IServiceCollection services,
            MultitenancySettings? settings = null)
        {
            settings ??= new MultitenancySettings();

            if (settings.Enabled.HasValue)
            {
                AppSession.Tenant = new TenantSession { Enabled = settings.Enabled };
            }

            return services;
        }
    }
}
