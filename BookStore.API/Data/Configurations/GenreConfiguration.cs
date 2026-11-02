using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.API.Data.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(genre => genre.Id);

        builder.Property(genre => genre.Name)
            .HasMaxLength(50);

        builder.HasIndex(genre => genre.Name)
            .IsUnique();

        builder.HasData(
            new { Id = Guid.Parse("0c4f3b8e-5a1d-4e2b-9f6a-3d7c8b9e1f20"), Name = "Programming" },
            new { Id = Guid.Parse("7d2a9e61-3c4b-4f8d-a1e5-6b0c2d3e4f51"), Name = "Fantasy" },
            new { Id = Guid.Parse("a9e5c7d3-1b2f-4a6e-8c0d-9f8e7d6c5b42"), Name = "Self-Help" },
            new { Id = Guid.Parse("e3b1d5f7-9a2c-4e6b-b8d0-1c3e5f7a9b63"), Name = "Science Fiction" });
    }
}
