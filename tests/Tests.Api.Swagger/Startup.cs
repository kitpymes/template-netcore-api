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
    /// Clase de configuración de la app.
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
        /// Obtiene la configuración del app settings.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// /// Configuración de los servicios de la app.
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
        /// Configuración de la app.
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
