using System;
using System.ComponentModel.DataAnnotations;

namespace NCFApi.Application.DTOs
{
    public class ReceiptDto
    {
        [Required]
        public int ReceiptId { get; set; }

        [Required]
        public int DonationId { get; set; }

        [Required]
        public int DonorId { get; set; }

        [Required]
        public int OrganizationId { get; set; }

        [Required]
        public int PaymentMethodId { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public DateTime IssuedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ReceiptNumber { get; set; } = string.Empty; // ✅ Defaults to empty string

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        public string Notes { get; set; } = string.Empty; // ✅ Defaults to empty string
    }
}