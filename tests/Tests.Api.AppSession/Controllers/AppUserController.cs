using Kitpymes.Core.Shared.Util;
using Kitpymes.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Kitpymes.Core.Security;
using System.Security.Claims;
using System;
using Kitpymes.Core.Shared;

namespace Tests.Api.AppSession.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppUserController : ControllerBase
    {
        private IJsonWebTokenService _jsonWebTokenService;

        public AppUserController(IJsonWebTokenService jsonWebTokenService)
        => _jsonWebTokenService = jsonWebTokenService;

        [HttpPost("login")]
        public IResult Login()
        {
            var jsonWebTokenResult = _jsonWebTokenService
                .Create(new Claim[] {
                    new Claim(nameof(UserSession), new UserSession
                    {
                         Id = Guid.NewGuid().ToString("N"),
                         Email = "user_1@gmail.com",
                         Role = "Admin",
                         Permissions = new string[] { "View", "Create", "Edit", "Delete" }
                    }.ToSerialize())
                });

            return Result<string>.Ok(jsonWebTokenResult.Token);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IResult Get()
        => Result<UserSession>.Ok(Kitpymes.Core.Entities.AppSession.User);
    }
}
