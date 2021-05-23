// -----------------------------------------------------------------------
// <copyright file="AppUserSettings.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    /*
       Clase de configuración AppUserSettings
       Contiene las propiedades para la configuración del usuario logueado
    */

    /// <summary>
    /// Clase de configuración <c>AppUserSettings</c>.
    /// Contiene las propiedades para la configuración del usuario logueado.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para la configuración del usuario logueado.</para>
    /// </remarks>
    public class AppUserSettings
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
        /// Obtiene o establece un valor que indica el usuario logueado.
        /// </summary>
        public Entities.UserSession User { get; set; } = new Entities.UserSession();
    }
}
