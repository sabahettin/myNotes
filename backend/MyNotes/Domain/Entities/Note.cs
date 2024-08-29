
namespace Domain.Entities
{
    public sealed class Note
    {
        public Note()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
