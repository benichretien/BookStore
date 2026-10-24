using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Dtos
{
    public record CreateBookDto
    (
        [Required][StringLength(100)] string Title,
        [Required][StringLength(100)] string Author,
        Guid GenreId,
        [Range(0, 1000)] decimal Price,
        DateOnly PublishedDate
    );
}
