
using System.ComponentModel.DataAnnotations;

namespace NCFApi.Domain.DTOs;

public class PermissionsDto
{
    public int PermissionId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(255)]
    public string Description { get; set; }
}
