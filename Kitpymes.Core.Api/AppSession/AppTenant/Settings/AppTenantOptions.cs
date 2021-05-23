// -----------------------------------------------------------------------
// <copyright file="AppTenantOptions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    /*
       Clase de configuración AppTenantOptions
       Contiene las propiedades para la configuración de los inquilinos
    */

    /// <summary>
    /// Clase de configuración <c>AppTenantOptions</c>.
    /// Contiene las propiedades para la configuración de los inquilinos.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para la configuración de los inquilinos.</para>
    /// </remarks>
    public class AppTenantOptions
    {
        /// <summary>
        /// Obtiene la configuración de los inquilinos.
        /// </summary>
        public AppTenantSettings TenantSettings { get; private set; } = new AppTenantSettings();

        /// <summary>
        /// Obtiene o establece un valor que indica el servicio esta habilitado.
        /// </summary>
        /// <param name="enabled">Habilita o desabilita.</param>
        /// <returns>AppTenantOptions.</returns>
        public AppTenantOptions WithEnabled(bool enabled = true)
        {
            TenantSettings.Enabled = enabled;

            return this;
        }

        /// <summary>
        /// Agrega un inquilino.
        /// </summary>
        /// <param name="tenant">Nuevo inquilino.</param>
        /// <returns>AppTenantOptions.</returns>
        public AppTenantOptions WithTenant(Entities.TenantSession tenant)
        {
            TenantSettings.Tenants.Add(tenant);

            return this;
        }

        /// <summary>
        /// Agrega un inquilino.
        /// </summary>
        /// <param name="tenants">Nuevos inquilinos.</param>
        /// <returns>AppTenantOptions.</returns>
        public AppTenantOptions WithTenants(params Entities.TenantSession[] tenants)
        {
            TenantSettings.Tenants.AddRange(tenants);

            return this;
        }
    }
}
