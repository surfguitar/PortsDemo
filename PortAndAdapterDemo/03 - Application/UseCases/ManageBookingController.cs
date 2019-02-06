using BookingQueue;
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
        private readonly IBookingEventEmitter _bookingEventEmitter;

        public ManageBookingController(IBookingRepository bookingRepository, IBookingEventEmitter bookingEventEmitter)
        {
            _bookingRepository = bookingRepository;
            _bookingEventEmitter = bookingEventEmitter;
        }

        public async Task CreateBooking(Booking booking)
        {
           await _bookingRepository.CreateBookingAsync(booking);
           await _bookingEventEmitter.EnqueBookingEvent(new BookingEvent(booking.Id, BookingEventTypeEnum.Created, DateTime.UtcNow));
        }

        public async Task SetBookingInactive(Booking booking)
        {
            booking.SetBookingInActive();
            await _bookingRepository.UpdateBooking(booking);
            await _bookingEventEmitter.EnqueBookingEvent(new BookingEvent(booking.Id, BookingEventTypeEnum.Updated, DateTime.UtcNow));

        }

        public IEnumerable<Booking> GetBookings()
        {
            return _bookingRepository.GetBookings();
        }
    }
}
