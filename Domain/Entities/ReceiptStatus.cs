using System.ComponentModel.DataAnnotations;

namespace NCFApi.Domain.Entities;

public class ReceiptStatus
{
    [Key]
    public int StatusId { get; set; }

    [Required]
    [StringLength(50)]
    public string StatusName { get; set; } = string.Empty; // ✅ Defaults to empty string

    [StringLength(255)]
    public string Description { get; set; } = string.Empty; // ✅ Defaults to empty string
}