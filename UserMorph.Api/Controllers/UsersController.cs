
using UserMorph.Core.DTOs.DomainModels;
using Microsoft.AspNetCore.Mvc;
using UserMorph.Core.Interfaces.Domain;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using UserMorph.Core.Enums;

namespace UserMorph.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        static List<User> users = new List<User>()
        {
            new User
            {
                Id = 1,
                FirstName = "Aurpan"
            },
            new User
            {
                Id = 2,
                FirstName = "Darshan"
            }

        };

        private readonly IUserService _service;
        private readonly IValidator<User> _userValidator;

        public UsersController(IUserService service, IValidator<User> userValidator)
        {
            _service = service;
            _userValidator = userValidator;
        }

        [HttpGet]
        public IActionResult GetUsers(DataSourceType dataSourceType) 
        {
            var userList = _service.GetUsers(dataSourceType).ToList();

            return Ok(userList);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id, DataSourceType dataSourceType) 
        { 
            var user = _service.GetUserDetailsById(id, dataSourceType);

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(User user) 
        {
            var validationResult = _userValidator.Validate(user);

            if (validationResult.IsValid)
            {

            }

            return CreatedAtAction(nameof(GetUserById), "Users", new { id = user.Id }, null);
        }

        [HttpPut]
        public IActionResult UpdateUser(User user) 
        {
            var domainUser = users.Find(x => x.Id == user.Id);

            domainUser.FirstName = user.FirstName;

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id) 
        {
            var userIndex = users.FindIndex(x => x.Id == id);

            users.RemoveAt(userIndex);

            return NoContent();
        }
    }
}
