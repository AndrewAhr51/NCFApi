using System.Collections.Generic;

namespace NCFApi.Domain.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }  // Unique Identifier
        public string MethodName { get; set; }  // e.g., Credit Card, PayPal, Bank Transfer
        public string Description { get; set; }  // Optional Details
        public bool IsActive { get; set; } = true;  // Tracks whether the method is available

        // ✅ Navigation Property
        public ICollection<Transaction> Transactions { get; set; }
    }
}