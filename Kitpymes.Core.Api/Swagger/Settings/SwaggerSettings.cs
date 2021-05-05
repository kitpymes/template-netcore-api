using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Kitpymes.Core.Api
{
    public class SwaggerSettings
    {
        [JsonIgnore] private List<string> _xmlCommentsPaths { get; set; } = new List<string>();
        [JsonIgnore] public IReadOnlyCollection<string> XmlCommentsPaths => _xmlCommentsPaths.AsReadOnly();

        public void AddXmlComments(params Assembly[] assemblys)
        {
            foreach (var assembly in assemblys)
            {
                var xmlFile = $"{assembly.GetName().Name}.xml";

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                if (File.Exists(xmlPath))
                {
                    _xmlCommentsPaths.Add(xmlPath);
                }
            }
        }

        [JsonIgnore] public string RoutePrefixWithSlash => 
            string.IsNullOrWhiteSpace(RoutePrefix) ? string.Empty : RoutePrefix + "/";

        public string? RoutePrefix { get; set; }
        public string? Version { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? TermsOfServiceUrl { get; set; }
        public ContactSettings Contact { get; set; } = new ContactSettings();
        public LicenseSettings License { get; set; } = new LicenseSettings();
    }
}
