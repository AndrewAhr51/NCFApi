using System.ComponentModel.DataAnnotations;

namespace NCFApi.Domain.DTOs;

public class RolePermissionDto
{
    [Required]
    public int RoleId { get; set; }

    [Required]
    public int PermissionId { get; set; }
}
