using Api;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly BookingManageApplication _bookingManageApplication;

        public BookingController(BookingManageApplication bookingManageApplication)
        {
            _bookingManageApplication = bookingManageApplication;
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            var bookings = _bookingManageApplication.GetBookings().ToList();
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(DateTime appointmentTime)
        {
            //Should take a DTO that maps to domain object IRL!

            var booking = new Booking(appointmentTime, new HealthInstitution(Guid.Parse("1CE7DC77-5E3B-4BA0-A0E4-0D25B23A9C11"), "Scapellkliniken", "skärgatan 777", "08-66666", DateTime.UtcNow), new Person(Guid.Parse("F27C6B18-2853-4250-AF1E-9E4371A1B12A"), "Jörgen Katz", "jorge@katz.com"));
            await _bookingManageApplication.CreateBooking(booking);

            return Ok(booking);
        }

        [HttpPut]
        public async Task<IActionResult> SetBookingInActive(Booking booking)
        {
            await _bookingManageApplication.SetBookingInactive(booking);
            return Ok();
        }
    }
}
