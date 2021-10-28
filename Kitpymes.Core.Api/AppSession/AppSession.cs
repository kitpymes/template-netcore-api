// -----------------------------------------------------------------------
// <copyright file="AppSession.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;

    /// <summary>
    /// Propiedades de la sesión de la aplicación.
    /// </summary>
    public static class AppSession
    {
        /// <summary>
        /// Obtiene o establece un valor que indica la clave de la sesión.
        /// </summary>
        public static string Key { get; set; } = null!;

        /// <summary>
        /// Obtiene o establece un valor que indica si es ambiente de desarrollo.
        /// </summary>
        public static bool IsDevelopment { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si la acplicación esta habilitado para inquilinos.
        /// </summary>
        public static bool IsMultitenancy { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si existe un usuario autenticado.
        /// </summary>
        public static bool IsUserAutenticated { get; set; }

        /// <summary>
        /// Obtiene o establece el usuario.
        /// </summary>
        public static UserSession? User { get; set; }

        /// <summary>
        /// Obtiene o establece el inquilino.
        /// </summary>
        public static TenantSession? Tenant { get; set; }
    }
}
