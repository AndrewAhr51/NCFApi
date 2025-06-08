namespace NCFApi.Domain.Entities
{
    public class Roles
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}