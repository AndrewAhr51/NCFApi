using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NCFApi.Domain.Entities
{
    public class Donation
    {
        [Key]
        public int DonationId { get; set; }

        [Required]
        [ForeignKey("Donor")]
        public int DonorId { get; set; }

        [Required]
        [ForeignKey("CharitableOrganization")]
        public int OrganizationId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime DonationDate { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; } = string.Empty; // ✅ Defaults to empty string

        [Required]
        [StringLength(100)]
        public string DonationReference { get; set; } = string.Empty; // ✅ Defaults to empty string

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = string.Empty; // ✅ Defaults to empty string

        public string Notes { get; set; } = string.Empty; // ✅ Defaults to empty string
    }
}