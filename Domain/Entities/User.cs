using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NCFApi.Domain.Entities
{
    public class User
    {
        [Key] // ✅ Explicitly define primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }  // Unique Identifier
        public required string Username { get; set; }  // Login Name
        public required string Email { get; set; }  // User Email
        public required string PasswordHash { get; set; }  // Hashed Password for Security
        public required int RoleId { get; set; }  // User Role (Admin, Manager, Viewer)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Timestamp for creation
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;  // Timestamp for updates
    }
}