namespace NCFApi.Domain.DTOs
{
    public class PaymentMethodDto
    {
        public int Id { get; set; }  // Unique Identifier
        public string MethodName { get; set; }  // e.g., Credit Card, PayPal, Bank Transfer
        public string Description { get; set; }  // Optional Details
        public bool IsActive { get; set; }  // Tracks whether the method is available
    }
}