namespace NCFApi.Domain.DTOs

{
    public class DonorDto
    {
        public int Id { get; set; }  // Unique Identifier
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}