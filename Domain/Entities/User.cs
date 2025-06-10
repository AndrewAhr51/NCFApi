using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NCFApi.Domain.Entities
{
    public class User
    {
        [Key] // ✅ Explicitly define primary key
        public int UserId { get; set; }  // Unique Identifier

        public required string Username { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string Email { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string PasswordHash { get; set; } = string.Empty; // ✅ Defaults to empty string (Hashed Password for Security)
        public required int RoleId { get; set; }  // User Role (Admin, Manager, Viewer)

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Timestamp for creation
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;  // Timestamp for updates
    }
}