
using System.ComponentModel.DataAnnotations;

namespace NCFApi.Domain.Entities;

public class ReceiptStatus
{
    [Key]
    public int StatusId { get; set; }

    [Required]
    [StringLength(50)]
    public string StatusName { get; set; }

    [StringLength(255)]
    public string Description { get; set; }
}
