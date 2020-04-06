using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Babylife.Core.Entities;
using BabyLife.Api.Helpers;
using BabyLife.Api.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BabyLife.Api.Accounts
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService accountsService;
        private readonly AppSettings _appSettings;

        public AccountsController(IAccountsService accountsService, IOptions<AppSettings> appSettings)
        {
            this.accountsService = accountsService;
            _appSettings = appSettings.Value;
        }


        [HttpPost("register")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public IActionResult Register([FromBody]RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    PersonType = Role.User
                };

                // create user
                var u = accountsService.Create(user, model.Password);

                return Ok(u);
            }

            return BadRequest(new { message = "User is not registered" });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody]LoginModel model)
        {
            var user = accountsService.GetByUseremailAndPassword(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}