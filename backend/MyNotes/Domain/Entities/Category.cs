namespace Domain.Entities
{
    public sealed class Category
    {
        public Category()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;

    }
}
