// -----------------------------------------------------------------------
// <copyright file="ApiVersioningStatus.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    /// <summary>
    /// Estado de la versión de la api.
    /// </summary>
    public enum ApiVersioningStatus
    {
        /// <summary>
        /// Primera versión, no segura.
        /// <para><strong>Alpha release</strong></para>
        /// </summary>
        Alpha,

        /// <summary>
        /// Segunda versión, donde se corrijen errores de la versión anterior, se agregan nuevas caracteristicas y se hacen pruebas.
        /// <para><strong>Beta release</strong></para>
        /// </summary>
        Beta,

        /// <summary>
        /// Tercera versión, donde se realizan mas pruebas exhaustivas.
        /// <para><strong>Candidate release</strong></para>
        /// </summary>
        RC,

        /// <summary>
        /// Ultima versión, es la versión estable.
        /// <para><strong>Stable release</strong></para>
        /// </summary>
        Stable,
    }
}
