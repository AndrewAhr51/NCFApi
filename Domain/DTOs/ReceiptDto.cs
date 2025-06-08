namespace NCFApi.Domain.DTOs
{
    public class ReceiptDto
    {
        public int Id { get; set; }  // Unique Identifier
        public required int TransactionId { get; set; }  // Foreign Key referencing Transaction
        public required DateTime IssuedDate { get; set; }  // Timestamp of issuance
        public required string ReceiptNumber { get; set; }  // Unique identifier for the receipt
        public required string IssuedBy { get; set; }  // Name of the issuer or organization
    }
}