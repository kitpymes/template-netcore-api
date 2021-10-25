// -----------------------------------------------------------------------
// <copyright file="InitHost.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;
    using System.Threading.Tasks;
    using Kitpymes.Core.Logger;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

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
    public static class InitHost
    {
        /// <summary>
        /// Clase de inicio del host, utilizada para inicios rápidos sin configuraciones.
        /// </summary>
        /// <typeparam name="TStartup">Clase de configuración de la app.</typeparam>
        /// <param name="args">Argumentos de comando.</param>
        /// <returns>Representa la operación asincrónica.</returns>
        public static async Task RunAsync<TStartup>(string[] args)
            where TStartup : class
        => await Custom<TStartup>(args).Build().RunAsync();

        /// <summary>
        /// Clase de inicio del host, utilizada para proyectos, configurada con logeo de errores.
        /// </summary>
        /// <typeparam name="TStartup">Clase de configuración de la app.</typeparam>
        /// <param name="args">Argumentos de comando.</param>
        /// <returns>Representa la operación asincrónica.</returns>
        public static IHost Build<TStartup>(string[] args)
            where TStartup : class
        {
            var logger = Log
                .UseSerilog(serilog => serilog.AddConsole().AddFile("Logs/start_host/.log"))
                .CreateLogger(nameof(InitHost));

            IHost host = null!;

            try
            {
                logger.Info("Started host...\r\n");

                host = Custom<TStartup>(args)
                    .ConfigureWebHostDefaults(builder =>
                    {
                        builder
                            .ConfigureAppConfiguration((hostingContext, config) =>
                            {
                                config.AddCommandLine(args);
                            })
                            .ConfigureLogging((context, logging) =>
                            {
                                logging.ClearProviders()
                                   .AddFilter("Microsoft.Hosting.Lifetime", LogLevel.Error)
                                   .AddFilter("Microsoft.AspNetCore.Hosting.Diagnostics", LogLevel.Error)
                                   .AddFilter("Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware", LogLevel.Error)
                                   .AddFilter("System", LogLevel.Error)
                                   .AddFilter("Console", LogLevel.Error)
                                   .AddSimpleConsole(x =>
                                   {
                                       x.TimestampFormat = "[yyyy/MM/dd] hh:mm:ss:\r\n\r\n";
                                   });
                            });
                    })
                    .UseDefaultServiceProvider((context, options) =>
                    {
                        options.ValidateOnBuild = context.HostingEnvironment.IsDevelopment();
                    })
                    .Build();
            }
            catch (Exception ex)
            {
                logger.Error(ex);

                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                if (environment == Environments.Development)
                {
                    logger.Info($"An error occurred, press ENTER to finish host...\r\n");

                    Console.ReadLine();
                }
                else
                {
                    logger.Info("An error occurred, Stopping host...\r\n");

                    _ = Task.Delay(10000);
                }
            }

            return host;
        }

        /// <summary>
        /// Clase de inicio del host, utilizada para ser customizada, no tiene ninguna configuración.
        /// </summary>
        /// <typeparam name="TStartup">Clase de configuración de la app.</typeparam>
        /// <param name="args">Argumentos de comando.</param>
        /// <returns>Representa la operación asincrónica.</returns>
        public static IHostBuilder Custom<TStartup>(string[] args)
            where TStartup : class
         => Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(config => { })
                .ConfigureWebHostDefaults(builder =>
                {
                    builder
                        .UseStartup<TStartup>()
                        .ConfigureKestrel(options => { })
                        .ConfigureServices((context, services) => { })
                        .ConfigureAppConfiguration((hostingContext, config) => { });
                });
    }
}