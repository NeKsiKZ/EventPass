using System;

namespace Ordering.Domain.Models
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public decimal TotalPrice { get; private set; }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string AddressLine { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public DateTime OrderDate { get; private set; }
        public string Status { get; private set; }

        protected Order() { }

        public Order(Guid userId, string firstName, string lastName, string email, string address, string country, string zipCode, decimal totalPrice)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = email;
            AddressLine = address;
            Country = country;
            ZipCode = zipCode;
            TotalPrice = totalPrice;

            OrderDate = DateTime.UtcNow;
            Status = "Pending";
        }
    }
}