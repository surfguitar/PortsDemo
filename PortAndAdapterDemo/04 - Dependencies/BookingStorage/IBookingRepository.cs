using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingStorage
{
    public interface IBookingRepository
    {
        Task CreateBookingAsync(Booking booking);
        Task UpdateBooking(Booking booking);
        IEnumerable<Booking> GetBookings();
    }
}
