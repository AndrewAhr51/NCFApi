using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NCFApi.Domain.Entities
{
    public class PaymentMethod
    {
        [Key] // ✅ Explicitly define primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Unique Identifier

        public required string MethodName { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required string Description { get; set; } = string.Empty; // ✅ Defaults to empty string
        public required bool IsActive { get; set; } = true;  // Tracks whether the method is available
    }
}