using System;

namespace NCFApi.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }  // Unique Identifier
        public int DonorId { get; set; }  // Foreign Key referencing Donor
        public decimal Amount { get; set; }  // Donation Amount
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;  // Timestamp
        public string PaymentMethod { get; set; }  // Credit Card, PayPal, etc.
        public string Status { get; set; }  // Pending, Completed, Failed
        public string ReferenceNumber { get; set; }  // External Payment Reference

        // ✅ Navigation Property
        public Donor Donor { get; set; }
    }
}