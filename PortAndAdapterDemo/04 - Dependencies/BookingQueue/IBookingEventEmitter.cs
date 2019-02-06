using Domain;
using System.Threading.Tasks;

namespace BookingQueue
{
    public interface IBookingEventEmitter
    {
        Task EnqueBookingEvent(BookingEvent bookingEvent);
    }
}
