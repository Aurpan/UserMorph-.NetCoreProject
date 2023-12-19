using UserMorph.Core.DTOs.DomainModels;
using Microsoft.AspNetCore.Mvc;
using UserMorph.Core.Interfaces.Domain;
using FluentValidation;
using UserMorph.Core.Enums;
using UserMorph.Core.ApplicationExceptions;
using UserMorph.Api.Responses;

namespace UserMorph.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IValidator<User> _userValidator;

        public UsersController(IUserService service, IValidator<User> userValidator)
        {
            _service = service;
            _userValidator = userValidator;
        }

        [HttpGet]
        public IActionResult GetUsers(DataSourceType dataSourceType, string searchText = "~") 
        {
            var userList = _service.GetUsers(dataSourceType, searchText).ToList();
            var response = new ApiResponse<List<User>>()
            {
                IsSuccess = true,
                Data = userList,
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id, DataSourceType dataSourceType) 
        {
            var response = new ApiResponse<User>();
            try
            {
                var user = _service.GetUserDetailsById(id, dataSourceType);

                response.IsSuccess = true;
                response.Data = user;
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (NotFoundException ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                response.StatusCode = StatusCodes.Status204NoContent;
            }
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateUser(User user) 
        {
            var validationResult = _userValidator.Validate(user);

            if (!validationResult.IsValid)
            {
                var errorResponse = new ApiResponse<List<string>>();
                errorResponse.StatusCode = StatusCodes.Status400BadRequest;
                errorResponse.IsSuccess = false;
                errorResponse.Data = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return BadRequest(errorResponse);
            }

            _service.CreateUser(user);

            return CreatedAtAction(nameof(GetUserById), "Users", new { id = user.Id }, null);
        }

        [HttpPut]
        public IActionResult UpdateUser(User user) 
        {
            var validationResult = _userValidator.Validate(user);
            if (!validationResult.IsValid) 
            {
                var errorResponse = new ApiResponse<List<string>>();
                errorResponse.StatusCode = StatusCodes.Status400BadRequest;
                errorResponse.IsSuccess = false;
                errorResponse.Data = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return BadRequest(errorResponse);
            }

            _service.UpdateUser(user);  

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id) 
        {
            var response = new ApiResponse<User>();
            try
            {
                _service.DeleteUser(id);

                response.IsSuccess = true;
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (NotFoundException ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                response.StatusCode = StatusCodes.Status404NotFound;

                return BadRequest(response);
            }
            
            return NoContent();
        }
    }
}
