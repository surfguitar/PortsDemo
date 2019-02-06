using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UseCases;

namespace Api
{
    public class BookingManageApplication
    {
        private readonly ManageBookingController _manageBookingController;

        public BookingManageApplication(ManageBookingController manageBookingController)
        {
            _manageBookingController = manageBookingController;
        }

        public async Task CreateBooking(Booking booking)
        {
            await _manageBookingController.CreateBooking(booking);
        }

        public void SetBookingInactive(Booking booking)
        {
            _manageBookingController.SetBookingInactive(booking);
        }

        public IEnumerable<Booking> GetBookings()
        {
            return _manageBookingController.GetBookings();
        }
    }
}
