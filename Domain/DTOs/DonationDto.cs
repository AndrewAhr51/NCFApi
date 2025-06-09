namespace NCFApi.Domain.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class DonationDto
    {
        public int DonationId { get; set; }
        [Required]
        public int DonorId { get; set; }

        [Required]
        public int OrganizationId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime DonationDate { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; }

        [Required]
        [StringLength(100)]
        public string DonationReference { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public string Notes { get; set; }
    }

}