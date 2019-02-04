using System;

namespace Domain
{
    public class HealthInstitution
    {
        public HealthInstitution(string institutionName, string address, string phone)
        {
            Id = Guid.NewGuid();
            InsitutionName = institutionName;
            Address = address;
            Phone = phone;
            CreatedAt = DateTime.UtcNow;
        }

        public HealthInstitution(Guid id, string institutionName, string address, string phone, DateTime createdAt)
        {
            Id = id;
            InsitutionName = institutionName;
            Address = address;
            Phone = phone;
            CreatedAt = createdAt;
        }

        public Guid Id { get; }
        public string InsitutionName { get; }
        public string Address { get; }
        public string Phone { get; }
        public DateTime CreatedAt { get; }
    }
}
