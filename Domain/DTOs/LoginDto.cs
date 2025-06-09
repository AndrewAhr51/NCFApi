namespace NCFApi.Domain.DTOs
{
    public class LoginDto
    {
        public required string Username { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string Password { get; set; } = string.Empty; // ✅ Defaults to empty string
    }
}