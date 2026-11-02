using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.API.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(book => book.Id);

        builder.Property(book => book.Title)
            .HasMaxLength(100);

        builder.Property(book => book.Author)
            .HasMaxLength(100);

        builder.Property(book => book.Price)
            .HasPrecision(10, 2);

        builder.HasOne(book => book.Genre)
            .WithMany()
            .HasForeignKey(book => book.GenreId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
