using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BabyLife.Api.Accounts;
using BabyLife.Api.Accounts.AccountsModel;
using BabyLife.Core.Entities;
using BabyLife.Mobile.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace BabyLife.Mobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountsService accountsService;
        private readonly UserManager<User> _userManager;

        public AccountController(IAccountsService accountsService,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.accountsService = accountsService;
            _userManager = userManager;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task RegisterAsync([FromBody] RegisterViewModel registerViewModel)
        {
            var result = await accountsService.Register(registerViewModel);

            if (result != null)
            {
                await Login(new LoginViewModel
                {
                    Email = registerViewModel.Email,
                    Password = registerViewModel.Password
                });
            }
            else
            {
                await Response.WriteAsync("Result validation failed!");
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task Login([FromBody] LoginViewModel model)
        {
            await accountsService.Login(model);

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    };

                    var jwtSecurityToken = new JwtSecurityToken(
                        issuer: AuthOptions.Issuer,
                        audience: AuthOptions.Audience,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)),
                        signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthOptions.Key)),
                            SecurityAlgorithms.HmacSha256));
                    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                    var response = new
                    {
                        access_token = encodedJwt,
                        userid = user.Id
                    };

                    Response.ContentType = "application/json";
                    await Response.WriteAsync(JsonConvert.SerializeObject(response,
                        new JsonSerializerSettings { Formatting = Formatting.Indented }));
                    return;
                }

                await Response.WriteAsync("Wrong credentials!");
            }
        }
    }
}