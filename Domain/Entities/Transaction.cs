using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NCFApi.Domain.Entities
{
    public class Transaction
    {
        [Key] // ✅ Explicitly define primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }  // Unique Identifier
        public required int DonorId { get; set; }  // Foreign Key referencing Donor
        public required decimal Amount { get; set; }  // Donation Amount
        public required DateTime TransactionDate { get; set; } = DateTime.UtcNow;  // Timestamp
        public required string PaymentMethod { get; set; }  // Credit Card, PayPal, etc.
        public required string Status { get; set; }  // Pending, Completed, Failed
        public required string ReferenceNumber { get; set; }  // External Payment Reference

        // ✅ Navigation Property
        public required Donor Donor { get; set; }
    }
}