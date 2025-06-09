namespace NCFApi.Domain.DTOs
{
    public class CreateUserDto
    {
        public required string Username { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string Email { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string Password { get; set; } = string.Empty; // ✅ Defaults to empty string (Will be hashed)
        public required string Role { get; set; } = string.Empty; // ✅ Defaults to empty string (Admin, Manager, Viewer)
    }
}