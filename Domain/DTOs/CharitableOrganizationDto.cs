using System.ComponentModel.DataAnnotations;

namespace NCFApi.Domain.DTOs;

public class CharitableOrganizationDto
{
    public int OrganizationId { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [StringLength(int.MaxValue)]
    public string Description { get; set; }

    [Required]
    [StringLength(50)]
    public string RegistrationNumber { get; set; }

    [StringLength(255)]
    public string Website { get; set; }

    [StringLength(255)]
    public string ContactEmail { get; set; }

    [StringLength(20)]
    public string ContactPhone { get; set; }

    [StringLength(255)]
    public string Address { get; set; }

    [StringLength(100)]
    public string City { get; set; }

    [StringLength(100)]
    public string State { get; set; }

    [StringLength(100)]
    public string Country { get; set; }

    [StringLength(20)]
    public string PostalCode { get; set; }

    public int? FoundedYear { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? TotalDonations { get; set; }

    public bool IsActive { get; set; } = true;
}