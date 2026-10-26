using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Features.Books.UpdateBook
{
    public record UpdateBookDto
    (
        [Required][StringLength(100)] string Title,
        [Required][StringLength(100)] string Author,
        Guid GenreId,
        [Range(0, 1000)] decimal Price,
        DateOnly PublishedDate
    );
    
}
