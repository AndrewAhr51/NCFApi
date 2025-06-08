namespace NCFApi.Domain.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }  // Unique Identifier
        public int DonorId { get; set; }  // Foreign Key referencing Donor
        public decimal Amount { get; set; }  // Donation Amount
        public DateTime TransactionDate { get; set; }  // Timestamp
        public string PaymentMethod { get; set; }  // Credit Card, PayPal, etc.
        public string Status { get; set; }  // Pending, Completed, Failed
        public string ReferenceNumber { get; set; }  // External Payment Reference
    }
}