
using NCFApi.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace NCFApi.Domain.Entities;
public class RolePermission
{
    [Key]
    [Column(Order = 1)]
    public int RoleId { get; set; }

    [Key]
    [Column(Order = 2)]
    public int PermissionId { get; set; }

    // Navigation Properties
    [ForeignKey("RoleId")]
    public virtual Roles Roles { get; set; }

    [ForeignKey("PermissionId")]
    public virtual Permission Permission { get; set; }
}
