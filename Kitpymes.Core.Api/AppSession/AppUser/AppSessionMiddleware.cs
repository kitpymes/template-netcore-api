// -----------------------------------------------------------------------
// <copyright file="AppSessionMiddleware.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System.Threading.Tasks;
    using Kitpymes.Core.Entities;
    using Kitpymes.Core.Shared;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Hosting;

    public class AppSessionMiddleware
    {
        private RequestDelegate Request { get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AppSessionMiddleware"/>.
        /// </summary>
        /// <param name="request"></param>
        public AppSessionMiddleware(RequestDelegate request)
        {
            Request = request;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext != null)
            {
                var environment = httpContext.RequestServices.ToEnvironment();

                AppSession.IsDevelopment = environment?.IsDevelopment() ?? true;

                if (httpContext.User.ToIsAuthenticated())
                {
                    AppSession.User = httpContext.User.ToGet<UserSession>(nameof(UserSession));
                }

                await Request(httpContext).ConfigureAwait(false);
            }
        }
    }
}