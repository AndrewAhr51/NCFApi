namespace NCFApi.Domain.DTOs
{
    public class PaymentMethodDto
    {
        public int Id { get; set; }  // Unique Identifier

        public required string MethodName { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string Description { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required bool IsActive { get; set; } // Boolean values don't need defaults
    }
}