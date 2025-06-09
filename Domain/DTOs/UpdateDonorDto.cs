namespace NCFApi.Domain.DTOs
{
    public class UpdateDonorDto
    {
        public required string FirstName { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string LastName { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string Email { get; set; } = string.Empty; // ✅ Defaults to empty string

        public string PhoneNumber { get; set; } = string.Empty; // ✅ Defaults to empty string
        public string StreetAddressLine1 { get; set; } = string.Empty; // ✅ Defaults to empty string
        public string StreetAddressLine2 { get; set; } = string.Empty; // ✅ Defaults to empty string
        public string City { get; set; } = string.Empty; // ✅ Defaults to empty string
        public string State { get; set; } = string.Empty; // ✅ Defaults to empty string
        public string PostalCode { get; set; } = string.Empty; // ✅ Defaults to empty string
        public string Country { get; set; } = string.Empty; // ✅ Defaults to empty string

        public DateOnly? DateOfBirth { get; set; }
    }
}