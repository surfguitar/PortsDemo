using BookingStorage;
using Domain;
using System;

namespace BookingSqlAdapter
{
    public class BookingRepository : IBookingRepository
    {
        private readonly string _connectionString;

        public BookingRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public void UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
