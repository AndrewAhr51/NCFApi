using System;
using System.Collections.Generic;

namespace NCFApi.Domain.Entities
{
    public class Organization
    {
        public int Id { get; set; }  // Unique Identifier
        public string Name { get; set; }  // Organization Name
        public string ContactEmail { get; set; }  // Contact Email
        public string PhoneNumber { get; set; }  // Contact Phone
        public string Address { get; set; }  // Physical Location
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Timestamp for creation
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;  // Timestamp for updates

        // ✅ Navigation Property
        public ICollection<Campaign> Campaigns { get; set; }
    }
}