using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Globalization;
using System.Linq;

namespace Kitpymes.Core.Api
{
    public sealed class StatusCodesFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation != null)
            {
                operation.Responses ??= new OpenApiResponses();

                operation.Responses.Add(
                    StatusCodes.Status500InternalServerError.ToString(CultureInfo.CurrentCulture),
                    new OpenApiResponse { Description = Shared.Util.Resources.MsgFriendlyUnexpectedError });

                var authorizeAttributes = context?.MethodInfo?.DeclaringType?
                    .GetCustomAttributes(true)?
                    .Union(context.MethodInfo.GetCustomAttributes(true))?
                    .OfType<AuthorizeAttribute>();

                if (authorizeAttributes != null)
                {
                    operation.Responses.Add(
                        StatusCodes.Status401Unauthorized.ToString(CultureInfo.CurrentCulture),
                        new OpenApiResponse { Description = Shared.Util.Resources.MsgUnauthorizedAccess });
                }
            }
        }
    }
}
