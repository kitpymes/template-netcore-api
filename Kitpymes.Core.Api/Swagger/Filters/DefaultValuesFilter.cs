using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Kitpymes.Core.Api
{
    public sealed class DefaultValuesFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var parameters = operation?.Parameters?.OfType<OpenApiParameter>();

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    var description = context?.ApiDescription.ParameterDescriptions.FirstOrDefault(p => p.Name == parameter.Name);

                    if (description != null)
                    {
                        parameter.Description ??= description.ModelMetadata?.Description;

                        if (description.RouteInfo != null)
                        {
                            parameter.Required |= !description.RouteInfo.IsOptional;
                        }

                        if (description.DefaultValue != null)
                        {
                            parameter.Schema.Default ??= new OpenApiString(description.DefaultValue.ToString());
                        }
                    }
                }
            }
        }
    }
}
