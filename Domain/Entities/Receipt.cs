using System;

namespace NCFApi.Domain.Entities
{
    public class Receipt
    {
        public int Id { get; set; }  // Unique Identifier
        public int TransactionId { get; set; }  // Foreign Key referencing Transaction
        public DateTime IssuedDate { get; set; } = DateTime.UtcNow;  // Timestamp of issuance
        public string ReceiptNumber { get; set; }  // Unique Receipt Identifier
        public string IssuedBy { get; set; }  // Name of the issuer or organization

        // ✅ Navigation Property
        public Transaction Transaction { get; set; }
    }
}