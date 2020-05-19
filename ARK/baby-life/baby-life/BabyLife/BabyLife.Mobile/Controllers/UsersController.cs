using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Users;
using BabyLife.Api.Users.UsersModels;
using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using BabyLife.Mobile.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabyLife.Mobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUsersService usersService;

        public UsersController(IUnitOfWork unitOfWork,
            IUsersService usersService)
        {
            this.unitOfWork = unitOfWork;
            this.usersService = usersService;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await unitOfWork.Users.GetByIDAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userModel = new UserModel()
            {
                UserId = user.Id,
                Birthday = user.Birthdate,
                Email = user.Email,
                ShareCode = user.ShareCode
            };

            return Ok(userModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] string id, [FromBody] EditUserViewModel user)
        {
            user.Id = id;

            var res = await usersService.EditUser(user);
            
            if(res == "Ok")
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}