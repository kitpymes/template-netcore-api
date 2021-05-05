// -----------------------------------------------------------------------
// <copyright file="MultitenancySettings.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class MultitenancySettings
    {
        private bool _enabled = false;

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

        [JsonIgnore] private List<(string Id, string Subdomain)> _tenants { get; set; } = new List<(string Id, string Subdomain)>();
       
        [JsonIgnore] public IReadOnlyCollection<(string Id, string Subdomain)> Tenants => _tenants.AsReadOnly();

        public void AddTenants(params (string Id, string Subdomain)[] tenants)
        => _tenants.AddRange(tenants);
    }
}
