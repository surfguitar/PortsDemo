using Domain;
using System;

namespace BookingStorage
{
    public interface IBookingStorage
    {
        void CreateBooking(Booking booking);
    }
}
