namespace NCFApi.Domain.DTOs
{
    public class CreateRoleDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}