using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization.TypeInspectors;

namespace Kitpymes.Core.Api
{
    public sealed class YamlDocumentFilter : IDocumentFilter
    {
        private IWebHostEnvironment HostingEnvironment { get; }

        public YamlDocumentFilter(IWebHostEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            try
            {
                var builder = new SerializerBuilder();

                builder.WithNamingConvention(new CamelCaseNamingConvention());

                builder.WithTypeInspector(innerInspector => new PropertiesIgnoreTypeInspector(innerInspector));

                var serializer = builder.Build();

                using var writer = new StringWriter();

                serializer.Serialize(writer, swaggerDoc);

                var file = Path.Combine(HostingEnvironment.WebRootPath, "swagger.yaml");

                using var stream = new StreamWriter(file);

                var result = writer.ToString();

                stream
                    .WriteLine(result
                        .Replace("2.0", "\"2.0\"", StringComparison.OrdinalIgnoreCase)
                        .Replace("ref:", "$ref:", StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private class PropertiesIgnoreTypeInspector : TypeInspectorSkeleton
        {
            private readonly ITypeInspector typeInspector;

            public PropertiesIgnoreTypeInspector(ITypeInspector typeInspector)
            {
                this.typeInspector = typeInspector;
            }

            public override IEnumerable<IPropertyDescriptor> GetProperties(Type type, object container)
            {
                return typeInspector.GetProperties(type, container).Where(p => p.Name != "extensions" && p.Name != "operation-id");
            }
        }
    }
}