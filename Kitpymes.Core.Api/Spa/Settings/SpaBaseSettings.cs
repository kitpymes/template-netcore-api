// -----------------------------------------------------------------------
// <copyright file="SpaBaseSettings.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    /*
      Clase de configuración SpaBaseSettings
      Contiene las propiedades para la configuración de las applicaciones de una sola página
    */

    /// <summary>
    /// Clase de configuración <c>SpaBaseSettings</c>.
    /// Contiene las propiedades para la configuración de las applicaciones de una sola página.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para las applicaciones de una sola página.</para>
    /// </remarks>
    public abstract class SpaBaseSettings
    {
        /// <summary>
        /// Valor por defecto que indica si esta habilitado el servicio.
        /// </summary>
        public const bool DefaultEnabled = false;

        /// <summary>
        /// Valor por defecto que indica la ruta del proyecto.
        /// </summary>
        public const string DefaultSourcePath = "ClientApp";

        /// <summary>
        /// Valor por defecto que indica el script de inicio del servidor.
        /// </summary>
        public const string DefaultNpmScript = "start";

        /// <summary>
        /// Valor por defecto que indica el proxy base de la url de inicio del servidor.
        /// </summary>
        public const string DefaultBaseUri = "https://localhost:4200";

        private bool _enabled = DefaultEnabled;

        private string _sourcePath = DefaultSourcePath;

        private string _npmScript = DefaultNpmScript;

        private string _baseUri = DefaultBaseUri;

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
        /// Obtiene o establece un valor que indica la ruta del proyecto.
        /// <para><strong>Default:</strong> <see cref="DefaultSourcePath"/> = "dist".</para>
        /// </summary>
        public string? SourcePath
        {
            get => _sourcePath;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _sourcePath = value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece un valor que indica el script de inicio del servidor.
        /// <para><strong>Default:</strong> <see cref="DefaultNpmScript"/> = "start".</para>
        /// </summary>
        public string? NpmScript
        {
            get => _npmScript;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _npmScript = value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece un valor que indica el proxy base de la url de inicio del servidor.
        /// <para><strong>Default:</strong> <see cref="DefaultBaseUri"/> = "https://localhost:4200".</para>
        /// </summary>
        public string? BaseUri
        {
            get => _baseUri;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _baseUri = value;
                }
            }
        }
    }
}
