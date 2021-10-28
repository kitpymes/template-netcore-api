// -----------------------------------------------------------------------
// <copyright file="TenantSession.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;
    using Kitpymes.Core.Entities;

    /*
        Clase para la sesión del inquilino TenantSession
        Propiedades y atributos del inquilino
    */

    /// <summary>
    /// Clase para la sesión del inquilino <c>TenantSession</c>.
    /// Propiedades y atributos del inquilino.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades y atributos para la sesión del inquilino.</para>
    /// </remarks>
    public class TenantSession : TenantSession<Guid>
    {
        /// <summary>
        /// Nombre de la clave del inquilino.
        /// </summary>
        public const string KeyName = "x-tenant-key";
    }
}
