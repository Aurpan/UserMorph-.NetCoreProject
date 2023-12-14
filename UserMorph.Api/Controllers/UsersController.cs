using UserMorph.Core.DTOs.DomainModels;
using Microsoft.AspNetCore.Mvc;
using UserMorph.Services;

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

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetUsers() 
        {
            var userList = _service.GetUsers().ToList();

            return Ok(userList);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id) 
        { 
            var user = users.Find(x => x.Id == id);

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(User user) 
        { 
            user.Id = users.Count() + 1;
            users.Add(user);

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
