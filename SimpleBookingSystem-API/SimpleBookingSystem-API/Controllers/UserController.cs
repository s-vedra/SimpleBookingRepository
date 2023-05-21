using Microsoft.AspNetCore.Mvc;
using SimpleBookingSystem_Exceptions;
using SimpleBookingSystem_Services.Abstraction;

namespace SimpleBookingSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("user/{id}")]
        public IActionResult Login([FromRoute] int id)
        {
            try
            {
                var user = _userService.GetUser(id);
                return Ok(user);
            }
            catch (CoreException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong, please try again later");
            }
        }
    }
}
