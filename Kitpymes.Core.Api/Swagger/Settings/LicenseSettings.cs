// -----------------------------------------------------------------------
// <copyright file="LicenseSettings.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    /*
       Clase de configuración LicenseSettings
       Contiene las propiedades para la configuración de la información de licencia para swagger
    */

    /// <summary>
    /// Clase de configuración <c>LicenseSettings</c>.
    /// Contiene las propiedades para la configuración de la información de licencia para swagger.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para la configuración de la información de licencia para swagger.</para>
    /// </remarks>
    public class LicenseSettings
    {
        /// <summary>
        /// Obtiene o establece un valor que indica el nombre de la licencia.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica el url de la licencia.
        /// </summary>
        public string? Url { get; set; }
    }
}
