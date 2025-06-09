namespace NCFApi.Domain.DTOs
{
    public class DonorDto
    {
        public int DonorId { get; set; }  // Unique Identifier

        public required string FirstName { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string LastName { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string Email { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string PhoneNumber { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string StreetAddressLine1 { get; set; } = string.Empty; // ✅ Defaults to empty string
        public string StreetAddressLine2 { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string City { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string State { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string PostalCode { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string Country { get; set; } = string.Empty; // ✅ Defaults to empty string

        public required DateTime DateOfBirth { get; set; }
    }
}