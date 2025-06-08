namespace NCFApi.Domain.DTOs
{
    public class OrganizationDto
    {
        public int Id { get; set; }  // Unique Identifier
        public string Name { get; set; }  // Organization Name
        public string ContactEmail { get; set; }  // Contact Email
        public string PhoneNumber { get; set; }  // Contact Phone
        public string Address { get; set; }  // Physical Location
        public DateTime CreatedAt { get; set; }  // Timestamp for creation
        public DateTime UpdatedAt { get; set; }  // Timestamp for updates
    }
}