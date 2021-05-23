using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Kitpymes.Core.Api;
using System.Reflection;

namespace Tests.Api.Swagger
{
    /// <summary>
    /// Clase de configuraci�n de la app.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Obtiene la configuraci�n del app settings.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// /// Configuraci�n de los servicios de la app.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
               .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);

            /***  LoadSwagger  ***/
            services
                .LoadApiVersioning(options => options.WithEnabled().WithConventions(ApiVersioningConventions.Get))
                .LoadSwagger(options => options
                    .WithEnabled()
                    .WithXmlComments(Assembly.GetExecutingAssembly())
                    .WithLicense(new LicenseSettings 
                    {
                         Name = "MIT",
                         Url = "https://opensource.org/licenses/MIT"
                    }));
        }

        /// <summary>
        /// Configuraci�n de la app.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            /***  LoadSwagger  ***/
            app.LoadApiVersioning().LoadSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
