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
                _bookingService.SaveBooking(booking);
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

        [HttpDelete]
        [Route("cancel-booking/{id}")]
        public IActionResult CancelBooking([FromRoute] int id)
        {
            try
            {
                _bookingService.CancelBookingAndRemoveDateRange(id);
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

        [HttpPost]
        [Route("update-booking")]
        public IActionResult UpdateBookingOrDateRange([FromBody] BookingDTO bookingDto)
        {
            try
            {
                _bookingService.UpdateBookingOrDateRange(bookingDto);
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

        [HttpGet]
        [Route("bookings/user/{id}")]
        public IActionResult GetBookingsByUser([FromRoute] int id)
        {
            try
            {
                var bookings = _bookingService.GetAllBookings(id);
                return Ok(bookings);
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
