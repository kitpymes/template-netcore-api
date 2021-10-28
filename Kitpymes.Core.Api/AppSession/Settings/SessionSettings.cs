// -----------------------------------------------------------------------
// <copyright file="SessionSettings.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System.Collections.Generic;

    /*
       Clase de configuración SessionSettings
       Contiene las propiedades para la configuración de la sesión
    */

    /// <summary>
    /// Clase de configuración <c>SessionSettings</c>.
    /// Contiene las propiedades para la configuración de la sesión.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para la configuración de la sesión.</para>
    /// </remarks>
    public class SessionSettings
    {
        /// <summary>
        /// Valor por defecto que indica si esta habilitado el servicio.
        /// </summary>
        public const bool DefaultEnabled = false;

        /// <summary>
        /// Valor por defecto que indica si esta habilitado para inquilinos.
        /// </summary>
        public const bool DefaultMultitenancyEnabled = false;

        private bool _enabled = DefaultEnabled;

        private bool _multitenancyEnabled = DefaultMultitenancyEnabled;

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
        /// Obtiene o establece un valor que indica si la aplicación acepta inquilinos.
        /// <para><strong>Default:</strong> <see cref="DefaultMultitenancyEnabled"/> = false.</para>
        /// </summary>
        public bool? IsMultitenancy
        {
            get => _multitenancyEnabled;
            set
            {
                if (value.HasValue)
                {
                    _multitenancyEnabled = value.Value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece un valor que indica los inquilinos de la aplicación.
        /// </summary>
        public List<TenantSession> Tenants { get; set; } = new ();
    }
}
