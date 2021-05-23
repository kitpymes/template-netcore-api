// -----------------------------------------------------------------------
// <copyright file="AngularOptions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    /*
      Clase de configuración AngularSettings
      Contiene las propiedades para la configuración de angular
    */

    /// <summary>
    /// Clase de configuración <c>AngularSettings</c>.
    /// Contiene las propiedades para la configuración de las applicaciones de angular.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para las applicaciones de angular.</para>
    /// </remarks>
    public class AngularOptions
    {
        /// <summary>
        /// Obtiene la configuración configuración de angular.
        /// </summary>
        public AngularSettings AngularSettings { get; private set; } = new AngularSettings();

        /// <summary>
        /// Obtiene o establece un valor que indica el servicio esta habilitado.
        /// </summary>
        /// <param name="enabled">Habilita o desabilita.</param>
        /// <returns>AngularOptions.</returns>
        public AngularOptions WithEnabled(bool enabled = true)
        {
            AngularSettings.Enabled = enabled;

            return this;
        }

        /// <summary>
        /// Obtiene o establece un valor que indica la ruta del proyecto.
        /// </summary>
        /// <param name="sourcePath">Ruta del proyecto.</param>
        /// <returns>AngularOptions.</returns>
        public AngularOptions WithSourcePath(string sourcePath = AngularSettings.DefaultSourcePath)
        {
            AngularSettings.SourcePath = sourcePath;

            return this;
        }

        /// <summary>
        /// Obtiene o establece un valor que indica el script de inicio del servidor.
        /// </summary>
        /// <param name="npmScript">Script de inicio del servidor.</param>
        /// <returns>AngularOptions.</returns>
        public AngularOptions WithNpmScript(string npmScript = AngularSettings.DefaultNpmScript)
        {
            AngularSettings.NpmScript = npmScript;

            return this;
        }

        /// <summary>
        /// Obtiene o establece un valor que indica el proxy base de la url de inicio del servidor.
        /// </summary>
        /// <param name="baseUri">Ruta base del inicio del servidor.</param>
        /// <returns>AngularOptions.</returns>
        public AngularOptions WithBaseUri(string baseUri = AngularSettings.DefaultBaseUri)
        {
            AngularSettings.BaseUri = baseUri;

            return this;
        }
    }
}