using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BookingEvent
    {
        public BookingEvent(Guid bookingId, BookingEventTypeEnum type, DateTime createdAt)
        {
            BookingId = bookingId;
            BookingEventTypeEnum = type;
            CreatedAt = createdAt;
        }

        public Guid BookingId { get; }
        public BookingEventTypeEnum BookingEventTypeEnum { get; }
        public DateTime CreatedAt { get; }
    }
}
