using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BookingEvent
    {
        public Guid BookingId { get; }
        public BookingEventTypeEnum BookingEventTypeEnum { get; }
        public DateTime CreatedAt { get; }
    }
}
