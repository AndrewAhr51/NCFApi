namespace NCFApi.Domain.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }  // Unique Identifier
        public string Username { get; set; }  // Login Name
        public string Email { get; set; }  // User Email
        public string Role { get; set; }  // User Role (Admin, Manager, Viewer)
    }
}