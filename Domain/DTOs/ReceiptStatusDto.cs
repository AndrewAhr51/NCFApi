
using System.ComponentModel.DataAnnotations;

namespace NCFApi.Domain.DTOs;

public class ReceiptStatusDto
{
    public int StatusId { get; set; }

    [Required]
    [StringLength(50)]
    public string StatusName { get; set; }

    [StringLength(255)]
    public string Description { get; set; }
}
