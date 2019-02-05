using BookingStorage;
using Domain;
using System;

namespace UseCases
{
    public class ManageBookingController
    {
        private readonly IBookingRepository _bookingRepository;

        public ManageBookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public void CreateBooking(Booking booking)
        {
            _bookingRepository.CreateBooking(booking);
        }

        public void UpdateBooking(Booking booking)
        {
            _bookingRepository.UpdateBooking(booking);
        }
    }
}
