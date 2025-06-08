namespace NCFApi.Domain.DTOs
{
    public class UpdateUserDto
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public string? Password { get; set; } // Nullable to allow updates without changing password
    }
}