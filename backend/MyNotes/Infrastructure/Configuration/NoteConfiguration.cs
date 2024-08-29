using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    internal class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.Description).IsRequired(false);
            builder.HasIndex(x => x.Title).IsUnique();

        }
    }
}
