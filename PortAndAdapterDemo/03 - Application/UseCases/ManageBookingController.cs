using BookingStorage;
using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UseCases
{
    public class ManageBookingController
    {
        private readonly IBookingRepository _bookingRepository;

        public ManageBookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task CreateBooking(Booking booking)
        {
           await _bookingRepository.CreateBookingAsync(booking);
        }

        public void SetBookingInactive(Booking booking)
        {
            booking.SetBookingInActive();
            _bookingRepository.UpdateBooking(booking);
        }

        public IEnumerable<Booking> GetBookings()
        {
            return _bookingRepository.GetBookings();
        }
    }
}
