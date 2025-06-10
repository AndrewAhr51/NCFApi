using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NCFApi.Domain.Entities
{
    public class Donor
    {
        [Key] // ✅ Explicitly define primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DonorId { get; set; }  // Unique Identifier

        public required int UserId { get; set; }  // Links donor to a user
        public required string FirstName { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string LastName { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string Email { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string PhoneNumber { get; set; } = string.Empty; // ✅ Defaults to empty string

        // ✅ Split Address into separate fields
        public required string StreetAddressLine1 { get; set; } = string.Empty; // ✅ Defaults to empty string
        public string StreetAddressLine2 { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string City { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string State { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string PostalCode { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string Country { get; set; } = string.Empty; // ✅ Defaults to empty string

        public required DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Timestamp for creation
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;  // Timestamp for updates
    }
}