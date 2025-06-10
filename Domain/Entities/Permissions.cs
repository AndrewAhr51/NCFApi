using System.ComponentModel.DataAnnotations;

namespace NCFApi.Domain.Entities;

public class Permission
{
    [Key]
    public int PermissionId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty; // ✅ Defaults to empty string

    [StringLength(255)]
    public string Description { get; set; } = string.Empty; // ✅ Defaults to empty string
}