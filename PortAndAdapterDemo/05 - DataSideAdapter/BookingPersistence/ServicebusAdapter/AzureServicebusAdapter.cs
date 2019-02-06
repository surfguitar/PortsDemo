using BookingQueue;
using Domain;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ServicebusAdapter
{
    public class AzureServicebusAdapter : IBookingEventEmitter
    {
        private readonly string _serviceBusConnectionString;
        public AzureServicebusAdapter(string serviceBusConnectionString)
        {
            _serviceBusConnectionString = serviceBusConnectionString;
        }
       
        const string QueueName = "booking-log";

        public async Task EnqueBookingEvent(BookingEvent bookingEvent)
        {
            var queueClient = new QueueClient(_serviceBusConnectionString, QueueName);
            string messageBody = JsonConvert.SerializeObject(bookingEvent);
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));
            Console.WriteLine($"Sending message");
            
            await queueClient.SendAsync(message);
        }
    }
}
