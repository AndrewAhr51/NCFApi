namespace NCFApi.Domain.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }  // Unique Identifier
        public required string Username { get; set; }  // Login Name
        public required string Email { get; set; }  // User Email
        public required int Role { get; set; }  // User Role (Admin, Manager, Viewer)
    }
}