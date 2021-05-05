// -----------------------------------------------------------------------
// <copyright file="SpaSettings.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Api
{
    public class SpaSettings
    {
        private bool _enabledAngular, _proxyToSpaDevelopmentServe = false;

        private string 
            _rootPath = "Frontend", 
            _sourcePath = "dist", 
            _npmScript = "start", 
            _proxyBaseUri = "https://localhost:4200";

        public bool? EnabledAngular
        {
            get => _enabledAngular;
            set
            {
                if (value.HasValue)
                {
                    _enabledAngular = value.Value;
                }
            }
        }

        public bool? EnabledProxyToSpaDevelopmentServe
        {
            get => _proxyToSpaDevelopmentServe;
            set
            {
                if (value.HasValue)
                {
                    _proxyToSpaDevelopmentServe = value.Value;
                }
            }
        }

        public string? RootPath
        {
            get => _rootPath; 
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _rootPath = value;
                }
            }
        }

        public string? SourcePath
        {
            get => _sourcePath; 
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _sourcePath = value;
                }
            }
        }

        public string? NpmScript
        {
            get => _npmScript; 
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _npmScript = value;
                }
            }
        }

        public string? ProxyBaseUri
        {
            get => _proxyBaseUri; 
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _proxyBaseUri = value;
                }
            }
        }
    }
}
