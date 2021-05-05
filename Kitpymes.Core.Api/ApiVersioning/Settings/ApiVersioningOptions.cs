// -----------------------------------------------------------------------
// <copyright file="ApiVersioningOptions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using Microsoft.AspNetCore.Mvc.Versioning;
    using Microsoft.AspNetCore.Mvc.Versioning.Conventions;

    /*
       Clase de configuración ApiVersioningOptions
       Contiene las propiedades para la configuración del versionado de la api
    */

    /// <summary>
    /// Clase de configuración <c>ApiVersioningOptions</c>.
    /// Contiene las propiedades para la configuración del versionado de la api.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para la del versionado de la api.</para>
    /// </remarks>
    public class ApiVersioningOptions
    {
        /// <summary>
        /// Obtiene la configuración del versionado de la api.
        /// </summary>
        public ApiVersioningSettings ApiVersioningSettings { get; private set; } = new ApiVersioningSettings();

        /// <summary>
        /// Obtiene o establece un valor que indica el servicio esta habilitado.
        /// </summary>
        /// <param name="enabled">Habilita o desabilita.</param>
        /// <returns>EncryptorOptions.</returns>
        public ApiVersioningOptions WithEnabled(bool enabled = true)
        {
            ApiVersioningSettings.Enabled = enabled;

            return this;
        }

        /// <summary>
        /// Indica la versión mayor de la api.
        /// <para><strong>Default:</strong> 1.</para>
        /// </summary>
        /// <param name="version">Numero de versión.</param>
        /// <returns>ApiVersioningOptions.</returns>
        public ApiVersioningOptions WithMajorVersion(int version = ApiVersioningSettings.DefaultMajorVersion)
        {
            ApiVersioningSettings.MajorVersion = version;

            return this;
        }

        /// <summary>
        /// Indica la versión menor de la api.
        /// <para><strong>Default:</strong> 0.</para>
        /// </summary>
        /// <param name="version">Numero de versión.</param>
        /// <returns>ApiVersioningOptions.</returns>
        public ApiVersioningOptions WithMinorVersion(int version = ApiVersioningSettings.DefaultMinorVersion)
        {
            ApiVersioningSettings.MinorVersion = version;

            return this;
        }

        /// <summary>
        /// Indica si se utiliza la versión por defecto si no se especifica ninguna.
        /// <para><strong>Default:</strong> true.</para>
        /// </summary>
        /// <param name="assume">Si se asume o no.</param>
        /// <returns>ApiVersioningOptions.</returns>
        public ApiVersioningOptions WithAssumeDefaultVersionWhenUnspecified(bool assume = ApiVersioningSettings.DefaultAssumeDefaultVersionWhenUnspecified)
        {
            ApiVersioningSettings.AssumeDefaultVersionWhenUnspecified = assume;

            return this;
        }

        /// <summary>
        /// Indica si las solicitudes HTTP informan sobre el estado de la versión de la API.
        /// Los encabezados HTTP "api-supported-versions" y "api-deprecated-versions" se agregarán a todas las rutas de servicio válidas.
        /// Esta información es útil para anunciar qué versiones son soportadas y cuales quedaron en desuso.
        /// <para><strong>Default:</strong> true.</para>
        /// </summary>
        /// <param name="report">Si se reporta el estado o no.</param>
        /// <returns>ApiVersioningOptions.</returns>
        public ApiVersioningOptions WithReportApiVersions(bool report = ApiVersioningSettings.DefaultReportApiVersions)
        {
            ApiVersioningSettings.ReportApiVersions = report;

            return this;
        }

        /// <summary>
        /// Indica si el parámetro de versión de API debe sustituirse en las plantillas de ruta.
        /// <para><strong>Default:</strong> true.</para>
        /// </summary>
        /// <param name="substitute">Si se debe sustituir o no.</param>
        /// <returns>ApiVersioningOptions.</returns>
        public ApiVersioningOptions WithSubstituteApiVersionInUrl(bool substitute = ApiVersioningSettings.DefaultSubstituteApiVersionInUrl)
        {
            ApiVersioningSettings.SubstituteApiVersionInUrl = substitute;

            return this;
        }

        /// <summary>
        /// Indica el formato utilizado para crear nombres de grupos a partir de versiones de API.
        /// <para><strong>Default:</strong> "'v'VVV".</para>
        /// </summary>
        /// <param name="nameFormat">Nombre del formato de grupo.</param>
        /// <returns>ApiVersioningOptions.</returns>
        public ApiVersioningOptions WithGroupNameFormat(string nameFormat = ApiVersioningSettings.DefaultGroupNameFormat)
        {
            ApiVersioningSettings.GroupNameFormat = nameFormat;

            return this;
        }

        /// <summary>
        /// Indica el lector de la versión de la API del servicio.
        /// <list type="bullet">
        /// <item>
        /// <term>Microsoft.AspNetCore.Mvc.Versioning.QueryStringApiVersionReader</term>
        /// <description>solo lee la versión de la API del parámetro del query string "api-version"</description>
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
        /// <para><strong>Default:</strong> UrlSegmentApiVersionReader.</para>
        /// </summary>
        /// <param name="apiVersionReader">Nombre del formato de grupo.</param>
        /// <returns>ApiVersioningOptions.</returns>
        public ApiVersioningOptions WithApiVersionReader(IApiVersionReader apiVersionReader)
        {
            ApiVersioningSettings.ApiVersionReader = apiVersionReader;

            return this;
        }

        /// <summary>
        /// Agrega la configuración de los endpoints de los controladores.
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
        /// <param name="conventions">Configuración.</param>
        /// <returns>ApiVersioningOptions.</returns>
        public ApiVersioningOptions WithConventions(IApiVersionConventionBuilder conventions)
        {
            ApiVersioningSettings.Conventions = conventions;

            return this;
        }
    }
}
