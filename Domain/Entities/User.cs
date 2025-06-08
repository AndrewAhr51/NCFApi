using System;

namespace NCFApi.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }  // Unique Identifier
        public required string Username { get; set; }  // Login Name
        public required string Email { get; set; }  // User Email
        public required string PasswordHash { get; set; }  // Hashed Password for Security
        public required string Role { get; set; }  // User Role (Admin, Manager, Viewer)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Timestamp for creation
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;  // Timestamp for updates
    }
}