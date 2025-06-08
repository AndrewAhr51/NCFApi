namespace NCFApi.Domain.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }  // Unique Identifier
        public required int DonorId { get; set; }  // Foreign Key referencing Donor
        public required decimal Amount { get; set; }  // Donation Amount
        public required DateTime TransactionDate { get; set; }  // Timestamp
        public required string PaymentMethod { get; set; }  // Credit Card, PayPal, etc.
        public required string Status { get; set; }  // Pending, Completed, Failed
        public required string ReferenceNumber { get; set; }  // External Payment Reference
    }
}