// -----------------------------------------------------------------------
// <copyright file="SpaServiceCollectionExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;
    using Kitpymes.Core.Shared;
    using Microsoft.Extensions.DependencyInjection;

    public static class SapServiceCollectionExtensions
    {
        public static IServiceCollection LoadSpa(
            this IServiceCollection services,
            Action<SpaSettings> settings)
        => services.LoadSpa(settings.ToConfigureOrDefault());

        public static IServiceCollection LoadSpa(
            this IServiceCollection services,
            SpaSettings? settings = null)
        {
            settings ??= new SpaSettings();

            services.AddSpaStaticFiles(options =>
            {
                options.RootPath = settings.RootPath;
            });

            return services;
        }
    }
}
