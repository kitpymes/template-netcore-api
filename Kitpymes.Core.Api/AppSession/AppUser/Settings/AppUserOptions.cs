// -----------------------------------------------------------------------
// <copyright file="AppUserOptions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    /*
       Clase de configuración AppUserOptions
       Contiene las propiedades para la configuración del usuario logueado
    */

    /// <summary>
    /// Clase de configuración <c>AppUserOptions</c>.
    /// Contiene las propiedades para la configuración del usuario logueado.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para la configuración del usuario logueado.</para>
    /// </remarks>
    public class AppUserOptions
    {
        /// <summary>
        /// Obtiene la configuración del usuario logueado.
        /// </summary>
        public AppUserSettings AppUserSettings { get; private set; } = new AppUserSettings();

        /// <summary>
        /// Obtiene o establece un valor que indica el servicio esta habilitado.
        /// </summary>
        /// <param name="enabled">Habilita o desabilita.</param>
        /// <returns>AppUserOptions.</returns>
        public AppUserOptions WithEnabled(bool enabled = true)
        {
            AppUserSettings.Enabled = enabled;

            return this;
        }

        /// <summary>
        /// Agrega un usuario.
        /// </summary>
        /// <param name="user">Usuario logueado.</param>
        /// <returns>AppUserOptions.</returns>
        public AppUserOptions WithUser(Entities.UserSession user)
        {
            AppUserSettings.User = user;

            return this;
        }
    }
}
