using Microsoft.AspNetCore.Mvc;
using SimpleBookingSystem_Exceptions;
using IResourceService = SimpleBookingSystem_Services.Abstraction.IResourceService;

namespace SimpleBookingSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        [Route("resource-list")]
        public IActionResult GetAllResources()
        {
            try
            {
                var resources = _resourceService.GetResources();
                return Ok(resources);
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
