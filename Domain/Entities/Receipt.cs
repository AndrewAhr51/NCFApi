using System;

namespace NCFApi.Domain.Entities
{
    public class Receipt
    {
        public int Id { get; set; }  // Unique Identifier
        public required int TransactionId { get; set; }  // Foreign Key referencing Transaction
        public required DateTime IssuedDate { get; set; } = DateTime.UtcNow;  // Timestamp of issuance
        public required string ReceiptNumber { get; set; }  // Unique Receipt Identifier
        public required string IssuedBy { get; set; }  // Name of the issuer or organization

        // ✅ Navigation Property
        public required Transaction Transaction { get; set; }
    }
}