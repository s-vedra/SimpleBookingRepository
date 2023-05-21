using Microsoft.AspNetCore.Mvc;
using SimpleBookingSystem_DTO;
using SimpleBookingSystem_Exceptions;
using SimpleBookingSystem_Services.Abstraction;

namespace SimpleBookingSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        [Route("book-resource")]
        public IActionResult SaveBooking([FromBody] BookingDTO booking)
        {
            try
            {
                booking.ValidateBooking();
                _bookingService.SaveBookingAndSendEmailToAdmin(booking);
                return Ok();
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
