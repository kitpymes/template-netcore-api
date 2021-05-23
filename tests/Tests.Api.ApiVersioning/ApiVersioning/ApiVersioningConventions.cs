using Kitpymes.Core.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;

namespace Tests.Api.ApiVersioning
{
    public static class ApiVersioningConventions
    {
        public static IApiVersionConventionBuilder Get => new ApiVersionConventionBuilder()
            .AddValuesController();

        private static ApiVersionConventionBuilder AddValuesController(this ApiVersionConventionBuilder builder)
        {
            builder.Controller<Controllers.v1.ValuesController>()
               .HasDeprecatedApiVersion(1, 0)
               .HasApiVersion(1, 0)
               .Action(c => c.Get()).MapToApiVersion(1, 0);

            builder.Controller<Controllers.v2.ValuesController>()
              .HasApiVersion(2, 0, ApiVersioningStatus.Stable.ToString())
              .Action(c => c.Get()).MapToApiVersion(2, 0);

            builder.Controller<Controllers.v3.ValuesController>()
              .HasApiVersion(3, 0, ApiVersioningStatus.Beta.ToString())
              .Action(c => c.Get()).MapToApiVersion(3, 0);

            return builder;
        }
    }
}
