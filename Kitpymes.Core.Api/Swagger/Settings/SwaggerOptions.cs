// -----------------------------------------------------------------------
// <copyright file="SwaggerOptions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System.Reflection;

    /*
       Clase de configuración SwaggerOptions
       Contiene las propiedades para la configuración del versionado de la api
    */

    /// <summary>
    /// Clase de configuración <c>SwaggerOptions</c>.
    /// Contiene las propiedades para la configuración del versionado de la api.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las propiedades para la del versionado de la api.</para>
    /// </remarks>
    public class SwaggerOptions
    {
        /// <summary>
        /// Obtiene la configuración del versionado de la api.
        /// </summary>
        public SwaggerSettings SwaggerSettings { get; private set; } = new SwaggerSettings();

        /// <summary>
        /// Obtiene o establece un valor que indica el servicio esta habilitado.
        /// </summary>
        /// <param name="enabled">Habilita o desabilita.</param>
        /// <returns>SwaggerOptions.</returns>
        public SwaggerOptions WithEnabled(bool enabled = true)
        {
            SwaggerSettings.Enabled = enabled;

            return this;
        }

        /// <summary>
        /// Indica el prefijo de la url de swagger.
        /// <para><strong>- Ejemplo:</strong></para>
        /// <para>
        ///     http://localhost:{port}/{route_prefix}/swagger/v1/swagger.json.
        /// </para>
        /// </summary>
        /// <param name="routePrefix">Prefijo de la url.</param>
        /// <returns>SwaggerOptions.</returns>
        public SwaggerOptions WithRoutePrefix(string routePrefix)
        {
            SwaggerSettings.RoutePrefix = routePrefix;

            return this;
        }

        /// <summary>
        /// Indica la versión de la api.
        /// </summary>
        /// <param name="version">Numero de versión.</param>
        /// <returns>SwaggerOptions.</returns>
        public SwaggerOptions WithVersion(string version)
        {
            SwaggerSettings.Version = version;

            return this;
        }

        /// <summary>
        /// Indica el titulo.
        /// </summary>
        /// <param name="title">Título.</param>
        /// <returns>SwaggerOptions.</returns>
        public SwaggerOptions WithTitle(string title)
        {
            SwaggerSettings.Title = title;

            return this;
        }

        /// <summary>
        /// Indica el descripción.
        /// </summary>
        /// <param name="description">Descripción.</param>
        /// <returns>SwaggerOptions.</returns>
        public SwaggerOptions WithDescription(string description)
        {
            SwaggerSettings.Description = description;

            return this;
        }

        /// <summary>
        /// Indica la url de terminos de uso.
        /// </summary>
        /// <param name="url">Url de terminos de uso.</param>
        /// <returns>SwaggerOptions.</returns>
        public SwaggerOptions WithTermsOfServiceUrl(string url)
        {
            SwaggerSettings.TermsOfServiceUrl = url;

            return this;
        }

        /// <summary>
        /// Indica los datos de contacto.
        /// </summary>
        /// <param name="contact">Configuración de contacto.</param>
        /// <returns>SwaggerOptions.</returns>
        public SwaggerOptions WithContact(ContactSettings contact)
        {
            SwaggerSettings.Contact = contact;

            return this;
        }

        /// <summary>
        /// Indica los datos de licencia.
        /// </summary>
        /// <param name="license">Configuración de licencia.</param>
        /// <returns>SwaggerOptions.</returns>
        public SwaggerOptions WithLicense(LicenseSettings license)
        {
            SwaggerSettings.License = license;

            return this;
        }

        /// <summary>
        /// Indica los datos de seguridad.
        /// </summary>
        /// <param name="security">Configuración de seguridad.</param>
        /// <returns>SwaggerOptions.</returns>
        public SwaggerOptions WithSecurity(SecuritySettings security)
        {
            SwaggerSettings.Security = security;

            return this;
        }

        /// <summary>
        /// Indica el ensamblado del que queremos incluir los comentarios xml.
        /// </summary>
        /// <param name="assembly">El esamblado que queremos incluir para los comentarios.</param>
        /// <returns>SwaggerOptions.</returns>
        public SwaggerOptions WithXmlComments(Assembly assembly)
        {
            SwaggerSettings.XmlComments = assembly;

            return this;
        }
    }
}