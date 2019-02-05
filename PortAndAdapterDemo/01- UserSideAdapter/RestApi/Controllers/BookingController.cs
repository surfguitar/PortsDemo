using Api;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingManageApplication _bookingManageApplication;

        public BookingController(BookingManageApplication bookingManageApplication)
        {
            _bookingManageApplication = bookingManageApplication;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public IActionResult CreateBooking()
        {
            var booking = new Booking(DateTime.UtcNow, new HealthInstitution("", "", ""), new Person("", ""));
            _bookingManageApplication.CreateBooking(booking);

            return Ok();
        }
    }
}
