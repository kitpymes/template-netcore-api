// -----------------------------------------------------------------------
// <copyright file="ApiVersioningSettings.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System.Text.Json.Serialization;
    using Microsoft.AspNetCore.Mvc.Versioning;
    using Microsoft.AspNetCore.Mvc.Versioning.Conventions;

    /*
       Clase de configuración ApiVersioningSettings
       Contiene las propiedades para la configuración del versionado de la api
    */

    /// <summary>
    /// Clase de configuración <c>ApiVersioningSettings</c>.
    /// Contiene las propiedades para la configuración del versionado de la api.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para el versionado de la api.</para>
    /// </remarks>
    public class ApiVersioningSettings
    {
        /// <summary>
        /// Valor por defecto que indica si esta habilitado el servicio.
        /// </summary>
        public const bool DefaultEnabled = false;

        /// <summary>
        /// Valor por defecto que indica la versión mayor de la api.
        /// </summary>
        public const int DefaultMajorVersion = 1;

        /// <summary>
        /// Valor por defecto que indica la versión menor de la api.
        /// </summary>
        public const int DefaultMinorVersion = 0;

        /// <summary>
        /// Valor por defecto que indica si se utiliza la versión por defecto si no se especifica ninguna.
        /// </summary>
        public const bool DefaultAssumeDefaultVersionWhenUnspecified = true;

        /// <summary>
        /// Valor por defecto que indica si las solicitudes HTTP informan sobre el estado de la versión de la API.
        /// </summary>
        public const bool DefaultReportApiVersions = true;

        /// <summary>
        /// Valor por defecto que indica si el parámetro de versión de API debe sustituirse en las plantillas de ruta.
        /// </summary>
        public const bool DefaultSubstituteApiVersionInUrl = true;

        /// <summary>
        /// Valor por defecto que indica el formato utilizado para crear nombres de grupos a partir de versiones de API.
        /// </summary>
        public const string DefaultGroupNameFormat = "'v'VVV";

        private bool _enabled = DefaultEnabled;
        private int _majorVersion = DefaultMajorVersion;
        private int _minorVersion = DefaultMinorVersion;
        private bool _assumeDefaultVersionWhenUnspecified = DefaultAssumeDefaultVersionWhenUnspecified;
        private bool _reportApiVersions = DefaultReportApiVersions;
        private bool _substituteApiVersionInUrl = DefaultSubstituteApiVersionInUrl;
        private string _groupNameFormat = DefaultGroupNameFormat;
        private IApiVersionReader _apiVersionReader = new HeaderApiVersionReader("api-version");

        /// <summary>
        /// Obtiene o establece un valor que indica el servicio esta habilitado.
        /// <para><strong>Default:</strong> <see cref="DefaultEnabled"/> = false.</para>
        /// </summary>
        public bool? Enabled
        {
            get => _enabled;
            set
            {
                if (value.HasValue)
                {
                    _enabled = value.Value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la versión mayor de la api.
        /// <para><strong>Default:</strong> <see cref="DefaultMajorVersion"/> = 1.</para>
        /// </summary>
        public int? MajorVersion
        {
            get => _majorVersion;
            set
            {
                if (value.HasValue)
                {
                    _majorVersion = value.Value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la versión menor de la api.
        /// <para><strong>Default:</strong> <see cref="DefaultMinorVersion"/> = 0.</para>
        /// </summary>
        public int? MinorVersion
        {
            get => _minorVersion;
            set
            {
                if (value.HasValue)
                {
                    _minorVersion = value.Value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece si se utiliza la versión por defecto si no se especifica ninguna.
        /// <para><strong>Default:</strong> <see cref="DefaultAssumeDefaultVersionWhenUnspecified"/> = true.</para>
        /// </summary>
        public bool? AssumeDefaultVersionWhenUnspecified
        {
            get => _assumeDefaultVersionWhenUnspecified;
            set
            {
                if (value.HasValue)
                {
                    _assumeDefaultVersionWhenUnspecified = value.Value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece si las solicitudes HTTP informan sobre el estado de la versión de la API.
        /// Los encabezados HTTP "api-supported-versions" y "api-deprecated-versions" se agregarán a todas las rutas de servicio válidas.
        /// Esta información es útil para anunciar qué versiones son soportadas y cuales quedaron en desuso.
        /// <para><strong>Default:</strong> <see cref="DefaultReportApiVersions"/> = true.</para>
        /// </summary>
        public bool? ReportApiVersions
        {
            get => _reportApiVersions;
            set
            {
                if (value.HasValue)
                {
                    _reportApiVersions = value.Value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece si el parámetro de versión de API debe sustituirse en las plantillas de ruta.
        /// <para><strong>Default:</strong> <see cref="DefaultSubstituteApiVersionInUrl"/> = true.</para>
        /// </summary>
        public bool? SubstituteApiVersionInUrl
        {
            get => _substituteApiVersionInUrl;
            set
            {
                if (value.HasValue)
                {
                    _substituteApiVersionInUrl = value.Value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece si el formato utilizado para crear nombres de grupos a partir de versiones de API.
        /// <para><strong>Default:</strong> <see cref="DefaultGroupNameFormat"/> = "'v'VVV".</para>
        /// </summary>
        public string? GroupNameFormat
        {
            get => _groupNameFormat;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _groupNameFormat = value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el lector de la versión de la API del servicio.
        /// <list type="bullet">
        /// <item>
        /// <term>Microsoft.AspNetCore.Mvc.Versioning.QueryStringApiVersionReader</term>
        /// <description>solo lee la versión de la API del parámetro del query string "api-version".</description>
        /// </item>
        /// <item>
        /// <term>Microsoft.AspNetCore.Mvc.Versioning.HeaderApiVersionReader</term>
        /// <description>lee la versión de la API a partir de información adicional del encabezado HTTP.</description>
        /// </item>
        /// <item>
        /// <term>Microsoft.AspNetCore.Mvc.Versioning.UrlSegmentApiVersionReader</term>
        /// <description>lee el valor de un segmento de la ruta URL.</description>
        /// </item>
        /// <item>
        /// <term>Microsoft.AspNetCore.Mvc.Versioning.MediaTypeApiVersionReader</term>
        /// <description>lee el valor de un encabezado HTTP de tipo de media.</description>
        /// </item>
        /// </list>
        /// <para><strong>Default:</strong> new HeaderApiVersionReader("api-version").</para>
        /// </summary>
        [JsonIgnore]
        public IApiVersionReader? ApiVersionReader
        {
            get => _apiVersionReader;
            set
            {
                if (value != null)
                {
                    _apiVersionReader = value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la configuración de los endpoints de los controladores.
        /// <para><strong>Ejemplos:</strong></para>
        /// <para>var conventions = new ApiVersionConventionBuilder();.</para>
        /// <list type="number">
        /// <item>
        /// <description>conventions.Controller{HomeV1Controller}().HasApiVersion(new ApiVersion(1, 0, ApiVersioningStatus.Alpha.ToString()));.</description>
        /// </item>
        /// <item>
        /// <description>conventions.Controller{HomeV2Controller}().HasApiVersion(new ApiVersion(2, 0));.</description>
        /// </item>
        /// <item>
        /// <description>
        ///     conventions.Controller{HomeV3Controller}()
        ///         <br/> .HasDeprecatedApiVersion(3, 0)
        ///         <br/> .HasApiVersion(3, 1)
        ///         <br/> .HasApiVersion(4, 0)
        ///         <br/> .Action(c => c.Get3_0()).MapToApiVersion(3, 0)
        ///         <br/> .Action(c => c.Get3_1()).MapToApiVersion(3, 1)
        ///         <br/> .Action(c => c.Get4_0()).MapToApiVersion(4, 0);
        /// </description>
        /// </item>
        /// </list>
        /// <para><strong>Default:</strong> null.</para>
        /// </summary>
        [JsonIgnore]
        public IApiVersionConventionBuilder? Conventions { get;  set; }
    }
}
