namespace NCFApi.Domain.DTOs
{
    public class ReceiptDto
    {
        public int Id { get; set; }  // Unique Identifier
        public int TransactionId { get; set; }  // Foreign Key referencing Transaction
        public DateTime IssuedDate { get; set; }  // Timestamp of issuance
        public string ReceiptNumber { get; set; }  // Unique identifier for the receipt
        public string IssuedBy { get; set; }  // Name of the issuer or organization
    }
}