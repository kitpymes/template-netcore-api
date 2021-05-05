using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Kitpymes.Core.Api
{
    public class AuthorizationBearerFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authorizeAttributes = context.GetControllerAndActionAttributes<AuthorizeAttribute>();

            if (authorizeAttributes.Any())
            {
                var policies = authorizeAttributes.Select(attr => attr.Policy).Distinct().ToList();

                if (operation != null)
                {
                    operation.Security ??= new List<OpenApiSecurityRequirement>();

                    operation.Security.Add(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Name = "Authorization",

                                Scheme = "Bearer",

                                In = ParameterLocation.Header,

                                Type = SecuritySchemeType.ApiKey,

                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,

                                    Id = "Bearer"
                                }
                            },
                            policies
                        }
                    });
                }
            }
        }
    }
}
