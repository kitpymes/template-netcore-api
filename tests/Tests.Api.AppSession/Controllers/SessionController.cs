using Kitpymes.Core.Shared.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Kitpymes.Core.Security;
using System.Security.Claims;
using System;
using Kitpymes.Core.Shared;
using Kitpymes.Core.Api;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Tests.Api.AppSession.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly IJsonWebTokenService _jsonWebTokenService;

        public SessionController(IJsonWebTokenService jsonWebTokenService)
        {
            _jsonWebTokenService = jsonWebTokenService;
        }

        [HttpGet("login")]
        public IResult Login()
        {
            if (!string.IsNullOrWhiteSpace(Kitpymes.Core.Api.AppSession.Key))
            {
                return Result.BadRequest($"El usuario ya se encuentra logueado.");
            }

            var userSession = new UserSession
            {
                Id = Guid.NewGuid(),
                Email = "admin@gmail.com",
                Role = "Admin",
                Permissions = new string[] { "View", "Create", "Edit", "Delete" }
            };

            Kitpymes.Core.Api.AppSession.Key = Guid.NewGuid().ToString("N");

            var claims = new List<Claim>
            {
                new Claim(nameof(UserSession), userSession.ToSerialize()),
            };

            var jsonWebTokenResult = _jsonWebTokenService.Create(claims);

            var getJsonWebTokenResult = _jsonWebTokenService.Get(jsonWebTokenResult.Token);

            var result = Result<GetJsonWebTokenResult>.Ok(getJsonWebTokenResult);

            result.Message = "Agregar el token para poder ingresar a las rutas que contienen el atributo Authorize: https://localhost:5001/api/session";

            result.Details = $"Authorization: Bearer {jsonWebTokenResult.Token}";

            return result;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IResult Get()
        {
            return Result<object>.Ok(new
            {
                Kitpymes.Core.Api.AppSession.Tenant,
                Kitpymes.Core.Api.AppSession.User,
            });
        }
    }
}
