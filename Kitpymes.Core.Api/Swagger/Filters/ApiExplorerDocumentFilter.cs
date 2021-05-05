using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Kitpymes.Core.Api
{
    public class ApiExplorerDocumentFilter : IDocumentFilter
    {
        private ApiExplorerOptions? ApiExplorerOptions { get; }

        public ApiExplorerDocumentFilter(IOptions<ApiExplorerOptions> options)
        {
            ApiExplorerOptions = options?.Value;
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var DefaultApiVersion = ApiExplorerOptions?.DefaultApiVersion;

            var versionSegment = DefaultApiVersion?.ToString(ApiExplorerOptions?.SubstitutionFormat, CultureInfo.CurrentCulture);
            
            if(context?.ApiDescriptions != null)
            {
                foreach (var apiDescription in context.ApiDescriptions)
                {
                    //If the version is default remove paths like: api/v1.0/controller
                    if (apiDescription.GetApiVersion() == DefaultApiVersion)
                    {
                        if(versionSegment != null)
                        {
                            if (apiDescription.RelativePath.Contains(versionSegment, System.StringComparison.CurrentCulture))
                            {
                                var path = "/" + apiDescription.RelativePath;

                                swaggerDoc?.Paths.Remove(path);
                            }
                        }
                    }
                    //If the version is not default remove paths like api/controller
                    else
                    {
                        var match = Regex.Match(apiDescription.RelativePath, @"^api\/v\d+");

                        if (!match.Success)
                        {
                            var path = "/" + apiDescription.RelativePath;

                            swaggerDoc?.Paths.Remove(path);
                        }
                    }
                }
            }
        }
    }
}
