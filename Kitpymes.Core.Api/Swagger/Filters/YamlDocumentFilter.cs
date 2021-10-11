// -----------------------------------------------------------------------
// <copyright file="YamlDocumentFilter.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using YamlDotNet.Serialization;
    using YamlDotNet.Serialization.NamingConventions;
    using YamlDotNet.Serialization.TypeInspectors;

    /// <summary>
    /// Filtro para la documentación Yaml.
    /// </summary>
    public sealed class YamlDocumentFilter : IDocumentFilter
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="YamlDocumentFilter"/>.
        /// </summary>
        /// <param name="hostingEnvironment">Proporciona información sobre el entorno de alojamiento web que se ejecuta una aplicación.</param>
        public YamlDocumentFilter(IWebHostEnvironment hostingEnvironment)
        => HostingEnvironment = hostingEnvironment;

        private IWebHostEnvironment HostingEnvironment { get; }

        /// <inheritdoc/>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            try
            {
                var builder = new SerializerBuilder();

                builder.WithNamingConvention(CamelCaseNamingConvention.Instance);

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

            public override IEnumerable<IPropertyDescriptor> GetProperties(Type type, object? container)
            {
                return typeInspector.GetProperties(type, container).Where(p => p.Name != "extensions" && p.Name != "operation-id");
            }
        }
    }
}