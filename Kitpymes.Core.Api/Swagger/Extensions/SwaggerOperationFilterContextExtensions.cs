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

    public static class SwaggerOperationFilterContextExtensions
    {
        public static IEnumerable<TAttribute> GetControllerAndActionAttributes<TAttribute>(this OperationFilterContext context) 
            where TAttribute : Attribute
        {
            var controllerAttributes = context?.MethodInfo.DeclaringType?.GetTypeInfo().GetCustomAttributes<TAttribute>();

            var actionAttributes = context?.MethodInfo.GetCustomAttributes<TAttribute>();

            return controllerAttributes.Concat(actionAttributes);
        }
    }
}
