using System;
using System.Collections.Generic;

namespace NCFApi.Domain.Entities
{
    public class Donor
    {
        public int Id { get; set; }  // Unique Identifier
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Timestamp for creation
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;  // Timestamp for updates

        // ✅ Optional: Link Donations to Donors
        public ICollection<Transaction> Transactions { get; set; }
    }
}