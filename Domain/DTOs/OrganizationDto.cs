namespace NCFApi.Domain.DTOs
{
    public class OrganizationDto
    {
        public int Id { get; set; }  // Unique Identifier
        public required string Name { get; set; }  // Organization Name
        public required string ContactEmail { get; set; }  // Contact Email
        public required string PhoneNumber { get; set; }  // Contact Phone
        public required string Address { get; set; }  // Physical Location
        public required DateTime CreatedAt { get; set; }  // Timestamp for creation
        public required DateTime UpdatedAt { get; set; }  // Timestamp for updates
    }
}