using System;
using System.ComponentModel.DataAnnotations;

namespace NCFApi.Domain.DTOs;

public class ReceiptDto
{
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
    public DateTime IssuedDate { get; set; } = DateTime.UtcNow;

    [Required]
    [StringLength(50)]
    public string ReceiptNumber { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
    public decimal Amount { get; set; }

    public string Notes { get; set; }
}