namespace NCFApi.Domain.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }  // Unique Identifier

        public required string Username { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string Email { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required int Role { get; set; } // ✅ Integer remains unchanged (Admin, Manager, Viewer)
    }
}