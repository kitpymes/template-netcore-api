// -----------------------------------------------------------------------
// <copyright file="SpaOptions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;
    using Kitpymes.Core.Shared;

    /*
      Clase de configuración SpaOptions
      Contiene las propiedades para la configuración de las applicaciones de una sola página
    */

    /// <summary>
    /// Clase de configuración <c>SpaOptions</c>.
    /// Contiene las propiedades para la configuración de las applicaciones de una sola página.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para las applicaciones de una sola página.</para>
    /// </remarks>
    public class SpaOptions
    {
        /// <summary>
        /// Obtiene la configuración configuración de applicaciones de una sola página.
        /// </summary>
        public SpaSettings SpaSettings { get; private set; } = new SpaSettings();

        /// <summary>
        /// Obtiene o establece un valor que indica el servicio esta habilitado.
        /// </summary>
        /// <param name="enabled">Habilita o desabilita.</param>
        /// <returns>SpaOptions.</returns>
        public SpaOptions WithEnabled(bool enabled = true)
        {
            SpaSettings.Enabled = enabled;

            return this;
        }

        /// <summary>
        /// Obtiene o establece un valor que indica la configuración de angular.
        /// </summary>
        /// <param name="options">Configuración de angular.</param>
        /// <returns>SpaOptions.</returns>
        public SpaOptions WithAngular(Action<AngularOptions> options)
        {
            return WithAngular(options.ToConfigureOrDefault().AngularSettings);
        }

        /// <summary>
        /// Obtiene o establece un valor que indica la configuración de angular.
        /// </summary>
        /// <param name="settings">Configuración de angular.</param>
        /// <returns>SpaOptions.</returns>
        public SpaOptions WithAngular(AngularSettings settings)
        {
            SpaSettings.AngularSettings = settings;

            return this;
        }
    }
}