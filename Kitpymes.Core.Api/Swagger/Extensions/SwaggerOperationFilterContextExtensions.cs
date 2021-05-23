// -----------------------------------------------------------------------
// <copyright file="SwaggerOperationFilterContextExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary>
    /// Extensión de los filtros del contexto.
    /// </summary>
    public static class SwaggerOperationFilterContextExtensions
    {
        /// <summary>
        /// Obtiene el atributo de un controlador o acción.
        /// </summary>
        /// <typeparam name="TAttribute">Tipo de atributo.</typeparam>
        /// <param name="context">Contexto del filtro de operacion.</param>
        /// <returns>IEnumerable{TAttribute}.</returns>
        public static IEnumerable<TAttribute> GetControllerAndActionAttributes<TAttribute>(this OperationFilterContext context)
            where TAttribute : Attribute
        {
            var controllerAttributes = context?.MethodInfo.DeclaringType?.GetTypeInfo().GetCustomAttributes<TAttribute>();

            var actionAttributes = context?.MethodInfo.GetCustomAttributes<TAttribute>();

            return controllerAttributes.Concat(actionAttributes);
        }
    }
}
