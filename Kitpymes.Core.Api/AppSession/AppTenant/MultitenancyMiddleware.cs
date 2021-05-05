// -----------------------------------------------------------------------
// <copyright file="MultitenancyMiddleware.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System.Linq;
    using System.Threading.Tasks;
    using Kitpymes.Core.Entities;
    using Kitpymes.Core.Shared;
    using Microsoft.AspNetCore.Http;

    public class MultitenancyMiddleware
    {
        private RequestDelegate Request { get; }

        public MultitenancyMiddleware(RequestDelegate request)
        {
            Request = request;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext != null)
            {
                if (httpContext.User.ToIsAuthenticated())
                {
                    AppSession.Tenant = httpContext.User.ToGet<TenantSession>(nameof(TenantSession));
                }
                else
                {
                    var settings = (MultitenancySettings)httpContext.RequestServices.GetService(typeof(MultitenancySettings));

                    if (settings?.Enabled == true)
                    {
                        var subdomain = httpContext.Request.ToSubdomain().ToIsSubdomainThrow(nameof(TenantSession.Subdomain));

                        var tenant = settings.Tenants.First(x => x.Subdomain == subdomain);

                        tenant.Subdomain.ToIsNullOrEmptyThrow(nameof(subdomain));

                        AppSession.Tenant = new TenantSession
                        {
                            Enabled = settings.Enabled.Value,
                            Id = tenant.Id,
                            Subdomain = tenant.Subdomain,
                        };
                    }
                }

                await Request(httpContext).ConfigureAwait(false);
            }
        }
    }
}