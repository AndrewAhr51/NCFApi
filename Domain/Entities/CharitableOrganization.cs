using System;
using System.ComponentModel.DataAnnotations;

namespace NCFApi.Domain.Entities
{
    public class CharitableOrganization
    {
        [Key]
        public int OrganizationId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty; // ✅ Defaults to empty string

        [StringLength(500)]
        public string Description { get; set; } = string.Empty; // ✅ Defaults to empty string

        [Required]
        [StringLength(50)]
        public string RegistrationNumber { get; set; } = string.Empty; // ✅ Defaults to empty string

        [Url]
        public string Website { get; set; } = string.Empty; // ✅ Defaults to empty string

        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; } = string.Empty; // ✅ Defaults to empty string

        [Phone]
        public string ContactPhone { get; set; } = string.Empty; // ✅ Defaults to empty string

        [StringLength(255)]
        public string Address { get; set; } = string.Empty; // ✅ Defaults to empty string

        [StringLength(100)]
        public string City { get; set; } = string.Empty; // ✅ Defaults to empty string

        [StringLength(100)]
        public string State { get; set; } = string.Empty; // ✅ Defaults to empty string

        [StringLength(100)]
        public string Country { get; set; } = string.Empty; // ✅ Defaults to empty string

        [StringLength(20)]
        public string PostalCode { get; set; } = string.Empty; // ✅ Defaults to empty string

        public int FoundedYear { get; set; }

        [Range(0, double.MaxValue)]
        public decimal TotalDonations { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}