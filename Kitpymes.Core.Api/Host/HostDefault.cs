// -----------------------------------------------------------------------
// <copyright file="HostDefault.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;
    using System.Threading;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Serilog;

    public class Loggers
    {
        public static void CreateDefaultLog()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.Logger(config => config.MinimumLevel.Warning()
                    .WriteTo.File("Warning.log"))
                .WriteTo.Logger(config => config.MinimumLevel.Error()
                    .WriteTo.File("Error.log"))
                .CreateLogger();
        }
    }

    public static class HostDefault
    {
        public static void Run<TStartup>()
            where TStartup : class
        {
            var machineName = Environment.MachineName;

            Loggers.CreateDefaultLog();

            try
            {
                Log.Information("Starting Host: {machineName}...", machineName);

                Host.CreateDefaultBuilder()
                    .ConfigureHostConfiguration(config => { })
                    //.UseSerilog((context, logger) =>
                    //{
                    //    logger.ReadFrom.Configuration(context.Configuration, "SerilogSettings");
                    //})
                    .ConfigureWebHostDefaults(builder =>
                    {
                        builder
                            .UseStartup<TStartup>()
                            .CaptureStartupErrors(true)
                            .ConfigureServices((context, services) => { })
                            .ConfigureAppConfiguration((context, config) => { })
                            .ConfigureLogging((context, logging) =>
                            {
                                //logging.ClearProviders();

                                logging.AddConsole();

                               // logging.AddSerilog(Log.Logger);
                            })
                            .ConfigureKestrel(options => { })
                            .UseDefaultServiceProvider((context, options) =>
                            {
                                options.ValidateOnBuild = context.HostingEnvironment.IsDevelopment();
                            });
                    })
                    .Build()
                    .Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");

                Thread.Sleep(20000);

                throw;
            }
            finally
            {
                Log.Information("Ending Host: {machineName}...", machineName);

                Thread.Sleep(20000);

                Log.CloseAndFlush();
            }
        }
    }
}