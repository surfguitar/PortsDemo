using System;

namespace Domain
{
    public class Booking
    {
        public Booking(DateTime appointmentTime, HealthInstitution healthInstitution, Person person)
        {
            Id = Guid.NewGuid();
            AppointmentTime = appointmentTime;
            HealthInstitution = healthInstitution;
            Person = person;
            IsActive = true;
        }

        public Booking(Guid id, DateTime appointmentTime, HealthInstitution healthInstitution, Person person)
        {
            Id = id;
            AppointmentTime = appointmentTime;
            HealthInstitution = healthInstitution;
            Person = person;
        }

        public void SetBookingActive()
        {
            IsActive = true;
        }

        public void SetBookingInActive()
        {
            IsActive = false;
        }

        public Guid Id  { get; }
        public DateTime AppointmentTime { get; }
        public HealthInstitution HealthInstitution { get; }
        public Person Person { get; }
        public bool IsActive { get; private set; }

    }
}
