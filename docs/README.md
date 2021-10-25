# <img src="https://github.com/kitpymes/template-netcore-api/raw/master/docs/images/logo.png" height="30px"> Kitpymes.Core.Api

**Extensiones y herramientas comunes utilizadas por la Api**

[![Build Status](https://github.com/kitpymes/template-netcore-api/workflows/Kitpymes.Core.Api/badge.svg)](https://github.com/kitpymes/template-netcore-api/actions)
[![NuGet Status](https://img.shields.io/nuget/v/Kitpymes.Core.Api)](https://www.nuget.org/packages/Kitpymes.Core.Api/)
[![NuGet Download](https://img.shields.io/nuget/dt/Kitpymes.Core.Api)](https://www.nuget.org/stats/packages/Kitpymes.Core.Api?groupby=Version)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://github.com/kitpymes/template-netcore-api/blob/master/docs/LICENSE.txt)
[![Size Repo](https://img.shields.io/github/repo-size/kitpymes/template-netcore-api)](https://github.com/kitpymes/template-netcore-api/)
[![Last Commit](https://img.shields.io/github/last-commit/kitpymes/template-netcore-api)](https://github.com/kitpymes/template-netcore-api/)

## 📋 Requerimientos 

* Visual Studio >= 2019

* NET TargetFramework >= net5.0

* Net Core SDK >= 5.0.100

* C# >= 9.0

* Conocimientos sobre Inyección de Dependencias

## 🔧 Instalación 

_Se puede instalar usando el administrador de paquetes Nuget o CLI dotnet._

_Nuget_

```
Install-Package Kitpymes.Core.Api
```

_CLI dotnet_

```
dotnet add package Kitpymes.Core.Api
```

## ⌨️ Código


### ApiVersioning

```cs
public static class ApiVersioningApplicationBuilderExtensions
{
    public static IApplicationBuilder LoadApiVersioning(this IApplicationBuilder application)
    { }
}
```

```cs
public static class ApiVersioningServiceCollectionExtensions
{
    public static IServiceCollection LoadApiVersioning(
        this IServiceCollection services,
        IConfiguration configuration,
        IApiVersionReader? apiVersionReader = null,
        IApiVersionConventionBuilder? conventions = null)
    { }

    public static IServiceCollection LoadApiVersioning(
            this IServiceCollection services,
            Action<ApiVersioningOptions> options)
    { }

    public static IServiceCollection LoadApiVersioning(
        this IServiceCollection services,
        ApiVersioningSettings settings)
    { }
}
```

```cs
public class ApiVersioningOptions
{
    public ApiVersioningOptions WithEnabled(bool enabled)
    { }

    public ApiVersioningOptions WithMajorVersion(int version)
    { }

    public ApiVersioningOptions WithMinorVersion(int version)
    { }

    public ApiVersioningOptions WithAssumeDefaultVersionWhenUnspecified(bool assume)
    { }

    public ApiVersioningOptions WithReportApiVersions(bool report)
    { }

    public ApiVersioningOptions WithSubstituteApiVersionInUrl(bool substitute)
    { }

    public ApiVersioningOptions WithGroupNameFormat(string nameFormat)
    { }

    public ApiVersioningOptions WithApiVersionReader(IApiVersionReader apiVersionReader)
    { }

    public ApiVersioningOptions WithConventions(IApiVersionConventionBuilder conventions)
    { }
}
```

```cs
public class ApiVersioningSettings
{
    public bool? Enabled { get;  set; }

    public int? MajorVersion { get;  set; }

    public int? MinorVersion { get;  set; }

    public bool? AssumeDefaultVersionWhenUnspecified { get;  set; }

    public bool? ReportApiVersions { get;  set; }

    public bool? SubstituteApiVersionInUrl { get;  set; }

    public string? GroupNameFormat { get;  set; }

    [JsonIgnore]
    public IApiVersionReader? ApiVersionReader { get;  set; }

    [JsonIgnore]
    public IApiVersionConventionBuilder? Conventions { get;  set; }
}
```

```cs
public enum ApiVersioningStatus
{
    Alpha,

    Beta,

    RC,

    Stable,
}
```

### AppSession

_AppTenant_

```cs
public static class AppTenantApplicationBuilderExtensions
{
    public static IApplicationBuilder LoadAppTenant(this IApplicationBuilder application)
    { }
}
```

```cs
public static class AppTenantServiceCollectionExtensions
{
    public static IServiceCollection LoadAppTenant(
        this IServiceCollection services,
        Action<AppTenantOptions> options)
    { }

    public static IServiceCollection LoadAppTenant(
        this IServiceCollection services,
        AppTenantSettings settings)
    { }
}
```

```cs
public class AppTenantMiddleware
{
    public AppTenantMiddleware(RequestDelegate requestDelegate) => RequestDelegate = requestDelegate;

    private RequestDelegate RequestDelegate { get; }

    public async Task InvokeAsync(HttpContext httpContext)
    { }
}
```

```cs
public class AppTenantOptions
{
    public AppTenantOptions WithEnabled(bool enabled = true)
    { }

    public AppTenantOptions WithTenant(Entities.TenantSession tenant)
    { }

    public AppTenantOptions WithTenants(params Entities.TenantSession[] tenants)
    { }
}
```

```cs
public class AppTenantSettings
{
    public bool? Enabled { get;  set; }

    public List<Entities.TenantSession> Tenants { get; set; } = new List<Entities.TenantSession>();
}
```


_AppUser_

```cs
public static class AppUserApplicationBuilderExtensions
{
    public static IApplicationBuilder LoadAppUser(this IApplicationBuilder application)
    { }
}
```

```cs
public static class AppUserServiceCollectionExtensions
{
    public static IServiceCollection LoadAppUser(
        this IServiceCollection services,
        Action<AppUserOptions> options)
    { }

    public static IServiceCollection LoadAppUser(
        this IServiceCollection services,
        AppUserSettings settings)
    { }
}
```

```cs
public class AppUserMiddleware
{
    public AppUserMiddleware(RequestDelegate requestDelegate) => RequestDelegate = requestDelegate;

    private RequestDelegate RequestDelegate { get; }

    public async Task InvokeAsync(HttpContext httpContext)
    { }
}
```

```cs
public class AppUserOptions
{
    public AppUserOptions WithEnabled(bool enabled = true)
    { }

    public AppUserOptions WithUser(Entities.UserSession user)
    { }
}
```

```cs
public class AppUserSettings
{
    public bool? Enabled { get; set; }

    public Entities.UserSession User { get; set; } = new Entities.UserSession();
}
```


### Host

```cs
public static class InitHost
{
    public static async Task RunAsync<TStartup>(string[] args)
        where TStartup : class
    { }

    public static IHost Build<TStartup>(string[] args)
        where TStartup : class
    { }

    public static IHostBuilder Custom<TStartup>(string[] args)
        where TStartup : class
    { }
}
```


### Result

```cs
public class AspNetResult : IActionResult
{
    public AspNetResult(IResult result) => Result = result;

    private IResult Result { get; }

    public async Task ExecuteResultAsync(ActionContext context)
    { }
}
```


### Spa

```cs
public static class SpaApplicationBuilderExtensions
{
    public static IApplicationBuilder LoadSpa(
        this IApplicationBuilder application,
        Action<AngularOptions> options)
    { }

    public static IApplicationBuilder LoadSpa(
        this IApplicationBuilder application,
        AngularSettings settings)
    { }
}
```

```cs
public static class SpaServiceCollectionExtensions
{
    public static IServiceCollection LoadSpa(
        this IServiceCollection services,
        string rootPath = DefaultRootPath)
    { }
}
```

```cs
public abstract class SpaBaseSettings
{
    public bool? { get; set; }

    public string? SourcePath { get; set; }

    public string? NpmScript { get; set; }

    public string? BaseUri { get; set; }
}
```

```cs
public class SpaOptions
{
    public SpaOptions WithEnabled(bool enabled = true)
    { }

    public SpaOptions WithAngular(Action<AngularOptions> options)
    { }

    public SpaOptions WithAngular(AngularSettings settings)
    { }
}
```

```cs
public class SpaSettings
{
    public bool? Enabled { get; set; }

    public AngularSettings? AngularSettings { get; set; }
}
```

```cs
public class AngularOptions
{
    public AngularOptions WithEnabled(bool enabled = true)
    { }

    public AngularOptions WithSourcePath(string sourcePath = AngularSettings.DefaultSourcePath)
    { }

    public AngularOptions WithNpmScript(string npmScript = AngularSettings.DefaultNpmScript)
    { }

    public AngularOptions WithBaseUri(string baseUri = AngularSettings.DefaultBaseUri)
    { }
}
```

```cs
public class AngularSettings : SpaBaseSettings
{ }
```


### Swagger

```cs
public static class SwaggerApplicationBuilderExtensions
{
    public static IApplicationBuilder LoadSwagger(this IApplicationBuilder application)
    { }
}
```

```cs
public static class SwaggerOperationFilterContextExtensions
{
    public static IEnumerable<TAttribute> GetControllerAndActionAttributes<TAttribute>(this OperationFilterContext context) 
        where TAttribute : Attribute
    { }
}
```

```cs
public static class SwaggerServiceCollectionExtensions
{
    public static IServiceCollection LoadSwagger(
        this IServiceCollection services,
        Action<SwaggerOptions> options)
    { }

    public static IServiceCollection LoadSwagger(
        this IServiceCollection services,
        SwaggerSettings settings)
    { }
}
```

```cs
public class ApiExplorerDocumentFilter : IDocumentFilter
{
    public ApiExplorerDocumentFilter(IOptions<ApiExplorerOptions> options)
    {  }

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {  }
}
```

```cs
public class AuthorizationBearerFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    { }
}
```

```cs
public sealed class DefaultValuesFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    { }
}
```

```cs
public sealed class StatusCodesFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    { }
}
```

```cs
public sealed class SupportedLanguagesFilter : IOperationFilter
{
    public SupportedLanguagesFilter(IServiceProvider serviceProvider) 
    { }

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    { }
}
```

```cs
public sealed class YamlDocumentFilter : IDocumentFilter
{
    private IWebHostEnvironment HostingEnvironment { get; }

    public YamlDocumentFilter(IWebHostEnvironment hostingEnvironment)
    { }

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    { }
}
```

```cs
public class ContactSettings
{
    public string? Name { get; set; }

    public string? Url { get; set; }

    public string? Email { get; set; }
}
```

```cs
public class LicenseSettings
{
    public string? Name { get; set; }

    public string? Url { get; set; }
}
```

```cs
public class SecuritySettings
{
    public string? Title { get; set; }

    public string? Name { get; set; }

    public string? Scheme { get; set; }

    public string? Description { get; set; }

    public int? ParameterLocation { get; set; }

    public int? SecurityType { get; set; }
}
```

```cs
public class SwaggerOptions
{
    public SwaggerOptions WithEnabled(bool enabled = true)
    { }

    public SwaggerOptions WithRoutePrefix(string routePrefix)
    { }

    public SwaggerOptions WithVersion(string version)
    { }

    public SwaggerOptions WithTitle(string title)
    { }

    public SwaggerOptions WithDescription(string description)
    { }

    public SwaggerOptions WithTermsOfServiceUrl(string url)
    { }

    public SwaggerOptions WithContact(ContactSettings contact)
    { }

    public SwaggerOptions WithLicense(LicenseSettings license)
    { }

    public SwaggerOptions WithSecurity(SecuritySettings security)
    { }

    public SwaggerOptions WithXmlComments(Assembly assembly)
    { }
}
```

```cs
public class SwaggerSettings
{
    public bool? Enabled { get; set; }

    public string? RoutePrefix { get; set; }

    public string? Version { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? TermsOfServiceUrl { get; set; }

    public ContactSettings Contact { get; set; } = new ContactSettings();

    public LicenseSettings License { get; set; } = new LicenseSettings();

    public SecuritySettings Security { get; set; } = new SecuritySettings();

    public Assembly? XmlComments { get; set; }

    [JsonIgnore]
    public string RoutePrefixWithSlash => string.IsNullOrWhiteSpace(RoutePrefix) ? string.Empty : RoutePrefix + "/";
}
```

## 🛠️ Construido con 

* [NET Core](https://dotnet.microsoft.com/download) - Framework de trabajo
* [C#](https://docs.microsoft.com/es-es/dotnet/csharp/) - Lenguaje de programación
* [Inserción de dependencias](https://docs.microsoft.com/es-es/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0) - Patrón de diseño de software
* [Postman](https://docs.microsoft.com/es-es/aspnet/core/tutorials/first-web-api) - Pruebas unitarias API REST
* [Nuget](https://www.nuget.org/) - Manejador de dependencias
* [Visual Studio](https://visualstudio.microsoft.com/) - Entorno de programacion


## ✒️ Autores 

* **Sebastian R Ferrari** - *Trabajo Inicial* - [kitpymes](https://kitpymes.com)


## 📄 Licencia 

* Este proyecto está bajo la Licencia [LICENSE](LICENSE.txt)


## 🎁 Gratitud 

* Este proyecto fue diseñado para compartir, creemos que es la mejor forma de ayudar 📢
* Cada persona que contribuya sera invitada a tomar una 🍺 
* Gracias a todos! 🤓

---
[Kitpymes](https://github.com/kitpymes) 😊