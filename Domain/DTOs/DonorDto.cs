namespace NCFApi.Domain.DTOs
{
    public class DonorDto
    {
        public int DonorId { get; set; }  // Unique Identifier
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string StreetAddressLine1 { get; set; } // ✅ First address line
        public string? StreetAddressLine2 { get; set; }  // ✅ Optional second address line
        public required string City { get; set; }
        public required string State { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
        public required DateTime DateOfBirth { get; set; }
    }
}