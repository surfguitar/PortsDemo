using Domain;
using System;
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

        public void CreateBooking(Booking booking)
        {
            _manageBookingController.CreateBooking(booking);
        }
    }
}
