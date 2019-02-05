using Domain;
using System;

namespace BookingStorage
{
    public interface IBookingRepository
    {
        void CreateBooking(Booking booking);
        void UpdateBooking(Booking booking);
    }
}
