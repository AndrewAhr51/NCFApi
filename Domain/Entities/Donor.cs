using System;
using System.Collections.Generic;

namespace NCFApi.Domain.Entities
{
    public class Donor
    {
        public int Id { get; set; }  // Unique Identifier
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Timestamp for creation
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;  // Timestamp for updates

        // ✅ Optional: Link Donations to Donors
        public required ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}