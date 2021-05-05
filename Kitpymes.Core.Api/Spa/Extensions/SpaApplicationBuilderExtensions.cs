// -----------------------------------------------------------------------
// <copyright file="SpaApplicationBuilderExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;
    using Kitpymes.Core.Shared;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.SpaServices.AngularCli;

    public static class SpaApplicationBuilderExtensions
    {
        public static IApplicationBuilder LoadSpa(
           this IApplicationBuilder application,
           Action<SpaSettings>? settings)
       => application.LoadSpa(settings.ToConfigureOrDefault());

        public static IApplicationBuilder LoadSpa(
           this IApplicationBuilder application,
           SpaSettings settings)
        {
            application.UseSpa(configuration =>
            {
                configuration.Options.SourcePath = settings.SourcePath;

                if (settings.EnabledAngular.HasValue && settings.EnabledAngular.Value)
                {
                    configuration.UseAngularCliServer(settings.NpmScript);
                }

                if (settings.EnabledProxyToSpaDevelopmentServe.HasValue && settings.EnabledProxyToSpaDevelopmentServe.Value)
                {
                    configuration.UseProxyToSpaDevelopmentServer(settings.ProxyBaseUri);
                }
            });

            return application;
        }
    }
}
