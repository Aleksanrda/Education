using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Babylife.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabyLife.Api.Users
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(User[]), StatusCodes.Status200OK)]
        public IActionResult GetUsers(int skip = 0, int take = 10)
        {
            var usersResult = usersService.GetUsers(skip, take);

            var response = new
            {
                items = usersResult.Items
                .Select(u => new
                {
                    id = u.Id,
                    email = u.Email,
                    name = u.Name,
                    personType = u.PersonType,
                    phoneNumber = u.PhoneNumber
                }),
                totalAmount = usersResult.TotalAmount,
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            //// only allow admins to access other user records
            //var currentUserId = int.Parse(User.Identity.Name);

            //if (id != currentUserId && !User.IsInRole(Role.Admin.ToString()))
            //    return Forbid();

            var user = usersService.GetUserById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}