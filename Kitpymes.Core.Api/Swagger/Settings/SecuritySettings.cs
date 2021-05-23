// -----------------------------------------------------------------------
// <copyright file="SecuritySettings.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;
    using Microsoft.OpenApi.Models;

    /*
       Clase de configuración SecuritySettings
       Contiene las propiedades para la configuración de la información de seguridad para swagger
    */

    /// <summary>
    /// Clase de configuración <c>SecuritySettings</c>.
    /// Contiene las propiedades para la configuración de la información de seguridad para swagger.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para la configuración de la información de seguridad para swagger.</para>
    /// </remarks>
    public class SecuritySettings
    {
        /// <summary>
        /// Valor por defecto que indica el nombre de la definición de seguridad.
        /// </summary>
        public const string DefaultTitle = "Authorization_Bearer";

        /// <summary>
        /// Valor por defecto que indica el nombre de la definición de seguridad del esquema.
        /// </summary>
        public const string DefaultName = "Authorization";

        /// <summary>
        /// Valor por defecto que indica el nombre del tipo de esquema de seguridad.
        /// </summary>
        public const string DefaultScheme = "Bearer";

        /// <summary>
        /// Valor por defecto que indica la descripción del tipo de esquema de seguridad.
        /// </summary>
        public const string DefaultDescription = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer xxxxxxxxxx\"";

        /// <summary>
        /// Valor por defecto que indica la ubicación del parametro a enviar a la api.
        /// </summary>
        public const int DefaultParameterLocation = 1;

        /// <summary>
        /// Valor por defecto que indica el tipo de seguridad utilizada.
        /// </summary>
        public const int DefaultSecurityType = 0;

        private string _title = DefaultTitle;

        private string _name = DefaultName;

        private string _scheme = DefaultScheme;

        private string _description = DefaultDescription;

        private int _parameterLocation = DefaultParameterLocation;

        private int _securityType = DefaultSecurityType;

        /// <summary>
        /// Obtiene o establece un valor que indica el nombre de la definición de seguridad.
        /// <para><strong>Default:</strong> <see cref="DefaultTitle"/> = "Authorization_Bearer".</para>
        /// </summary>
        public string? Title
        {
            get => _title;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _title = value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece un valor que indica el nombre de la definición de seguridad del esquema.
        /// <para><strong>Default:</strong> <see cref="DefaultName"/> = "Authorization".</para>
        /// </summary>
        public string? Name
        {
            get => _name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece un valor que indica el nombre del tipo de esquema de seguridad.
        /// <para><strong>Default:</strong> <see cref="DefaultScheme"/> = "Bearer".</para>
        /// </summary>
        public string? Scheme
        {
            get => _scheme;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _scheme = value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece un valor que indica el nombre del tipo de esquema de seguridad.
        /// <para><strong>Default:</strong> <see cref="DefaultDescription"/> = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer xxxxxxxxxx\"".</para>
        /// </summary>
        public string? Description
        {
            get => _description;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _description = value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece un valor que indica la ubicación del parametro a enviar a la api.
        /// <list type="bullet">
        /// <item>
        /// <description><strong>0 = </strong>Query.</description>
        /// </item>
        /// <item>
        /// <description><strong>1 = </strong>Header.</description>
        /// </item>
        /// <item>
        /// <description><strong>2 = </strong>Path.</description>
        /// </item>
        /// <item>
        /// <description><strong>3 = </strong>Cookie.</description>
        /// </item>
        /// </list>
        /// <para><strong>Default:</strong> <see cref="DefaultParameterLocation"/> = 1.</para>
        /// </summary>
        public int? ParameterLocation
        {
            get => _parameterLocation;
            set
            {
                if (value.HasValue && Enum.IsDefined(typeof(ParameterLocation), value.Value))
                {
                    _parameterLocation = value.Value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece un valor que indica el tipo de seguridad utilizada.
        /// <list type="bullet">
        /// <item>
        /// <description><strong>0 = </strong>ApiKey.</description>
        /// </item>
        /// <item>
        /// <description><strong>1 = </strong>Http.</description>
        /// </item>
        /// <item>
        /// <description><strong>2 = </strong>OAuth2.</description>
        /// </item>
        /// <item>
        /// <description><strong>3 = </strong>OpenIdConnect.</description>
        /// </item>
        /// </list>
        /// <para><strong>Default:</strong> <see cref="DefaultSecurityType"/> = 0.</para>
        /// </summary>
        public int? SecurityType
        {
            get => _securityType;
            set
            {
                if (value.HasValue && Enum.IsDefined(typeof(SecuritySchemeType), value.Value))
                {
                    _securityType = value.Value;
                }
            }
        }
    }
}
