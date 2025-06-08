namespace NCFApi.Domain.DTOs
{
    public class CreateUserDto
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }  // Will be hashed before storage  
        public required string Role { get; set; }  // Admin, Manager, Viewer  
    }
}