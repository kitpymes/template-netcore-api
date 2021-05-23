// -----------------------------------------------------------------------
// <copyright file="CreateHost.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /*
        Clase de inicio de la app CreateHost
        Contiene los inicio de la app
    */

    /// <summary>
    /// Clase de inicio de la app <c>CreateHost</c>.
    /// Contiene los diferentes inicios por defecto de la app.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todos los inicios por defecto de la app.</para>
    /// </remarks>
    public static class CreateHost
    {
        /// <summary>
        /// Clase de inicio por defecto de la app.
        /// </summary>
        /// <typeparam name="TStartup">Clase de configuración de la app.</typeparam>
        /// <param name="args">Argumentos de comando.</param>
        public static void Run<TStartup>(string[] args)
            where TStartup : class
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(config => { })
                .ConfigureWebHostDefaults(builder =>
                {
                    builder
                        .UseStartup<TStartup>()
                        .CaptureStartupErrors(true)
                        .ConfigureServices((context, services) => { })
                        .ConfigureAppConfiguration((context, config) => { })
                        .ConfigureLogging((context, logging) => { })
                        .ConfigureKestrel(options => { })
                        .UseDefaultServiceProvider((context, options) =>
                        {
                            options.ValidateOnBuild = context.HostingEnvironment.IsDevelopment();
                        });
                })
                .Build()
                .Run();
        }
    }
}