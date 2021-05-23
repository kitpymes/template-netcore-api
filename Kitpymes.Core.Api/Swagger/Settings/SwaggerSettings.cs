// -----------------------------------------------------------------------
// <copyright file="SwaggerSettings.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System.Reflection;
    using System.Text.Json.Serialization;

    /*
        Clase de configuración SwaggerSettings
        Contiene las propiedades para la configuración de swagger
    */

    /// <summary>
    /// Clase de configuración <c>SwaggerSettings</c>.
    /// Contiene las propiedades para la configuración de swagger.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para la configuración de swagger.</para>
    /// </remarks>
    public class SwaggerSettings
    {
        /// <summary>
        /// Valor por defecto que indica si esta habilitado el servicio.
        /// </summary>
        public const bool DefaultEnabled = false;

        private bool _enabled = DefaultEnabled;

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
        /// Obtiene o establece un valor que indica el prefijo de la url de swagger.
        /// <para><strong>- Ejemplo:</strong></para>
        /// <para>
        ///     http://localhost:{port}/{route_prefix}/swagger/v1/swagger.json.
        /// </para>
        /// </summary>
        public string? RoutePrefix { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica la versión de la api.
        /// </summary>
        public string? Version { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica el titulo.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica la descripción.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica la url de terminos de uso.
        /// </summary>
        public string? TermsOfServiceUrl { get; set; }

        /// <summary>
        /// Obtiene o establece un valor para la configuración del contacto.
        /// </summary>
        public ContactSettings Contact { get; set; } = new ContactSettings();

        /// <summary>
        /// Obtiene o establece un valor para la configuración de la licencia.
        /// </summary>
        public LicenseSettings License { get; set; } = new LicenseSettings();

        /// <summary>
        /// Obtiene o establece un valor para la configuración de la seguridad de swagger.
        /// </summary>
        public SecuritySettings Security { get; set; } = new SecuritySettings();

        /// <summary>
        /// Obtiene o establece el esamblado de donde se obtienen los comentarios para crear los archivos xml.
        /// </summary>
        public Assembly? XmlComments { get; set; }

        /// <summary>
        /// Obtiene un valor que indica el prefijo con un slash de la url de swagger.
        /// <para><strong>- Ejemplo:</strong></para>
        /// <para>
        ///     http://localhost:{port}/{route_prefix}/swagger/v1/swagger.json.
        /// </para>
        /// </summary>
        [JsonIgnore]
        public string RoutePrefixWithSlash => string.IsNullOrWhiteSpace(RoutePrefix) ? string.Empty : RoutePrefix + "/";
    }
}
