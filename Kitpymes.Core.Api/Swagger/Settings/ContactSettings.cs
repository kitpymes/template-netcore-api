// -----------------------------------------------------------------------
// <copyright file="ContactSettings.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    /*
       Clase de configuración ContactSettings
       Contiene las propiedades para la configuración de la información de contacto para swagger
    */

    /// <summary>
    /// Clase de configuración <c>ContactSettings</c>.
    /// Contiene las propiedades para la configuración de la información de contacto para swagger.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para la configuración de la información de contacto para swagger.</para>
    /// </remarks>
    public class ContactSettings
    {
        /// <summary>
        /// Obtiene o establece un valor que indica el nombre del contacto.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica la url del contacto.
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica el email del contacto.
        /// </summary>
        public string? Email { get; set; }
    }
}
