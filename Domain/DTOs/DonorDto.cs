namespace NCFApi.Domain.DTOs
{
    public class DonorDto
    {
        public int Id { get; set; }  // Unique Identifier
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required DateTime DateOfBirth { get; set; }
    }
}