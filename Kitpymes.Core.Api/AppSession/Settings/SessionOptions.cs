// -----------------------------------------------------------------------
// <copyright file="SessionOptions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    /*
       Clase de configuración SessionOptions
       Contiene las propiedades para la configuración de la sesión
    */

    /// <summary>
    /// Clase de configuración <c>SessionOptions</c>.
    /// Contiene las propiedades para la configuración de la sesión.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para la configuración de la sesión.</para>
    /// </remarks>
    public class SessionOptions
    {
        /// <summary>
        /// Obtiene la configuración de la sesión.
        /// </summary>
        public SessionSettings SessionSettings { get; private set; } = new SessionSettings();

        /// <summary>
        /// Obtiene o establece un valor que indica el servicio esta habilitado.
        /// </summary>
        /// <param name="enabled">Habilita o desabilita.</param>
        /// <returns>SessionOptions.</returns>
        public SessionOptions WithEnabled(bool enabled = true)
        {
            SessionSettings.Enabled = enabled;

            return this;
        }

        /// <summary>
        /// Obtiene o establece un valor que indica si la aplicación acepta inquilinos.
        /// </summary>
        /// <param name="enabled">Habilita o desabilita.</param>
        /// <returns>SessionOptions.</returns>
        public SessionOptions WithMultitenancy(bool enabled = true)
        {
            SessionSettings.IsMultitenancy = enabled;

            return this;
        }

        /// <summary>
        /// Para agregar inquilinos.
        /// </summary>
        /// <param name="tenants">Nuevos inquilinos.</param>
        /// <returns>SessionOptions.</returns>
        public SessionOptions WithTenants(params TenantSession[] tenants)
        {
            SessionSettings.Tenants.AddRange(tenants);

            return this;
        }
    }
}
