// -----------------------------------------------------------------------
// <copyright file="AppTenantSettings.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System.Collections.Generic;

    /*
       Clase de configuración AppTenantSettings
       Contiene las propiedades para la configuración de los inquilinos
    */

    /// <summary>
    /// Clase de configuración <c>AppTenantSettings</c>.
    /// Contiene las propiedades para la configuración de los inquilinos.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para la configuración de los inquilinos.</para>
    /// </remarks>
    public class AppTenantSettings
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
        /// Obtiene o establece un valor que indica los inquilinos de la aplicación.
        /// </summary>
        public List<Entities.TenantSession> Tenants { get; set; } = new List<Entities.TenantSession>();
    }
}
