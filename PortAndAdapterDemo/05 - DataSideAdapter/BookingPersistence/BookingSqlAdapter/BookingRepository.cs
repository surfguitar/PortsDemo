using BookingStorage;
using Domain;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace BookingSqlAdapter
{
    public class BookingRepository : IBookingRepository
    {
        private readonly string _connectionString;

        public BookingRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task CreateBookingAsync(Booking booking)
        {
            const string sql = "INSERT INTO Booking (Id, HealthInstitutionId, PersonId, AppointmentTime, IsActive) " +
                               "VALUES (@Id, @HealthInstitutionId, @PersonId, @AppointmentTime, @IsActive) ";

            using (var connection = new SqlConnection(_connectionString))
            {
               await connection.OpenAsync();


               await connection.ExecuteAsync(sql,
                    new
                    {
                        Id = booking.Id,
                        HealthInstitutionId = booking.HealthInstitution.Id,
                        PersonId = booking.Person.Id,
                        AppointmentTime = booking.AppointmentTime,
                        IsActive = booking.IsActive
                    });

            }
        }

        public IEnumerable<Booking> GetBookings()
        {
            //const string sql =
            //    @"SELECT B.*, HI.Id AS HealthId, HI.*, P.Id AS PersonId, P.* FROM Booking B, HealthInstitution HI, Person P
            //                    WHERE B.HealthInstitutionId = HI.Id
            //                    AND B.PersonId = P.Id";

            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    connection.Open();

            //    var records = connection.Query(sql);

            //    var bookingsList = new List<Booking>();

            //    foreach (var record in records)
            //    {
            //        bookingsList.Add(new Booking(record.Id, record.AppointmentTime,
            //            new HealthInstitution(record.HealthId, record.InstitutionName, record.Address, record.Phone,
            //                record.CreatedAt), new Person(record.PersonId, record.Name, record.Email)));
            //    }

            //    return bookingsList;
            //}

            var bookingsList = new List<Booking>();

            bookingsList.Add(new Booking(Guid.Parse("9e57aaee-dd6e-4e34-8285-228c649a4f7d"), DateTime.UtcNow,
                                new HealthInstitution(Guid.Parse("1ce7dc77-5e3b-4ba0-a0e4-0d25b23a9c11"), "Slottet", "skärgatan 777",
                                "08-66666", DateTime.UtcNow),
                                new Person(Guid.Parse("f27c6b18-2853-4250-af1e-9e4371a1b12a"), "Jörgen Katz", "jorgen@katz.com")));

            return bookingsList;
        }

        public async Task UpdateBooking(Booking booking)
        {
            const string sql = "UPDATE Booking SET IsActive = @IsActive WHERE Id = @Id";
                            
            using (var connection = new SqlConnection(_connectionString))
            {
                 await connection.OpenAsync();

                 await connection.ExecuteAsync(sql,
                     new
                     {
                         Id = booking.Id,
                         IsActive = booking.IsActive
                     });

            }
        }
    }
}
