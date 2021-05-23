// -----------------------------------------------------------------------
// <copyright file="SpaSettings.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    /*
      Clase de configuraci�n SpaSettings
      Contiene las propiedades para la configuraci�n de las applicaciones de una sola p�gina
    */

    /// <summary>
    /// Clase de configuraci�n <c>SpaSettings</c>.
    /// Contiene las propiedades para la configuraci�n de las applicaciones de una sola p�gina.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para las applicaciones de una sola p�gina.</para>
    /// </remarks>
    public class SpaSettings
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
        /// Obtiene o establece la configuraci�n de angular.
        /// </summary>
        public AngularSettings? AngularSettings { get; set; }
    }
}
