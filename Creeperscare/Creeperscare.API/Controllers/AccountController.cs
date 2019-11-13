using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Creeperscare.DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Creeperscare.Entities;
using Creeperscare.API.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Creeperscare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly CreeperscareDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(CreeperscareDbContext creeperscareDbContext, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _context = creeperscareDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task RegisterAsync([FromBody] UserRegisterRequestModel userRegisterRequestModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = userRegisterRequestModel.Email,
                    UserName = userRegisterRequestModel.Email,
                    Role = userRegisterRequestModel.Role
                };
                var result = await _userManager.CreateAsync(user, userRegisterRequestModel.Password);
                if (result.Succeeded)
                {
                    await Login(new AuthModel
                    {
                        Email = userRegisterRequestModel.Email,
                        Password = userRegisterRequestModel.Password
                    });
                }
                else
                {
                    await Response.WriteAsync("Result validation failed!");
                }
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task Login([FromBody] AuthModel model)
        {
            await _signInManager.PasswordSignInAsync(model.Email, model.Password, true,
                false);

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role),

                        // 
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

        [HttpPost("logout")]
        public async Task LogOff()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
