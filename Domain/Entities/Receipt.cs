using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NCFApi.Domain.Entities
{
    public class Receipt
    {
        [Key]
        public int ReceiptId { get; set; }

        [Required]
        [ForeignKey("Donation")]
        public int DonationId { get; set; }

        [Required]
        [ForeignKey("Donor")]
        public int DonorId { get; set; }

        [Required]
        [ForeignKey("CharitableOrganization")]
        public int OrganizationId { get; set; }

        [Required]
        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }

        [Required]
        [ForeignKey("ReceiptStatus")]
        public int StatusId { get; set; }

        [Required]
        public DateTime IssuedDate { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(50)]
        public string ReceiptNumber { get; set; } = string.Empty; // ✅ Defaults to empty string

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        public string Notes { get; set; } = string.Empty; // ✅ Defaults to empty string
    }
}