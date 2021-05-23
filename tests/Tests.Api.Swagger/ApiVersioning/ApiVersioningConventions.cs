using Kitpymes.Core.Api;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;

namespace Tests.Api.Swagger
{
    /// <summary>
    /// Configuración de las versiones de los endpoints.
    /// </summary>
    public static class ApiVersioningConventions
    {
        /// <summary>
        /// Obtiene las versiones de los endponits.
        /// </summary>
        public static IApiVersionConventionBuilder Get => new ApiVersionConventionBuilder()
            .AddValuesController();

        private static ApiVersionConventionBuilder AddValuesController(this ApiVersionConventionBuilder builder)
        {
            builder.Controller<Controllers.v1.ValuesController>()
               .HasDeprecatedApiVersion(1, 0)
               .HasApiVersion(1, 0);

            builder.Controller<Controllers.v2.ValuesController>()
              .HasApiVersion(2, 0, ApiVersioningStatus.Stable.ToString());

            return builder;
        }
    }
}
